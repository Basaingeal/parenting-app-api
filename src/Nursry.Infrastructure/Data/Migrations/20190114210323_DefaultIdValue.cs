using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nursry.Infrastructure.Data.Migrations
{
    public partial class DefaultIdValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Log",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Genders",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FeedingTypes",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DiaperTypes",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Children",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BottleContents",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Log",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Genders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FeedingTypes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DiaperTypes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Children",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BottleContents",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "newsequentialid()");

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
    }
}
