using BookOfRecipes.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookOfRecipes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntitty> Ingredients { get; set; }
        public DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }
        public DbSet<UnitEntity> Units { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<RecipeEntity>()
        //        .HasMany(x => x.Ingredients)
        //        .WithMany(y => y.Recipes)
        //        .UsingEntity(j => j.ToTable("RecipeIngredient"));
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>()
                .HasMany(r => r.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipesId);

            modelBuilder.Entity<IngredientEntitty>()
                    .HasMany(i => i.RecipeIngredients)
                    .WithOne(ri => ri.Ingredient)
                    .HasForeignKey(ri => ri.IngredientsId);

            modelBuilder.Entity<RecipeIngredientEntity>()
                    .HasKey(ri => new { ri.RecipesId, ri.IngredientsId });

            modelBuilder.Entity<RecipeIngredientEntity>()
                .ToTable("RecipeIngredient");
        }
    }
}


    

