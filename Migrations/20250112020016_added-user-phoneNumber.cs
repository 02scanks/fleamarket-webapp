using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleamarketApp.Migrations
{
    /// <inheritdoc />
    public partial class addeduserphoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerPhoneNumber",
                table: "GlobalItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerPhoneNumber",
                table: "GlobalItems");
        }
    }
}
