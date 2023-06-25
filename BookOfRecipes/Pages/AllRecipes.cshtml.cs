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
    public class AllRecipesModel : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public AllRecipesModel(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RecipeEntity> RecipeEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recipes != null)
            {
                RecipeEntity = await _context.Recipes.ToListAsync();
            }
        }
    }
}
