using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class bill3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9f108f1a-d104-4b70-8a3a-6150eefc6ff1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("95692944-91e4-4d72-81f2-8e5106f9d9aa"));

            migrationBuilder.AddColumn<int>(
                name: "MinBill",
                table: "Sale",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(3782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(2909));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("de6e1a7a-4910-4c24-af7b-a3b1927380ae"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("664cd5d3-9949-43ed-8c7f-249ec613fc5e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(2713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ab3400b2-1972-4ade-8c64-0d97c6606add"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f6e7e252-7404-4ede-8102-d1c72374b44a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(1580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(365));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5924bbb8-18ff-4941-b17d-e3e0b3c41ad8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0afbaf5f-fb85-48ea-b13b-105c59cb5d7b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dbbc9a3f-056e-4b7a-80ce-638a908c404c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("234c23f6-c416-4a73-960e-bed849929fec"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 998, DateTimeKind.Local).AddTicks(7163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e2225d6b-fd32-4f1a-bc68-7f02bbfd0974"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("57736c28-f271-49f3-85b5-49243e2ff645"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1078bb72-54df-4123-ab2f-42feff5bb7e8", "6606e3a9-97a2-40c0-a4a4-923f98548c1c", "Customer", "CUSTOMER" },
                    { "4aaaeff2-ff18-4f13-9ca6-64c877fbb8b3", "02c52c43-e171-4ca2-8412-8857d878a87d", "Employee", "EMPLOYEE" },
                    { "f7540f60-2076-4008-9bf9-c6f9bf5a8db7", "7088ea7e-de8d-4688-8b2c-0d4c07cd075e", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1078bb72-54df-4123-ab2f-42feff5bb7e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aaaeff2-ff18-4f13-9ca6-64c877fbb8b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7540f60-2076-4008-9bf9-c6f9bf5a8db7");

            migrationBuilder.DropColumn(
                name: "MinBill",
                table: "Sale");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(3541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("95692944-91e4-4d72-81f2-8e5106f9d9aa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9f108f1a-d104-4b70-8a3a-6150eefc6ff1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(2909),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("664cd5d3-9949-43ed-8c7f-249ec613fc5e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("de6e1a7a-4910-4c24-af7b-a3b1927380ae"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(1752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f6e7e252-7404-4ede-8102-d1c72374b44a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ab3400b2-1972-4ade-8c64-0d97c6606add"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 605, DateTimeKind.Local).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0afbaf5f-fb85-48ea-b13b-105c59cb5d7b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5924bbb8-18ff-4941-b17d-e3e0b3c41ad8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(9238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("234c23f6-c416-4a73-960e-bed849929fec"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dbbc9a3f-056e-4b7a-80ce-638a908c404c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 13, 0, 48, 604, DateTimeKind.Local).AddTicks(6962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 998, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("57736c28-f271-49f3-85b5-49243e2ff645"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e2225d6b-fd32-4f1a-bc68-7f02bbfd0974"));

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
    }
}
