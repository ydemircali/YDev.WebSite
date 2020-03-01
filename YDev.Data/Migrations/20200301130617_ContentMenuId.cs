using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class ContentMenuId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MenuId",
                table: "Contents",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_MenuId",
                table: "Contents",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Menus_MenuId",
                table: "Contents",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Menus_MenuId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_MenuId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Contents");
        }
    }
}
