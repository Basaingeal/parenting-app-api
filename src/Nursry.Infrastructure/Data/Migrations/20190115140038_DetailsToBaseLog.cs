using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class DetailsToBaseLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BottleContents",
                keyColumn: "Id",
                keyValue: new Guid("42cc37f6-2cb0-40f2-98ae-0eb44b535097"));

            migrationBuilder.DeleteData(
                table: "BottleContents",
                keyColumn: "Id",
                keyValue: new Guid("b6ec1fba-9aef-4b89-bb14-1bc420331049"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("0b771b7f-5026-4e2a-a24a-4f863bc4863c"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("0e97466b-0d0f-46ae-a504-62d4e4c674a1"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("d910453e-8da5-44db-bd22-84382072357c"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("3fdd2c0c-7aec-4479-b09f-d3c7e9dc711c"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("99c30681-094a-405c-8496-8b663c10a6c2"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("da550542-66db-458b-9ec3-57f3a0f4f4fa"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("eaa19920-dcfc-4140-b82a-8882f58da27b"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("75571732-3ee2-4c12-92dd-df80b5a7ed30"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("791410f0-735d-490e-b28b-89d1a5b84607"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BottleContents",
                keyColumn: "Id",
                keyValue: new Guid("66fc7156-8f18-4899-8fa9-38ef14073e03"));

            migrationBuilder.DeleteData(
                table: "BottleContents",
                keyColumn: "Id",
                keyValue: new Guid("e42a5065-dc76-49f0-ba59-343bb79594ab"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("5943d161-cee7-44e6-98df-d94745afd252"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("a15db759-ec19-45bf-b06c-c5faabee68aa"));

            migrationBuilder.DeleteData(
                table: "DiaperTypes",
                keyColumn: "Id",
                keyValue: new Guid("c0b07ea3-f90d-4941-ad4f-e01135a6efce"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("06efe9ad-f609-4131-b334-6307bf60a878"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("2be3a084-8051-4c0e-b123-ae1d28cb0a38"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("756f69bb-57da-4d41-a595-7ff89b04af73"));

            migrationBuilder.DeleteData(
                table: "FeedingTypes",
                keyColumn: "Id",
                keyValue: new Guid("81cbcf44-2e61-4660-8be0-99c22cb58c3f"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("982376cd-c73c-43e5-bbec-11c95b89a444"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("a33c2cca-774a-418e-86c7-7a0b34c16937"));

            migrationBuilder.InsertData(
                table: "BottleContents",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { new Guid("42cc37f6-2cb0-40f2-98ae-0eb44b535097"), "Formula" },
                    { new Guid("b6ec1fba-9aef-4b89-bb14-1bc420331049"), "Breast milk" }
                });

            migrationBuilder.InsertData(
                table: "DiaperTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("d910453e-8da5-44db-bd22-84382072357c"), "Pee" },
                    { new Guid("0b771b7f-5026-4e2a-a24a-4f863bc4863c"), "Poo" },
                    { new Guid("0e97466b-0d0f-46ae-a504-62d4e4c674a1"), "Both" }
                });

            migrationBuilder.InsertData(
                table: "FeedingTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("da550542-66db-458b-9ec3-57f3a0f4f4fa"), "Left Breast" },
                    { new Guid("99c30681-094a-405c-8496-8b663c10a6c2"), "Right Breast" },
                    { new Guid("3fdd2c0c-7aec-4479-b09f-d3c7e9dc711c"), "Bottle" },
                    { new Guid("eaa19920-dcfc-4140-b82a-8882f58da27b"), "Meal" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("791410f0-735d-490e-b28b-89d1a5b84607"), "Male" },
                    { new Guid("75571732-3ee2-4c12-92dd-df80b5a7ed30"), "Female" }
                });
        }
    }
}
