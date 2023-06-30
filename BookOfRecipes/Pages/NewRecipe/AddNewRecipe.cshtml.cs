using BookOfRecipes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookOfRecipes.Pages.NewRecipe
{
    public class AddNewRecipeModel : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public  AddNewRecipeModel(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public RecipeEntity Recipe { get; set; }
        [BindProperty]
        public List<RecipeEntity> ListOfIngredients { get; set; }

        //public IList<IngredientEntitty> Ingredient { get; set; }   
        public void OnGet()
        {
            //Ingredient = _context.Ingredients.ToList();
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
