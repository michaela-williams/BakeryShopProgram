using System;
using System.Collections.Generic;

namespace BakeryShop
{
    public static class Shop
    {
        public static double Funds { get; private set; }
        public static Dictionary<Item, int> Stock { get; private set; }
        public static List<Order> ActiveOrders { get; private set; }
        public static Dictionary<string, Item> KnownItems { get; private set; }

        private static long CurrentOrderNumber;
        private const double StartingFunds = 50;

        public static void InitializeShop()
        {
            
            Funds = StartingFunds;
            ActiveOrders = new List<Order>();
            CurrentOrderNumber = 1;

            Bakery.InitializeBakery();
            InitializeStockAndItems();
        }

        private static void InitializeStockAndItems()
        {
            Stock = new Dictionary<Item, int>();
            KnownItems = new Dictionary<string, Item>();

            foreach (Recipe recipe in Bakery.KnownRecipes.Values)
            {
                Item item = new Item(recipe.Name, recipe);
                KnownItems[recipe.Name.ToLower()] = item;
                Stock[item] = 0;
            }
        }

        public static void SpendMoney (double amount)
        {
            Shop.Funds -= amount;
        }

        // Increments amount of item in Stock by one
        public static void AddItemToStock(Item item)
        {
            Stock[item]++;
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
