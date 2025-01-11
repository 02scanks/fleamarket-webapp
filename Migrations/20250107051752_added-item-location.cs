using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleamarketApp.Migrations
{
    /// <inheritdoc />
    public partial class addeditemlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "GlobalItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "GlobalItems");
        }
    }
}
