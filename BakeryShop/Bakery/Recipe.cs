using System;
namespace BakeryShop
{
    public class Recipe
    {
        public string Name { get; set; }
        public (Ingredient, float)[] Ingredients { get; }
        public double Cost { get; set; }

        public Recipe(string name, (Ingredient, float)[] ingredients)
        {
            this.Name = name;
            this.Ingredients = ingredients;
        }

        // Attempts to bake this recipe
        // Returns true if successful; returns false otherwise
        public bool Bake()
        {
            // Verify that ingredients for recipe are available
            if (!BakeryInventory.CheckIngredients(Ingredients))
            {
                Console.WriteLine($"You do not have the required ingredients to bake {Name}.");
                return false;
            }

            // Remove recipe ingredients from BakeryInventory
            BakeryInventory.UseIngredients(Ingredients);

            return true;
        }
    }
}
