using System;
using System.Collections.Generic;
namespace BakeryShop
{
    public static class ShopInventory
    {
        public static Dictionary<Item, int> Stock { get; set; }

        public static void InitializeShopInventory()
        {
            Stock = new Dictionary<Item, int>();
        }


    }
}
