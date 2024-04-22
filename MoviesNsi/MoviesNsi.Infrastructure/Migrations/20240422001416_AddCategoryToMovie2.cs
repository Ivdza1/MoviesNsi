using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesNsi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToMovie2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Movies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 2);

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "Movies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
