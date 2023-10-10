using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class bill1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "164105b3-2d20-4919-b75d-d8a27a7a38b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5247198b-894d-45a4-974d-3a7442068f45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ceaf05e-5897-44b5-8f25-0ac078951b32");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(5579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("801f8f25-53f3-4131-8fd5-77d984b17caf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7c73b499-acd5-4188-8886-c653fb9336dc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(4814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2bb69d2d-15a6-489b-a634-146a1a6436b3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5bc14d14-c057-45e1-9bf7-a66b4b03089a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(3583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f6551733-e2b2-4379-a043-1203eef902c8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d8258dfb-d8ce-4404-8652-65049adb11b7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(2239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d96ef45-3ae0-4e9d-a3dc-8a29b79f2bfa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ec60b889-86b1-4bc6-9a4b-c47a65d04bfd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c9caed1a-9bf9-45e6-9aa4-cbbb8a3dd705"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8b425e9c-ebcc-4250-a4f3-148b6c58f59b"));

            migrationBuilder.AddColumn<int>(
                name: "IntoMoney",
                table: "Bill",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 882, DateTimeKind.Local).AddTicks(8111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("80f1e838-28e0-4fd3-85cf-4a43ded5b317"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d0a6d292-fb22-4b44-88f6-179387b4ed15"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08374e98-6548-476c-9a5f-504ba00bc51f", "14d5fa9c-ace8-4ad4-9b85-6083485f4ac7", "Customer", "CUSTOMER" },
                    { "211a9233-e70a-48f8-b4e8-4df6ef014ce0", "945739dc-49c6-4676-a72f-c705bfd44314", "Manager", "MANAGER" },
                    { "729e919a-0ce4-4166-95ec-5ffa545109d9", "8ad9199a-37f4-46c5-8b0b-10251218d903", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08374e98-6548-476c-9a5f-504ba00bc51f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "211a9233-e70a-48f8-b4e8-4df6ef014ce0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "729e919a-0ce4-4166-95ec-5ffa545109d9");

            migrationBuilder.DropColumn(
                name: "IntoMoney",
                table: "Bill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Sale",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7c73b499-acd5-4188-8886-c653fb9336dc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("801f8f25-53f3-4131-8fd5-77d984b17caf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5bc14d14-c057-45e1-9bf7-a66b4b03089a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2bb69d2d-15a6-489b-a634-146a1a6436b3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(4916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d8258dfb-d8ce-4404-8652-65049adb11b7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f6551733-e2b2-4379-a043-1203eef902c8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(3777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ec60b889-86b1-4bc6-9a4b-c47a65d04bfd"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d96ef45-3ae0-4e9d-a3dc-8a29b79f2bfa"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(2318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8b425e9c-ebcc-4250-a4f3-148b6c58f59b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c9caed1a-9bf9-45e6-9aa4-cbbb8a3dd705"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(88),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 882, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d0a6d292-fb22-4b44-88f6-179387b4ed15"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("80f1e838-28e0-4fd3-85cf-4a43ded5b317"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "164105b3-2d20-4919-b75d-d8a27a7a38b3", "a2a152bf-7f6a-4027-99b3-0d5a0e3a22cf", "Employee", "EMPLOYEE" },
                    { "5247198b-894d-45a4-974d-3a7442068f45", "854a94f7-1662-4fba-a4ce-917a4434fafa", "Customer", "CUSTOMER" },
                    { "7ceaf05e-5897-44b5-8f25-0ac078951b32", "b447510a-f281-400d-80a5-db42c9a64539", "Manager", "MANAGER" }
                });
        }
    }
}
