using BookOfRecipes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookOfRecipes.Pages.NewRecipe
{
    //[BindProperties(SupportsGet = true)]
    public class AddNewRecipeModel : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public AddNewRecipeModel(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public RecipeEntity Recipe { get; set; }

        [BindProperty]
        public List<int> ingredientsIDs { get; set; }

        [BindProperty]
        public Dictionary<int, int> ingredientIDQuantity { get; set; }

        [BindProperty]
        public List<int> unitSelect { get; set; }


        public List<SelectListItem> Options { get; set; }
        public List<SelectListItem> UnitOptions { get; set; }


        public void OnGet(bool isMetric)
        {

            Options = _context.Ingredients.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameOfIngredient
            }).ToList();

            if (!isMetric)
            {
                UnitOptions = _context.Units.Where(y => y.unitType == "metric").Select(y => new SelectListItem
                {
                    Value = y.Id.ToString(),
                    Text = y.unit
                }).ToList();
            }
        }

        public async Task<JsonResult> OnGetUnit(bool isMetric)
        {
            if (!isMetric)
            {
                return new JsonResult(await _context.Units
                    .Where(q => q.unitType == "metric")
                    .ToListAsync());
            }
            else
            {
                return new JsonResult(await _context.Units
                    .Where(q => q.unitType == "imperial").ToListAsync());
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //else
            //{
            //_context.Recipes.Add(Recipe);
            Recipe.RecipeIngredients = new List<RecipeIngredientEntity>();
            int iter = 0;
            foreach (var ingredient in ingredientIDQuantity)
            { 
                var recipeIngredient = new RecipeIngredientEntity
                {
                    RecipesId = Recipe.Id,
                    IngredientsId = ingredient.Key,
                    Quantity = ingredient.Value,
                    unitsId = unitSelect[iter]
                };
                Recipe.RecipeIngredients.Add(recipeIngredient);
                iter++;
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
