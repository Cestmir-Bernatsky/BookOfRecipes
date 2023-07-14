namespace BookOfRecipes.Entities
{
    public class IngredientEntitty
    {
        public int Id { get; set; }
        public string NameOfIngredient { get; set; }
        public ICollection<RecipeIngredientEntity> RecipeIngredients { get; set; }
    }
}
