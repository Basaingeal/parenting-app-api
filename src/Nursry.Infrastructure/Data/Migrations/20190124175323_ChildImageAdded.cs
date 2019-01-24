using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class ChildImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Children");

            migrationBuilder.AddColumn<bool>(
                name: "ImageAdded",
                table: "Children",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAdded",
                table: "Children");

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Children",
                nullable: true);
        }
    }
}
