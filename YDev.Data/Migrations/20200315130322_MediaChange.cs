using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class MediaChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "RemoteUrl",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "ThumbnailPath",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Medias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Medias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteUrl",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailPath",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
