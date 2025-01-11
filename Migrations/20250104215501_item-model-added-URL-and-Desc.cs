using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleamarketApp.Migrations
{
    /// <inheritdoc />
    public partial class itemmodeladdedURLandDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GlobalItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "GlobalItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GlobalItems");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "GlobalItems");
        }
    }
}
