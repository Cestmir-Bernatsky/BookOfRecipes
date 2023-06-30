using BookOfRecipes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookOfRecipes.Pages.NewRecipe
{
    [BindProperties(SupportsGet = true)]
    public class AddNewRecipeModel : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public  AddNewRecipeModel(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public RecipeEntity Recipe { get; set; }

        public List<IngredientEntitty> ListOfIngredients { get; set; }

        public void OnGet()
        {
            ListOfIngredients = _context.Ingredients.ToList();
        }

        public async Task <IActionResult> OnPostAsync() 
        {
            Console.WriteLine("Test");
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //else
            //{
            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();
         return Page();
         
           
        }
    }
}
