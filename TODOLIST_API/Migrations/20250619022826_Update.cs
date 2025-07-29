using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODOLIST_API.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TodoItems",
                newName: "DescriptionItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionItem",
                table: "TodoItems",
                newName: "Description");
        }
    }
}
