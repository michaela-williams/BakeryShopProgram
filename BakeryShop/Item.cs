using System;
namespace BakeryShop
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; private set; }

        public Item(string name)
        {
            this.Name = name;
        }

    }
}
