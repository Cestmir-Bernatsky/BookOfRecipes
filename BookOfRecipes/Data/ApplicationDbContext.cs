using BookOfRecipes.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookOfRecipes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {}

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntitty> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>()
                .HasMany(x => x.Ingredients)
                .WithMany(y => y.Recipes)
                .UsingEntity(j => j.ToTable("RecipeIngredient"));
        }
    }

    
}
