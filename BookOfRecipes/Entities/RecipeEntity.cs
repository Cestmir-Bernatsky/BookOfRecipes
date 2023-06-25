namespace BookOfRecipes.Entities
{
    public class RecipeEntity
    {
        public int Id { get; set; } 
        public string NameOfRecipe { get; set; } 
        public string Author { get; set;} 
        public string Directions { get; set; } 

        public ICollection<IngredientEntitty> Ingredients { get; set; }

    }
}
