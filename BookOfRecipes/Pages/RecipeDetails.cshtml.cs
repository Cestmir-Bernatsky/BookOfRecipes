using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookOfRecipes.Data;
using BookOfRecipes.Entities;

namespace BookOfRecipes.Pages
{
    public class RecipeDetailsModel : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public RecipeDetailsModel(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public RecipeEntity RecipeEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipeentity = await _context.Recipes.Include("Ingredients").FirstOrDefaultAsync(m => m.Id == id);
            if (recipeentity == null)
            {
                return NotFound();
            }
            else 
            {
                RecipeEntity = recipeentity;
            }
            return Page();
        }
    }
}
