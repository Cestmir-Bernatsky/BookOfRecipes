using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookOfRecipes.Data;
using BookOfRecipes.Entities;

namespace BookOfRecipes.Pages
{
    public class AddNewRecipe___Model : PageModel
    {
        private readonly BookOfRecipes.Data.ApplicationDbContext _context;

        public AddNewRecipe___Model(BookOfRecipes.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeEntity RecipeEntity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Recipes == null || RecipeEntity == null)
            {
                return Page();
            }

            _context.Recipes.Add(RecipeEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
