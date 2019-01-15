using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class PickListsAsEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Genders_GenderId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_BottleContents_ContentsId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_DiaperTypes_DiaperTypeId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_FeedingTypes_FeedingTypeId",
                table: "Log");

            migrationBuilder.DropTable(
                name: "BottleContents");

            migrationBuilder.DropTable(
                name: "DiaperTypes");

            migrationBuilder.DropTable(
                name: "FeedingTypes");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Log_ContentsId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_DiaperTypeId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Log_FeedingTypeId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Children_GenderId",
                table: "Children");

            migrationBuilder.DropColumn(
                name: "ContentsId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "DiaperTypeId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "FeedingTypeId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Children");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Log",
                type: "decimal(8, 5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiaperType",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Contents",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeedingType",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Children",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaperType",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Contents",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "FeedingType",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Children");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Log",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 5)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContentsId",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DiaperTypeId",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FeedingTypeId",
                table: "Log",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GenderId",
                table: "Children",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BottleContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottleContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaperTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaperTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BottleContents",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { new Guid("e42a5065-dc76-49f0-ba59-343bb79594ab"), "Formula" },
                    { new Guid("66fc7156-8f18-4899-8fa9-38ef14073e03"), "Breast milk" }
                });

            migrationBuilder.InsertData(
                table: "DiaperTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("5943d161-cee7-44e6-98df-d94745afd252"), "Pee" },
                    { new Guid("c0b07ea3-f90d-4941-ad4f-e01135a6efce"), "Poo" },
                    { new Guid("a15db759-ec19-45bf-b06c-c5faabee68aa"), "Both" }
                });

            migrationBuilder.InsertData(
                table: "FeedingTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("81cbcf44-2e61-4660-8be0-99c22cb58c3f"), "Left Breast" },
                    { new Guid("06efe9ad-f609-4131-b334-6307bf60a878"), "Right Breast" },
                    { new Guid("2be3a084-8051-4c0e-b123-ae1d28cb0a38"), "Bottle" },
                    { new Guid("756f69bb-57da-4d41-a595-7ff89b04af73"), "Meal" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("982376cd-c73c-43e5-bbec-11c95b89a444"), "Male" },
                    { new Guid("a33c2cca-774a-418e-86c7-7a0b34c16937"), "Female" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_ContentsId",
                table: "Log",
                column: "ContentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_DiaperTypeId",
                table: "Log",
                column: "DiaperTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_FeedingTypeId",
                table: "Log",
                column: "FeedingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_GenderId",
                table: "Children",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Genders_GenderId",
                table: "Children",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_BottleContents_ContentsId",
                table: "Log",
                column: "ContentsId",
                principalTable: "BottleContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_DiaperTypes_DiaperTypeId",
                table: "Log",
                column: "DiaperTypeId",
                principalTable: "DiaperTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_FeedingTypes_FeedingTypeId",
                table: "Log",
                column: "FeedingTypeId",
                principalTable: "FeedingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
