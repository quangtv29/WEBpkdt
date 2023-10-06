using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateRolesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f68cf8e-88cc-4593-a426-4243a35b14c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "908b1a86-7630-4df6-b98a-6eb33a632980");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df2015df-dac5-4204-8cf3-2b5a3b5d3419");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(2370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 885, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("13716fd7-b872-4918-9cc3-9ef0bd6c0d2f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2eeb025f-41f8-4c2b-bab3-484051d405c7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(1008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("80ab680f-0d26-4434-9dbc-74d0fa1bf0af"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e71134c3-ed42-4943-b17c-9345abbc6f19"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(9671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3e49c7d8-adc4-49e7-bf66-dfb69a540cea"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ada14e63-a87a-4f1a-be8a-cf1928e4dc04"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(8388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ac72a231-c602-47b6-9084-0641b54782ca"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("84b4691f-d580-41aa-9b4e-cd2efc205ab2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(5823),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 883, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a841014e-fc30-48a6-8cba-153aeb0fcfae"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2191959c-0696-4860-8d60-b024d1c8fb94"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51c743f7-5067-468a-897b-ba21875524d1", "5779a149-1f77-438f-89b4-c6896c414df5", "Customer", "CUSTOMER" },
                    { "97567d17-e10e-43c1-9e34-97afdb9d0e5b", "be0d61ad-3889-46fa-a921-d9ccd121f461", "Employee", "EMPLOYEE" },
                    { "f3045383-4644-4263-b8eb-4aaa6c818568", "a8accd52-ab83-43d7-8754-cb72b70a656d", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51c743f7-5067-468a-897b-ba21875524d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97567d17-e10e-43c1-9e34-97afdb9d0e5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3045383-4644-4263-b8eb-4aaa6c818568");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 885, DateTimeKind.Local).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2eeb025f-41f8-4c2b-bab3-484051d405c7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("13716fd7-b872-4918-9cc3-9ef0bd6c0d2f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(8951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e71134c3-ed42-4943-b17c-9345abbc6f19"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("80ab680f-0d26-4434-9dbc-74d0fa1bf0af"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(6045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ada14e63-a87a-4f1a-be8a-cf1928e4dc04"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3e49c7d8-adc4-49e7-bf66-dfb69a540cea"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(3068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("84b4691f-d580-41aa-9b4e-cd2efc205ab2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ac72a231-c602-47b6-9084-0641b54782ca"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 883, DateTimeKind.Local).AddTicks(6101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2191959c-0696-4860-8d60-b024d1c8fb94"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a841014e-fc30-48a6-8cba-153aeb0fcfae"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f68cf8e-88cc-4593-a426-4243a35b14c7", "e544de34-9183-4c87-9d2f-3a39696593f0", "Employee", null },
                    { "908b1a86-7630-4df6-b98a-6eb33a632980", "8105c546-a080-42d8-b96e-5b7e91d526a5", "Customer", null },
                    { "df2015df-dac5-4204-8cf3-2b5a3b5d3419", "8eeb7b9a-2769-4a18-9602-1ae909561b9a", "Manager", null }
                });
        }
    }
}
