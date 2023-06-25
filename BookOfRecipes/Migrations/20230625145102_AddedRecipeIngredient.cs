using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOfRecipes.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecipeIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientEntittyRecipeEntity_Ingredients_IngredientsId",
                table: "IngredientEntittyRecipeEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientEntittyRecipeEntity_Recipes_RecipesId",
                table: "IngredientEntittyRecipeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientEntittyRecipeEntity",
                table: "IngredientEntittyRecipeEntity");

            migrationBuilder.RenameTable(
                name: "IngredientEntittyRecipeEntity",
                newName: "RecipeIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientEntittyRecipeEntity_RecipesId",
                table: "RecipeIngredient",
                newName: "IX_RecipeIngredient_RecipesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeIngredient",
                table: "RecipeIngredient",
                columns: new[] { "IngredientsId", "RecipesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientsId",
                table: "RecipeIngredient",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipesId",
                table: "RecipeIngredient",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientsId",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipesId",
                table: "RecipeIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeIngredient",
                table: "RecipeIngredient");

            migrationBuilder.RenameTable(
                name: "RecipeIngredient",
                newName: "IngredientEntittyRecipeEntity");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredient_RecipesId",
                table: "IngredientEntittyRecipeEntity",
                newName: "IX_IngredientEntittyRecipeEntity_RecipesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientEntittyRecipeEntity",
                table: "IngredientEntittyRecipeEntity",
                columns: new[] { "IngredientsId", "RecipesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientEntittyRecipeEntity_Ingredients_IngredientsId",
                table: "IngredientEntittyRecipeEntity",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientEntittyRecipeEntity_Recipes_RecipesId",
                table: "IngredientEntittyRecipeEntity",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
