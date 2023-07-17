using System.ComponentModel.DataAnnotations;

namespace BookOfRecipes.Entities
{
    public class RecipeEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Jméno receptu je povinné")]
        public string? NameOfRecipe { get; set; }

        [Required(ErrorMessage = "Autor receptu je povinný")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Postup receptu je povinný")]
        public string? Directions { get; set; }


        public ICollection<RecipeIngredientEntity>? RecipeIngredients { get; set; }
    }
}
