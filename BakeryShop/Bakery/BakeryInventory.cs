using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public static class BakeryInventory
    {
        public static Dictionary<Ingredient, float> Stock { get; set; }

        public static void InitializeBakeryInventory()
        {
            Stock = new Dictionary<Ingredient, float>();
        }

        public static void Order(Ingredient ingredient, int quantity)
        {
            // Check if money is avaiable in Shop to purchase ingredients
            double cost = ingredient.Cost * quantity;

            if (Shop.Funds < cost)
            {
                Console.WriteLine("There is not enough money available to complete the purchase.");
                Console.WriteLine($"To order {quantity} of {ingredient.Name} you need {cost}. You have {Shop.Funds}.");
                return;
            }
            
            if (Stock.ContainsKey(ingredient))
            {
                Stock[ingredient] += quantity;
            }
            else
            {
                Stock[ingredient] = quantity;
            }
        }

        public static bool CheckIngredients((Ingredient, float)[] ingredients)
        {
            bool available = true;
            foreach( (Ingredient, float) ingredient in ingredients)
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
            foreach( (Ingredient, float) ingredient in ingredients)
            {
                if (Stock.ContainsKey(ingredient.Item1))
                {
                    Stock[ingredient.Item1] -= ingredient.Item2;
                }
            }
        }
    }
}
