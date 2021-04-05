using System;
namespace BakeryShop
{
    public class Ingredient
    {
        public string Name { get; private set; }
        public double Cost { get; private set; }

        public Ingredient(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
