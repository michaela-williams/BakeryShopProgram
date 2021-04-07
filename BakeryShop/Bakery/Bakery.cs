using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public static class Bakery
    {
        public static Dictionary<string, Ingredient> KnownIngredients { get; private set; }
        public static Dictionary<Ingredient, float> Stock { get; private set; }
        public static Dictionary<string, Recipe> KnownRecipes { get; private set; }

        private const float StartingStock = 5f;
        private static (string, float)[] StartingIngredients =
        {
            ("Baking Powder", 2.50f),
            ("Flour", 3.50f),
            ("Vanilla Extract", 8.00f),
            ("Sugar", 4.00f),
            ("Eggs", 2.00f),
            ("Butter", 4.00f),
            ("Milk", 3.00f),
            ("Baking Soda", 1.00f),
            ("Brown Sugar", 3.00f),
            ("Chocolate Chips", 3.00f),
            ("Cocoa Powder", 5.00f)
        };

        private static (string, float)[] WhiteCakeRecipe =
        {
            ("Flour", 0.1f),
            ("Sugar", 0.06f),
            ("Vanilla Extract", 0.08f),
            ("Eggs", 0.17f),
            ("Butter", 0.25f),
            ("Milk", 0.15f),
            ("Baking Powder", 0.03f)
        };

        private static (string, float)[] SugarCookieRecipe =
        {
            ("Flour", 0.3f),
            ("Sugar", 0.15f),
            ("Vanilla Extract", 0.06f),
            ("Eggs", 0.08f),
            ("Butter", 0.5f),
            ("Baking Powder", 0.03f)
        };

        private static (string, float)[] ChocolateCakeRecipe =
        {
            ("Flour", 0.1f),
            ("Sugar", 0.06f),
            ("Vanilla Extract", 0.08f),
            ("Eggs", 0.08f),
            ("Butter", 0.25f),
            ("Milk", 0.45f),
            ("Baking Powder", 0.03f),
            ("Cocoa Powder", 0.15f)
        };

        private static (string, (string, float)[])[] StartingRecipes =
        {
            ("White Cake", WhiteCakeRecipe),
            ("Sugar Cookies", SugarCookieRecipe),
            ("Chocolate Cake", ChocolateCakeRecipe)
        };

        public static void InitializeBakery()
        {
            InitializeIngredientsAndStock();
            InitializeRecipes();
        }

        // Add starting ingredients
        private static void InitializeIngredientsAndStock()
        {
            KnownIngredients = new Dictionary<string, Ingredient>();
            Stock = new Dictionary<Ingredient, float>();

            string name;
            float price;
            Ingredient current;

            foreach ((string, float) namePrice in StartingIngredients)
            {
                name = namePrice.Item1;
                price = namePrice.Item2;
                current = new Ingredient(name, price);
                KnownIngredients[name.ToLower()] = current;
                Stock[current] = StartingStock;
            }
        }

        private static void InitializeRecipes()
        {
            KnownRecipes = new Dictionary<string, Recipe>();

            string name;
            (string, float)[] ingredients;
            foreach ((string, (string, float)[]) nameRecipe in StartingRecipes)
            {
                name = nameRecipe.Item1;
                ingredients = nameRecipe.Item2;
                KnownRecipes[name.ToLower()] = new Recipe(name, ingredients);
            }
        }

        public static void Order(Ingredient ingredient, int quantity)
        {
            // Check if ingredient is known
            if (!Stock.ContainsKey(ingredient))
            {
                Console.WriteLine("Unknown Ingredient.");
                return;
            }

            // Check if money is available in Shop to purchase ingredients
            double cost = ingredient.Cost * quantity;

            if (Shop.Funds < cost)
            {
                Console.WriteLine("There is not enough money available to complete the purchase.");
                Console.WriteLine($"To order {quantity} of {ingredient.Name} you " +
                    $"need {Utils.GetUSD(cost)}. You have {Utils.GetUSD(Shop.Funds)}.");
                return;
            }

            Shop.SpendMoney(cost);
            Stock[ingredient] += quantity;
        }

        public static bool CheckIngredients((Ingredient, float)[] ingredients)
        {
            bool available = true;
            foreach ((Ingredient, float) ingredient in ingredients)
            {
                if (Stock.ContainsKey(ingredient.Item1))
                {
                    if (Stock[ingredient.Item1] < ingredient.Item2)
                    {
                        available = false;
                        break;
                    }
                }
                else
                {
                    available = false;
                    break;
                }
            }

            return available;
        }

        public static void UseIngredients((Ingredient, float)[] ingredients)
        {
            foreach ((Ingredient, float) ingredient in ingredients)
            {
                if (Stock.ContainsKey(ingredient.Item1))
                {
                    Stock[ingredient.Item1] -= ingredient.Item2;
                }
            }
        }
    }
}
