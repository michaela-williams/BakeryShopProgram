using System;
namespace BakeryShop
{
    public class UserInterface
    {
        public static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();

            bool running = true;
            // Run program until user exits
            while (running)
            {
                userInterface.DisplayMenu();
                string input = Console.ReadLine();
                input.Trim();

                switch (input)
                {
                    // View Funds
                    case "1":
                        break;

                    //View Bakery Inventory
                    case "2":
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
                        break;

                    // Choice Not Recognized
                    default:
                        break;
                }
            }
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
        }
    }
}
