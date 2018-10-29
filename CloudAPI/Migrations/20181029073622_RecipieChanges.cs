using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudAPI.Migrations
{
    public partial class RecipieChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_AspNetUsers_IdentityId",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeComment_AspNetUsers_IdentityId",
                table: "RecipeComment");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLike_AspNetUsers_IdentityId",
                table: "RecipeLike");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRating_AspNetUsers_IdentityId",
                table: "RecipeRating");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRating_IdentityId",
                table: "RecipeRating");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLike_IdentityId",
                table: "RecipeLike");

            migrationBuilder.DropIndex(
                name: "IX_RecipeComment_IdentityId",
                table: "RecipeComment");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IdentityId",
                table: "Recipe");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "RecipeRating",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "RecipeLike",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "RecipeComment",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "Recipe",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecipeRating",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecipeLike",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecipeComment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RecipeRating",
                newName: "IdentityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RecipeLike",
                newName: "IdentityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RecipeComment",
                newName: "IdentityId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Recipe",
                newName: "IdentityId");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "RecipeRating",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "RecipeLike",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "RecipeComment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRating_IdentityId",
                table: "RecipeRating",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLike_IdentityId",
                table: "RecipeLike",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeComment_IdentityId",
                table: "RecipeComment",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IdentityId",
                table: "Recipe",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_AspNetUsers_IdentityId",
                table: "Recipe",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComment_AspNetUsers_IdentityId",
                table: "RecipeComment",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLike_AspNetUsers_IdentityId",
                table: "RecipeLike",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRating_AspNetUsers_IdentityId",
                table: "RecipeRating",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
