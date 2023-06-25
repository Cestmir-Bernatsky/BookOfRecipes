using BookOfRecipes.Data;
using BookOfRecipes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookOfRecipes.Pages.AllRecipes
{
    public class AllRecipesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public AllRecipesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RecipeEntity> AllRecipes = new List<RecipeEntity>(); 
        public void OnGet()
        {
            AllRecipes = _context.Recipes.ToList(); 
        }
    }
}
