using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class RefactorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Children_ChildId",
                table: "Log");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChildId",
                table: "Log",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreastFeedingLog_FeedingType",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastBreastUsed",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "LeftBreastDuration",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RightBreastDuration",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BreastFeedingLog_StartTime",
                table: "Log",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Children_ChildId",
                table: "Log",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Children_ChildId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "BreastFeedingLog_FeedingType",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "LastBreastUsed",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "LeftBreastDuration",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "RightBreastDuration",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "BreastFeedingLog_StartTime",
                table: "Log");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChildId",
                table: "Log",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Children_ChildId",
                table: "Log",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
