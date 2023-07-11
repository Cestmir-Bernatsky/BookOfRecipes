using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookOfRecipes.Data;
using BookOfRecipes.Entities;

namespace BookOfRecipes.Pages.Details
{
    [BindProperties(SupportsGet = true)]
    public class RecipeDetailsModel : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public RecipeDetailsModel(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public RecipeEntity Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var allrecipes =  await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(z => z.Ingredient)
                .ThenInclude(x => x.RecipeIngredients)
                .ThenInclude(c => c.Units)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }
            if(Recipe == null)
            {
                return NotFound();
            }
            else
            {
                Recipe = allrecipes;
            }
            return Page();
            
        }
    }
}
