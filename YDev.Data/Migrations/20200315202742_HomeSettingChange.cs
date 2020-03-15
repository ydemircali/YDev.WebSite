using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class HomeSettingChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSettings_Galleries_HomeGalleryId",
                table: "HomeSettings");

            migrationBuilder.AlterColumn<long>(
                name: "HomeGalleryId",
                table: "HomeSettings",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSettings_Galleries_HomeGalleryId",
                table: "HomeSettings",
                column: "HomeGalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSettings_Galleries_HomeGalleryId",
                table: "HomeSettings");

            migrationBuilder.AlterColumn<long>(
                name: "HomeGalleryId",
                table: "HomeSettings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSettings_Galleries_HomeGalleryId",
                table: "HomeSettings",
                column: "HomeGalleryId",
                principalTable: "Galleries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
