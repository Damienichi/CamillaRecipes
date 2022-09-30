using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamillaRecipes.Migrations
{
    /// <inheritdoc />
    public partial class PhotoChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Photo_RecipeImageId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Video_RecipeVideoId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeImageId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeImageId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeVideoId",
                table: "Recipes",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_RecipeVideoId",
                table: "Recipes",
                newName: "IX_Recipes_VideoId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Video",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Photo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Category",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_RecipeId",
                table: "Photo",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SubCategoryId",
                table: "Category",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_SubCategoryId",
                table: "Category",
                column: "SubCategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Recipes_RecipeId",
                table: "Photo",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Video_VideoId",
                table: "Recipes",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_SubCategoryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Recipes_RecipeId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Video_VideoId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Photo_RecipeId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Category_SubCategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Recipes",
                newName: "RecipeVideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_VideoId",
                table: "Recipes",
                newName: "IX_Recipes_RecipeVideoId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Video",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeImageId",
                table: "Recipes",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photo",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeImageId",
                table: "Recipes",
                column: "RecipeImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Photo_RecipeImageId",
                table: "Recipes",
                column: "RecipeImageId",
                principalTable: "Photo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Video_RecipeVideoId",
                table: "Recipes",
                column: "RecipeVideoId",
                principalTable: "Video",
                principalColumn: "Id");
        }
    }
}
