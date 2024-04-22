using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesNsi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Movies");
        }
    }
}
