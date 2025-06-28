using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartNotepad.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteCategoryId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteTagId",
                table: "Notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteCategoryId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoteTagId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
