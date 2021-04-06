using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public static class Shop
    {
        public static double Funds { get; private set; }
        public static List<Recipe> KnownRecipes { get; set; }

        private const double StartingFunds = 50;

        public static void InitializeShop()
        {
            Funds = StartingFunds;
            KnownRecipes = new List<Recipe>();
        }

        // Should add a Recipe to KnownRecipes
        public static bool AddRecipe()
        {
            // stub
            return false;
        }

    }

    
}
