using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class AddBottleFeedingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContentsId",
                table: "Log",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Log_ContentsId",
                table: "Log",
                column: "ContentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_BottleContents_ContentsId",
                table: "Log",
                column: "ContentsId",
                principalTable: "BottleContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_BottleContents_ContentsId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_ContentsId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "ContentsId",
                table: "Log");
        }
    }
}
