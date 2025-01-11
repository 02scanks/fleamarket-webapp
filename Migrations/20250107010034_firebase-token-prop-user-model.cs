using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleamarketApp.Migrations
{
    /// <inheritdoc />
    public partial class firebasetokenpropusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirebaseToken",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirebaseToken",
                table: "AspNetUsers");
        }
    }
}
