 using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class sale3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e644e2-fb78-4b89-868d-be38066495c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cac9c1b-c09f-422a-b08f-4782aa6e17a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9d54c42-dfe4-4264-941f-87e7aca875e2");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Sale",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Percent",
                table: "Sale",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6664),
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
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Sale",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 390, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5bc14d14-c057-45e1-9bf7-a66b4b03089a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7448d147-cb37-4eb7-bfeb-74b9f67e9d41"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(4916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d8258dfb-d8ce-4404-8652-65049adb11b7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("56e20107-8638-4908-a691-8d25723c6257"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(3777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ec60b889-86b1-4bc6-9a4b-c47a65d04bfd"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ab403421-1b5a-43cb-89b5-23a2305fe731"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(2318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8b425e9c-ebcc-4250-a4f3-148b6c58f59b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5025bdc7-d4fd-4e9c-b435-8d37d2e7b039"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(88),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 388, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d0a6d292-fb22-4b44-88f6-179387b4ed15"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e9cf25a6-bbf0-414d-be8a-5cdd7bae672b"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Percent",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7c73b499-acd5-4188-8886-c653fb9336dc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 390, DateTimeKind.Local).AddTicks(1942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7448d147-cb37-4eb7-bfeb-74b9f67e9d41"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5bc14d14-c057-45e1-9bf7-a66b4b03089a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(9263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("56e20107-8638-4908-a691-8d25723c6257"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d8258dfb-d8ce-4404-8652-65049adb11b7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(6751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ab403421-1b5a-43cb-89b5-23a2305fe731"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ec60b889-86b1-4bc6-9a4b-c47a65d04bfd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(2260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(2318));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5025bdc7-d4fd-4e9c-b435-8d37d2e7b039"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8b425e9c-ebcc-4250-a4f3-148b6c58f59b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 388, DateTimeKind.Local).AddTicks(4133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 11, 10, 59, 883, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e9cf25a6-bbf0-414d-be8a-5cdd7bae672b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d0a6d292-fb22-4b44-88f6-179387b4ed15"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80e644e2-fb78-4b89-868d-be38066495c3", "f889d848-b257-4328-9c1c-66e8e824f5b7", "Customer", "CUSTOMER" },
                    { "8cac9c1b-c09f-422a-b08f-4782aa6e17a5", "f9c7f0a7-fab7-4c7f-bd6e-2487c85aef68", "Employee", "EMPLOYEE" },
                    { "f9d54c42-dfe4-4264-941f-87e7aca875e2", "8d2f47b0-d1b8-4a6a-9177-813eb5084087", "Manager", "MANAGER" }
                });
        }
    }
}
