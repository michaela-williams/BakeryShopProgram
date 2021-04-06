using System;
namespace BakeryShop
{
    public class Item
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public Recipe ItemRecipe { get; private set; }

        public Item(string name)
        {
            this.Name = name;
            CalculatePrice();
        }

        // Calculates price based on the cost of ingredients
        private void CalculatePrice()
        {
            Price = 0;

            (Ingredient, float)[] ingredients = ItemRecipe.Ingredients;
            foreach((Ingredient, float) ingredient in ingredients)
            {
                var ingredientCost = ingredient.Item1.Cost;
                var ingredientQuantity = ingredient.Item2;
                Price += ingredientCost * ingredientQuantity;
            }

        
        }

    }
}
