using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class homeSettinChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "HomeSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "HomeSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "HomeSettings");

            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "HomeSettings");
        }
    }
}
