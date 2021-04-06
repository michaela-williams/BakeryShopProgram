using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public static class Shop
    {
        public static double Funds { get; private set; }
        public static List<Order> ActiveOrders { get; private set; }
        public static List<Recipe> KnownRecipes { get; set; }

        private static long CurrentOrderNumber;
        private const double StartingFunds = 50;

        public static void InitializeShop()
        {
            Funds = StartingFunds;
            KnownRecipes = new List<Recipe>();
            ActiveOrders = new List<Order>();
            CurrentOrderNumber = 1;
        }

        public static void AddOrder(Order newOrder)
        {
            ActiveOrders.Add(newOrder);
        }

        // Removes the order where OrderNumber == orderNumber from ActiveOrders
        // Returns true if successful, false otherwise
        public static bool FillOrder(long orderNumber)
        {
            int orderIndex = 0;
            for (int i = 0; i < ActiveOrders.Count; i++)
            {
                if (ActiveOrders[i].OrderNumber == orderNumber)
                {
                    orderIndex = i;
                }
            }

            // Order found
            if (orderIndex > 0)
            {
                ActiveOrders.RemoveAt(orderIndex);
                return true;
            }

            // Order not found
            return false;
        }

        // Should add a Recipe to KnownRecipes
        public static bool AddRecipe()
        {
            // stub
            return false;
        }

        // Return the current value of CurrentOrderNumber and increment
        // CurrentOrderNumber by one
        public static long GetOrderNumber()
        {
            var orderNumber = CurrentOrderNumber;
            CurrentOrderNumber++;
            return orderNumber;

        }

    }

    
}
