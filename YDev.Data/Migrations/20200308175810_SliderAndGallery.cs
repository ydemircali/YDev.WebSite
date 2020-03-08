using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class SliderAndGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaGalleries_Medias_MediaId",
                table: "MediaGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_Medias_MediaId",
                table: "Sliders");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Sliders_MediaId",
                table: "Sliders");

            migrationBuilder.DropIndex(
                name: "IX_MediaGalleries_MediaId",
                table: "MediaGalleries");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "MediaGalleries");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Sliders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCoverImage",
                table: "MediaGalleries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "MediaGalleries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsCoverImage",
                table: "MediaGalleries");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "MediaGalleries");

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "Sliders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "MediaGalleries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordUser = table.Column<long>(type: "bigint", nullable: true),
                    ThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_MediaId",
                table: "Sliders",
                column: "MediaId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_Medias_MediaId",
                table: "Sliders",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
