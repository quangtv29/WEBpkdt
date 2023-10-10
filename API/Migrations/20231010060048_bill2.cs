using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class bill2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Percent",
                table: "Sale",
                type: "float",
                nullable: true,
                defaultValue: 1.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(3541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("95692944-91e4-4d72-81f2-8e5106f9d9aa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("801f8f25-53f3-4131-8fd5-77d984b17caf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(2909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("664cd5d3-9949-43ed-8c7f-249ec613fc5e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2bb69d2d-15a6-489b-a634-146a1a6436b3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(1752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f6e7e252-7404-4ede-8102-d1c72374b44a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f6551733-e2b2-4379-a043-1203eef902c8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0afbaf5f-fb85-48ea-b13b-105c59cb5d7b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d96ef45-3ae0-4e9d-a3dc-8a29b79f2bfa"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(9238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.AlterColumn<double>(
                name: "IntoMoney",
                table: "Bill",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Bill",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("234c23f6-c416-4a73-960e-bed849929fec"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c9caed1a-9bf9-45e6-9aa4-cbbb8a3dd705"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(6962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 882, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("57736c28-f271-49f3-85b5-49243e2ff645"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("80f1e838-28e0-4fd3-85cf-4a43ded5b317"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b16e7829-4dba-40b8-b8ab-e82f9bd88202", "6f274838-9f4a-4317-84f4-9dc3e8e479ea", "Manager", "MANAGER" },
                    { "b958227a-5380-4ed6-ac6d-94da3275c9f0", "236c8bf9-1374-478f-a841-ad760be99fbf", "Employee", "EMPLOYEE" },
                    { "e8f566f8-9ab9-402e-adcf-488a0201d611", "d62a14af-f14b-4cf3-af58-0187550a3b03", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b16e7829-4dba-40b8-b8ab-e82f9bd88202");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b958227a-5380-4ed6-ac6d-94da3275c9f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f566f8-9ab9-402e-adcf-488a0201d611");

            migrationBuilder.AlterColumn<int>(
                name: "Percent",
                table: "Sale",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldDefaultValue: 1.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(5579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("801f8f25-53f3-4131-8fd5-77d984b17caf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("95692944-91e4-4d72-81f2-8e5106f9d9aa"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(4814),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2bb69d2d-15a6-489b-a634-146a1a6436b3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("664cd5d3-9949-43ed-8c7f-249ec613fc5e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(3583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f6551733-e2b2-4379-a043-1203eef902c8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f6e7e252-7404-4ede-8102-d1c72374b44a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(2239),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(365));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d96ef45-3ae0-4e9d-a3dc-8a29b79f2bfa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0afbaf5f-fb85-48ea-b13b-105c59cb5d7b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 883, DateTimeKind.Local).AddTicks(918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.AlterColumn<int>(
                name: "IntoMoney",
                table: "Bill",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Bill",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c9caed1a-9bf9-45e6-9aa4-cbbb8a3dd705"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("234c23f6-c416-4a73-960e-bed849929fec"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 12, 39, 27, 882, DateTimeKind.Local).AddTicks(8111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("80f1e838-28e0-4fd3-85cf-4a43ded5b317"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("57736c28-f271-49f3-85b5-49243e2ff645"));

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
    }
}
