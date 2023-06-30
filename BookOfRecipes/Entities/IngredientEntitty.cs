namespace BookOfRecipes.Entities
{
    public class IngredientEntitty
    {
        public int Id { get; set; }
        public string NameOfIngredient { get; set; }
        public ICollection<RecipeEntity> Recipes { get; set; }
    }
}
