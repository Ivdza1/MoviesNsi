using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesNsi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActorIdToMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "Movies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");
        }
    }
}
