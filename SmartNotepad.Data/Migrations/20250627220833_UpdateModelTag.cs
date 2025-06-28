using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartNotepad.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Tags_TagId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tags_TagId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Tags_TagId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_TagId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TagId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TagId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Exercises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_TagId",
                table: "Recipes",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TagId",
                table: "Notes",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TagId",
                table: "Exercises",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Tags_TagId",
                table: "Exercises",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tags_TagId",
                table: "Notes",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Tags_TagId",
                table: "Recipes",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
