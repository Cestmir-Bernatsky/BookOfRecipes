namespace BookOfRecipes.Entities
{
    public class RecipeEntity
    {
        public int Id { get; set; } 
        public string NameOfRecipe { get; set; }
        public string Author { get; set; } = "Uknown";
        public string Directions { get; set; }
        public ICollection<RecipeIngredientEntity> RecipeIngredients { get; set; }
        //public ICollection<IngredientEntitty> Ingredients { get; set; }

        //public List<IngredientEntitty> Ingredients { get; set; }
        //public ICollection<RecipeIngredientEntity> RecipesIngredients { get; set; }
    }
}
