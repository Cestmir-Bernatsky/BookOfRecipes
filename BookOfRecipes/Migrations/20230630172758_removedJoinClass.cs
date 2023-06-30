using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOfRecipes.Migrations
{
    /// <inheritdoc />
    public partial class removedJoinClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_IngredientEntitty_IngredientsId",
                table: "RecipeIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientEntitty",
                table: "IngredientEntitty");

            migrationBuilder.RenameTable(
                name: "IngredientEntitty",
                newName: "Ingredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientsId",
                table: "RecipeIngredient",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientsId",
                table: "RecipeIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "IngredientEntitty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientEntitty",
                table: "IngredientEntitty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_IngredientEntitty_IngredientsId",
                table: "RecipeIngredient",
                column: "IngredientsId",
                principalTable: "IngredientEntitty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
