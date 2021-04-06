using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public static class Bakery
    {
        public static Dictionary<Ingredient, float> Stock { get; private set; }

        public static void InitializeBakery()
        {
            InitializeStock();
        } 

        // Add starting ingredients
        private static void InitializeStock()
        {
            Stock = new Dictionary<Ingredient, float>();

            Ingredient current = new Ingredient("Baking Powder", 2.50);
            Stock[current] = 2;

            current = new Ingredient("Flour", 3.50);
            Stock[current] = 5;

            current = new Ingredient("Vanilla Extract", 8.00);
            Stock[current] = 2;

            current = new Ingredient("Sugar", 4.00);
            Stock[current] = 5;

            current = new Ingredient("Eggs", 2.00);
            Stock[current] = 2;

            current = new Ingredient("Milk", 3.00);
            Stock[current] = 3;

            current = new Ingredient("Baking Soda", 1.00);
            Stock[current] = 1;

            current = new Ingredient("Brown Sugar", 3.00);
            Stock[current] = 3;

            current = new Ingredient("Chocolate Chips", 3.00);
            Stock[current] = 5;

            current = new Ingredient("Cocoa Powder", 5.00);
            Stock[current] = 3;

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
                Console.WriteLine($"To order {quantity} of {ingredient.Name} you need {cost}. You have {Shop.Funds}.");
                return;
            }

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
