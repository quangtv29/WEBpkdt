using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "657ca07f-248b-430a-9b0b-9b5be9f39890");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4ad5fe-45ad-4491-aeb2-b6f836e45ffd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98c1f170-c5ef-45ed-8d6f-58dfdf1d22f9");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("53f44416-d853-477d-a95a-31d67370c94b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("347b4e34-b14a-4b87-829b-a26193c33458"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("189d949a-d40a-4f35-9b60-1bb76a7bed86"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("37fd089e-07b9-42be-bc88-a8c95a4caac1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9d4afda6-f89d-4cd4-8ce8-ffb5da16b5b4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4690ebd5-8d4a-4c8b-b5a8-b83031b2cb9c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b7639ff3-5666-4818-9bae-6ac456613925"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("aa6f4f0f-abd7-4bf2-8a5a-f97bb5e16773"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7b5f479b-354a-4497-aea6-02ec3843838a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6bc2928b-15d0-494f-8a82-a52afae457af"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a7be09a9-0d0c-40e3-9716-0ee393454ed1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2f4013d0-14ed-4434-950a-199a3407c3c8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1eb40834-8304-4f23-ac59-be86990b431d", "40280bc5-a497-421b-8478-82d5aa0a3645", "Manager", "MANAGER" },
                    { "331dd680-0162-4548-8aaa-e4e6bf05fed4", "89145dea-50e2-465d-9a7f-78592d3ec70f", "Customer", "CUSTOMER" },
                    { "934f6eb5-8215-46b1-b847-79fb92f7f897", "a3153deb-b158-43d7-b037-5b220066f945", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eb40834-8304-4f23-ac59-be86990b431d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "331dd680-0162-4548-8aaa-e4e6bf05fed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "934f6eb5-8215-46b1-b847-79fb92f7f897");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("347b4e34-b14a-4b87-829b-a26193c33458"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("53f44416-d853-477d-a95a-31d67370c94b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("37fd089e-07b9-42be-bc88-a8c95a4caac1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("189d949a-d40a-4f35-9b60-1bb76a7bed86"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4690ebd5-8d4a-4c8b-b5a8-b83031b2cb9c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9d4afda6-f89d-4cd4-8ce8-ffb5da16b5b4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("aa6f4f0f-abd7-4bf2-8a5a-f97bb5e16773"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b7639ff3-5666-4818-9bae-6ac456613925"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6bc2928b-15d0-494f-8a82-a52afae457af"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7b5f479b-354a-4497-aea6-02ec3843838a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2f4013d0-14ed-4434-950a-199a3407c3c8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a7be09a9-0d0c-40e3-9716-0ee393454ed1"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "657ca07f-248b-430a-9b0b-9b5be9f39890", "f3337186-a3af-4379-98af-b21f8b1b8d5d", "Employee", "EMPLOYEE" },
                    { "6d4ad5fe-45ad-4491-aeb2-b6f836e45ffd", "33a32e29-f8b9-4974-9f4d-9674f5a322dc", "Manager", "MANAGER" },
                    { "98c1f170-c5ef-45ed-8d6f-58dfdf1d22f9", "c827936d-04d5-44d6-8b71-1a602100dcc7", "Customer", "CUSTOMER" }
                });
        }
    }
}
