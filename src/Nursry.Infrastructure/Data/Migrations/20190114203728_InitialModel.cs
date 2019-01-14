using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<Guid>(nullable: true),
                    ImageUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<string>(nullable: true),
                    ChildId = table.Column<Guid>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    TimeOfDiaperChange = table.Column<DateTime>(nullable: true),
                    DiaperTypeId = table.Column<Guid>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    FeedingTypeId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    ContentsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_BottleContents_ContentsId",
                        column: x => x.ContentsId,
                        principalTable: "BottleContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_DiaperTypes_DiaperTypeId",
                        column: x => x.DiaperTypeId,
                        principalTable: "DiaperTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_FeedingTypes_FeedingTypeId",
                        column: x => x.FeedingTypeId,
                        principalTable: "FeedingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Log_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BottleContents",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { new Guid("19821a66-51e1-4b78-b42a-302ef8f58f6d"), "Formula" },
                    { new Guid("544b07c6-75a7-4b2c-ad08-091118ab7e90"), "Breast milk" }
                });

            migrationBuilder.InsertData(
                table: "DiaperTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("de69d0a4-d993-4b94-85f5-70a12b4a4029"), "Pee" },
                    { new Guid("2cbb13a1-954e-4236-84b8-d93df5ba3594"), "Poo" },
                    { new Guid("2c2cee8e-9476-4616-b1a4-7fe032421e49"), "Both" }
                });

            migrationBuilder.InsertData(
                table: "FeedingTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("fb3aaa66-326d-4b30-9687-27379f63640d"), "Left Breast" },
                    { new Guid("412058ab-c92b-45a6-ba4e-fc8b7a0ed895"), "Right Breast" },
                    { new Guid("935726c8-f95c-4c19-add5-b1073ce4bf81"), "Bottle" },
                    { new Guid("961f9ea0-67ac-43bd-bf63-3969080982b8"), "Meal" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("26ec5151-bdc8-447c-b916-2c56ff2d77cc"), "Male" },
                    { new Guid("ca588f41-266b-4895-b5d1-520efcc5fd1d"), "Female" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_GenderId",
                table: "Children",
                column: "GenderId");

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
                name: "IX_Log_ChildId",
                table: "Log",
                column: "ChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "BottleContents");

            migrationBuilder.DropTable(
                name: "DiaperTypes");

            migrationBuilder.DropTable(
                name: "FeedingTypes");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
