namespace BookOfRecipes.Entities
{
    public class RecipeIngredientEntity
    {
        public int RecipesId { get; set; }
        public RecipeEntity Recipe { get; set; }

        public int IngredientsId { get; set; }
        public IngredientEntitty Ingredient { get; set; }

        public int Quantity { get; set; }

        public int unitsId { get; set; }
        public UnitEntity Units { get; set; }
    }
}
