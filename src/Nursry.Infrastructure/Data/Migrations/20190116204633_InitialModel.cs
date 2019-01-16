using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    ImageUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<string>(nullable: true),
                    ChildId = table.Column<Guid>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTimeOffset>(nullable: true),
                    FeedingType = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(8, 5)", nullable: true),
                    Contents = table.Column<int>(nullable: true),
                    BreastFeedingLog_StartTime = table.Column<DateTimeOffset>(nullable: true),
                    BreastFeedingLog_FeedingType = table.Column<int>(nullable: true),
                    LeftBreastDuration = table.Column<TimeSpan>(nullable: true),
                    RightBreastDuration = table.Column<TimeSpan>(nullable: true),
                    EndTime = table.Column<DateTimeOffset>(nullable: true),
                    LastBreastUsed = table.Column<int>(nullable: true),
                    TimeOfDiaperChange = table.Column<DateTimeOffset>(nullable: true),
                    DiaperType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Children");
        }
    }
}
