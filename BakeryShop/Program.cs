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
                //Console.ReadLine();

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
            Console.WriteLine();
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
                    break;
            }
        }

        public void ViewFunds()
        {
            Console.WriteLine($"Current Funds: {Shop.Funds}");
            Console.WriteLine();
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
            Console.WriteLine();
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
    }
}
