using System;

namespace BakeryShop
{
    public static class Shop
    {
        public static double Funds { get; private set; }

        private const double StartingFunds = 50;

        public static void InitializeShop()
        {
            Funds = StartingFunds;
        }

    }

    
}
