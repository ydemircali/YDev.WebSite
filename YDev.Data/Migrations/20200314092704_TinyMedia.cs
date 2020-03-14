using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class TinyMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TinyMediaUrl",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinyMediaUrl",
                table: "Sliders");
        }
    }
}
