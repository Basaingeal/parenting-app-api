using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class RemoveBFEndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndTime",
                table: "Log",
                nullable: true);
        }
    }
}
