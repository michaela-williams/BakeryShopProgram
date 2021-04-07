using System;
namespace BakeryShop
{
    public static class Utils
    {
        // Not necessary and not much shorter than a plain Console.WriteLine(),
        // but a bit simpler and makes the purpose of the function more obvious
        public static void AddSpacing()
        {
            Console.WriteLine();
        }

        public static void AddSpacing(int numberLines)
        {
            for(int i = 0; i < numberLines; i++)
            {
                Console.WriteLine();
            }    
        }

        public static string GetUSD(double amount)
        {
            return $"{string.Format("{0:c}", amount)}";
        }

    }
}
