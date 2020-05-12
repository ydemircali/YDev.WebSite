using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class GallerMediaUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaGalleries_Medias_MediaId",
                table: "MediaGalleries");

            migrationBuilder.DropIndex(
                name: "IX_MediaGalleries_MediaId",
                table: "MediaGalleries");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MediaGalleries");

            migrationBuilder.AddColumn<string>(
                name: "MediaContent",
                table: "MediaGalleries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "MediaGalleries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaContent",
                table: "MediaGalleries");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "MediaGalleries");

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "MediaGalleries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_MediaGalleries_MediaId",
                table: "MediaGalleries",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaGalleries_Medias_MediaId",
                table: "MediaGalleries",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
