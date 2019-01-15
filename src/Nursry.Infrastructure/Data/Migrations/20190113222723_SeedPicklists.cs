using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class SeedPicklists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BottleContents",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { new Guid("8c0544b5-3fdd-4f48-ab4e-a2820196f5d8"), "Formula" },
                    { new Guid("79ea25f4-7b1f-48e8-8fdc-78894b871083"), "Breast milk" }
                });

            migrationBuilder.InsertData(
                table: "DiaperTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1206a261-8ea0-4d88-b427-e8c41057fb5f"), "Pee" },
                    { new Guid("a3a499c5-b271-4540-a913-fb1cdbf542a3"), "Poo" },
                    { new Guid("79640e24-1a12-4121-99ab-943f55fcdb90"), "Both" }
                });

            migrationBuilder.InsertData(
                table: "FeedingTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("9384fdce-898d-4c65-8007-014bdae60487"), "Left Breast" },
                    { new Guid("2f9622c6-128d-43cd-ba3b-3c685e905f98"), "Right Breast" },
                    { new Guid("2588236e-f2f7-4a39-8a16-348a15b94041"), "Bottle" },
                    { new Guid("22fc12b5-92ef-4b88-b5aa-7d50c6523ebb"), "Meal" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("246f4ecf-0268-4a69-a14f-93221658b29c"), "Male" },
                    { new Guid("6b852f22-9419-4125-8e5a-6914049bed85"), "Female" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BottleContents",
                keyColumn: "Id",
                keyValue: new Guid("79ea25f4-7b1f-48e8-8fdc-78894b871083"));

            migrationBuilder.DeleteData(
                table: "BottleContents",
                keyColumn: "Id",
                keyValue: new Guid("8c0544b5-3fdd-4f48-ab4e-a2820196f5d8"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("1206a261-8ea0-4d88-b427-e8c41057fb5f"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("79640e24-1a12-4121-99ab-943f55fcdb90"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("a3a499c5-b271-4540-a913-fb1cdbf542a3"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("22fc12b5-92ef-4b88-b5aa-7d50c6523ebb"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("2588236e-f2f7-4a39-8a16-348a15b94041"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("2f9622c6-128d-43cd-ba3b-3c685e905f98"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("9384fdce-898d-4c65-8007-014bdae60487"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("246f4ecf-0268-4a69-a14f-93221658b29c"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("6b852f22-9419-4125-8e5a-6914049bed85"));
        }
    }
}
