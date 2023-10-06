using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addedRolesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 885, DateTimeKind.Local).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 921, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2eeb025f-41f8-4c2b-bab3-484051d405c7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d8a14a04-504e-4b52-b8be-a58e1d648c76"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(8951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 921, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e71134c3-ed42-4943-b17c-9345abbc6f19"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("69ec9a92-de71-4a62-811d-0046153f62de"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(6045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 920, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ada14e63-a87a-4f1a-be8a-cf1928e4dc04"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a03423e1-d87a-475b-99e5-1eb799ded2bf"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(3068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 920, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("84b4691f-d580-41aa-9b4e-cd2efc205ab2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1a08daaa-8679-4f47-b10d-7723397821ee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 883, DateTimeKind.Local).AddTicks(6101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 920, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2191959c-0696-4860-8d60-b024d1c8fb94"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("07883e72-0cc9-419c-84ee-784b09332251"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 921, DateTimeKind.Local).AddTicks(3408),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 885, DateTimeKind.Local).AddTicks(2467));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d8a14a04-504e-4b52-b8be-a58e1d648c76"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2eeb025f-41f8-4c2b-bab3-484051d405c7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 921, DateTimeKind.Local).AddTicks(1664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(8951));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("69ec9a92-de71-4a62-811d-0046153f62de"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e71134c3-ed42-4943-b17c-9345abbc6f19"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 920, DateTimeKind.Local).AddTicks(9421),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a03423e1-d87a-475b-99e5-1eb799ded2bf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ada14e63-a87a-4f1a-be8a-cf1928e4dc04"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 920, DateTimeKind.Local).AddTicks(6198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 884, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1a08daaa-8679-4f47-b10d-7723397821ee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("84b4691f-d580-41aa-9b4e-cd2efc205ab2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 4, 10, 50, 30, 920, DateTimeKind.Local).AddTicks(572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 17, 32, 883, DateTimeKind.Local).AddTicks(6101));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("07883e72-0cc9-419c-84ee-784b09332251"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2191959c-0696-4860-8d60-b024d1c8fb94"));
        }
    }
}
