using System;

namespace BakeryShop
{
    class Program
    {
        private static bool Running { get; set; }

        static void Main(string[] args)
        {
            Program userInterface = new Program();

            Running = true;
            // Run program until user exits
            while (Running)
            {
                userInterface.DisplayMenu();
                string input = Console.ReadLine();
                input = input.Trim();
                userInterface.MakeSelection(input);
            }
        }

        public Program()
        {
            // Initialize static classes: BakeryInventory, Shop, ShopInventory
            BakeryInventory.InitializeBakeryInventory();
            Shop.InitializeShop();
            ShopInventory.InitializeShopInventory();

        }

        public void DisplayMenu()
        {
            Console.WriteLine("1 /tView Funds");
            Console.WriteLine("2 /tView Bakery Inventory");
            Console.WriteLine("3 /tView Shop Inventory");
            Console.WriteLine("4 /tOrder Ingredients");
            Console.WriteLine("5 /tBake");
            Console.WriteLine("6 /tView Orders");
            Console.WriteLine("7 /tTake Order");
            Console.WriteLine("8 /tFill Order");
            Console.WriteLine("9 /tExit");
            Utils.AddSpacing();
        }

        public void MakeSelection(string input)
        {
            switch (input)
            {
                // View Funds
                case "1":
                    ViewFunds();
                    break;

                //View Bakery Inventory
                case "2":
                    ViewBakeryInventory();
                    break;

                // View Shop Inventory
                case "3":
                    ViewShopInventory();
                    break;

                // Order Ingredients
                case "4":
                    break;

                // Bake
                case "5":
                    break;

                // View Orders
                case "6":
                    break;

                // Take Order
                case "7":
                    break;

                // Fill Order
                case "8":
                    break;

                // Exit
                case "9":
                    Quit();
                    break;

                // Choice Not Recognized
                default:
                    Console.WriteLine("Choice not recognized. Please enter a number" +
                        " from the menu.");
                    break;
            }

            // Add spacing, then pause until user presses enter key
            // If user has quit, do not pause but exit immediately
            if (Running)
            {
                Utils.AddSpacing();
                Console.Write("Press enter to continue...");
                Console.ReadLine();
            }
        }

        public void ViewFunds()
        {
            Console.WriteLine($"Current Funds: {Shop.Funds}");
        }

        public void ViewBakeryInventory()
        {
            if (BakeryInventory.Stock.Count <= 0)
            {
                Console.WriteLine("There are no ingredients in the bakery's inventory.");
            }

            else
            {
                Console.WriteLine("Bakery Inventory:");
                foreach (Ingredient ingredient in BakeryInventory.Stock.Keys)
                {
                    Console.WriteLine($"{ingredient.Name}:\t{BakeryInventory.Stock[ingredient]}");
                }
            }
        }

        public void ViewShopInventory()
        {
            if (ShopInventory.Stock.Count <= 0)
            {
                Console.WriteLine("There are no items in the shop's inventory.");
            }
            else
            {
                Console.WriteLine("Shop Inventory: ");
                foreach(Item item in ShopInventory.Stock.Keys)
                {
                    Console.WriteLine($"{item.Name}:\t{ShopInventory.Stock[item]}");
                }
            }
        }

        public void OrderIngredients()
        {

        }

        public void Bake()
        {

        }

        public void ViewOrders()
        {
            Console.WriteLine("Orders:");
            Utils.AddSpacing();

            foreach(Order order in Shop.ActiveOrders)
            {
                DisplayOrder(order);
                Utils.AddSpacing();
            }
        }

        public void TakeOrder()
        {

        }

        public void FillOrder()
        {

        }

        public void Quit()
        {
            Console.WriteLine("Are you sure you want to quit? (Y/N)");
            string input = Console.ReadLine();

            input = input.Trim().ToLower();

            if (input.Equals("y"))
            {
                Running = false;
            }

        }

        private void DisplayOrder(Order order)
        {
            // Display order header
            Console.WriteLine($"========== Order {order.OrderNumber} " +
                $"==========");
            Utils.AddSpacing();
            Console.WriteLine($"Customer:\t{order.CustomerName}");
            Utils.AddSpacing();

            Console.WriteLine("Ordered Items:");
            // Loop through items in the order
            foreach ((Item, int) cur in order.OrderedItems)
            {
                var item = cur.Item1;
                var quantity = cur.Item2;
              
                Console.WriteLine($"{item.Name}: ({item.Price})\tx{quantity}");
            }

            // Display Sales Total
            Utils.AddSpacing();
            Console.WriteLine($"Sales Total:\t{order.SalesTotal}");
        }
    }
}
