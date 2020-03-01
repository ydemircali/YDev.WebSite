using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YDev.Data.Migrations
{
    public partial class ContentAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(nullable: true),
                    RecordUser = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Spot = table.Column<string>(nullable: true),
                    CoverImage = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Html = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");
        }
    }
}
