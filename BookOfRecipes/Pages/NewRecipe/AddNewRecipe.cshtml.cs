using BookOfRecipes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

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
        public RecipeEntity? Recipe { get; set; } = new RecipeEntity();

        [BindProperty]
        public List<int>? ingredientsIDs { get; set; } = new List<int>();

        [BindProperty]
        [EachValueRequiredAttribute(ErrorMessage = "Množství je povinné")]
        public Dictionary<int, int>? ingredientIDQuantity { get; set; } = new Dictionary<int, int>();

        [BindProperty]
        [ValueRequiredListAttribute("Jednotka", ErrorMessage = "Jednotka je povinná")]
        public List<int>? unitSelect { get; set; } = new List<int>();


        public List<SelectListItem>? Options { get; set; } = new List<SelectListItem>();
        public List<SelectListItem>? UnitOptions { get; set; } = new List<SelectListItem>();


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

            if (!ModelState.IsValid) {
                OnGet(isMetric: false);
                await OnGetUnit(isMetric: false);
                return Page();
            }
            else
            {
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

                if (await _context.Recipes.AnyAsync(r => r.NameOfRecipe == Recipe.NameOfRecipe && r.Author == Recipe.Author))
                {
                    ModelState.AddModelError("DuplicateRecipe", "Tento recept již existuje");
                    OnGet(isMetric: false);
                    await OnGetUnit(isMetric: false);
                    return Page();
                }
                else
                {
                    _context.Recipes.Add(Recipe);
                    await _context.SaveChangesAsync();
                    return Redirect("/AllRecipes/AllRecipes");
                }
            }
            
        }
    }
}
