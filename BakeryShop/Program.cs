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
            // Initialize static classes: Bakery, Shop
            Bakery.InitializeBakery();
            Shop.InitializeShop();
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
            Utils.AddSpacing(3);
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
                    OrderIngredients();
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
            Console.WriteLine($"Current Funds: {Utils.GetUSD(Shop.Funds)}");
        }

        public void ViewBakeryInventory()
        {
            if (Bakery.Stock.Count <= 0)
            {
                Console.WriteLine("There are no ingredients in the bakery's inventory.");
            }

            else
            {
                Console.WriteLine("Bakery Inventory:");
                Utils.AddSpacing();
                foreach (Ingredient ingredient in Bakery.Stock.Keys)
                {
                    Console.WriteLine($"{ingredient.Name}: {Bakery.Stock[ingredient]}");
                }
            }
        }

        public void ViewShopInventory()
        {
            if (Shop.Stock.Count <= 0)
            {
                Console.WriteLine("There are no items in the shop's inventory.");
            }
            else
            {
                Console.WriteLine("Shop Inventory: ");
                foreach (Item item in Shop.Stock.Keys)
                {
                    Console.WriteLine($"{item.Name}:\t{Shop.Stock[item]}");
                }
            }
        }

        public void OrderIngredients()
        {
            // Header
            Console.WriteLine("========== Order Ingredients ==========");
            Utils.AddSpacing(2);

            // Continue taking Ingredient orders until the user exits
            bool ordering = true;
            string input;

            while (ordering)
            {
                // Header
                Console.WriteLine("Enter \"quit\" to exit the ordering menu or " +
                    "\"available\" to see available ingredients.");
                Console.WriteLine($"Current Funds: {Utils.GetUSD(Shop.Funds)}");
                Utils.AddSpacing();

                Console.WriteLine("What ingredient would you like to order?");
                input = Console.ReadLine().ToLower().Trim();

                // Exit menu
                if (input == "quit")
                {
                    ordering = false;
                }
                // Print known ingredients
                else if (input == "available")
                {
                    Console.WriteLine("Available Ingredients: ");
                    foreach (string name in Bakery.KnownIngredients.Keys)
                    {
                        Console.WriteLine(name);
                    }
                }
                // Attempt to order ingredient
                else
                {
                    HandleIngredientOrder(input);
                }

                Utils.AddSpacing();
            }
        }

        public void Bake()
        {

        }

        public void ViewOrders()
        {
            Console.WriteLine("Orders:");
            Utils.AddSpacing();

            foreach (Order order in Shop.ActiveOrders)
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

        // Helper Functions
        //======================================================================

        // Prints an Order to console
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

                Console.WriteLine($"{item.Name}: ({Utils.GetUSD(item.Price)})" +
                    $"\tx{quantity}");
            }

            // Display Sales Total
            Utils.AddSpacing();
            Console.WriteLine($"Sales Total:\t{Utils.GetUSD(order.SalesTotal)}");
        }

        // Handles actual ingredient ordering for OrderIngredients()
        private void HandleIngredientOrder(string input)
        {
            // Check if input is a known ingredient
            if (!Bakery.KnownIngredients.ContainsKey(input))
            {
                Console.WriteLine("Unknown Ingredient.");
            }
            else
            {
                var ingredient = Bakery.KnownIngredients[input];
                int amount;

                // Header
                Utils.AddSpacing();
                Console.WriteLine($"{ingredient.Name} costs " +
                    $"{Utils.GetUSD(ingredient.Cost)}.");
                Console.WriteLine($"Current Funds: {Utils.GetUSD(Shop.Funds)}");

                // Get a valid amount of ingredients to order
                while (true)
                {

                    Console.WriteLine("How many would you like to order?");
                    input = Console.ReadLine().Trim();
                    // Check if input is an int
                    try
                    {
                        amount = int.Parse(input);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("That isn't an amount you can order. " +
                            "Try a whole number.");
                    }
                }

                // Order ingredients
                Bakery.Order(ingredient, amount);
            }
        }
    }
}
