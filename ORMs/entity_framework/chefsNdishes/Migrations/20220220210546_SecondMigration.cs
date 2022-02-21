using Microsoft.EntityFrameworkCore.Migrations;

namespace chefsNdishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chefs");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Chefs",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Chefs",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Chefs");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Chefs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chefs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
