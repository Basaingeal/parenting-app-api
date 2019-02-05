using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class TrackDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Log",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Log",
                nullable: false,
                defaultValueSql: "SYSUTCDATETIME()");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Log",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Children",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Children",
                nullable: false,
                defaultValueSql: "SYSUTCDATETIME()");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Children",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Children");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Log",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Children",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID()");
        }
    }
}
