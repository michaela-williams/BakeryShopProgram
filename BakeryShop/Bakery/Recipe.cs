using System;
namespace BakeryShop
{
    public class Recipe
    {
        public string Name { get; set; }
        public (Ingredient, float)[] Ingredients { get; }

        public Recipe(string name, (Ingredient, float)[] ingredients)
        {
            this.Name = name;
            this.Ingredients = ingredients;
        }

        // Assumes all ingredients are valid
        public Recipe (string name, (string, float)[] ingredients)
        {
            this.Name = name;
            Ingredients = new (Ingredient, float)[ingredients.Length];

            for (int i = 0; i < ingredients.Length; i++)
            {
                string ingredientName = ingredients[i].Item1;
                float amount = ingredients[i].Item2;
                Ingredient ingredient = Bakery.KnownIngredients[ingredientName.ToLower()];
                Ingredients[i] = (ingredient, amount);
            }
        }

        // Attempts to bake this recipe
        // Returns true if successful; returns false otherwise
        public bool Bake()
        {
            // Verify that ingredients for recipe are available
            if (!Bakery.CheckIngredients(Ingredients))
            {
                return false;
            }

            // Remove recipe ingredients from Bakery.Stock
            // Add new item to Shop.Stock
            Bakery.UseIngredients(Ingredients);
            Shop.AddItemToStock(Shop.KnownItems[Name.ToLower()]);

            return true;
        }
    }
}
