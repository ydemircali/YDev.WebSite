using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class AdminTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "RoleTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RoleTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RecordUser",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordDate",
                table: "Titles",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RecordUser",
                table: "Titles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordDate",
                table: "RoleTypes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RecordUser",
                table: "RoleTypes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ThumbnailPath = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticPages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaGalleries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    MediaId = table.Column<long>(nullable: false),
                    GalleryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaGalleries_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaGalleries_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    MediaId = table.Column<long>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Time = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sliders_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaGalleries_GalleryId",
                table: "MediaGalleries",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGalleries_MediaId",
                table: "MediaGalleries",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_MediaId",
                table: "Sliders",
                column: "MediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaGalleries");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "StaticPages");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropColumn(
                name: "RecordDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecordUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecordDate",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "RecordUser",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "RecordDate",
                table: "RoleTypes");

            migrationBuilder.DropColumn(
                name: "RecordUser",
                table: "RoleTypes");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Titles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Titles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "RoleTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RoleTypes",
                type: "datetime2",
                nullable: true);
        }
    }
}
