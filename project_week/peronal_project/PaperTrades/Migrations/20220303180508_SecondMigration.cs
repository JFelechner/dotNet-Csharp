using Microsoft.EntityFrameworkCore.Migrations;

namespace PaperTrades.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BuyInPrice",
                table: "Wallets",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyInPrice",
                table: "Wallets");
        }
    }
}
