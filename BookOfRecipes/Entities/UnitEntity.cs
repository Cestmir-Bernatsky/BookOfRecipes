namespace BookOfRecipes.Entities
{
    public class UnitEntity
    {
        public int Id { get; set; }
        public string? unit { get; set; }
        public string? unitType { get; set; }

        public ICollection<RecipeIngredientEntity>? RecipeIngredients { get; set; }
    }
}
