using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addsold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e5f9941-dd51-43d2-9f73-9b0dfbd7e9b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73995847-3a41-4bed-8966-47092083a25c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8566ef57-b81c-49b6-b44b-7cfaa586a7aa");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dc2268a4-42b4-4681-a6bf-d0ada3cd8ddf"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6a846fe9-1c88-4a99-8f7e-69983f4edca0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("61a0334f-fabf-401a-9f32-3d5cee3ca1ed"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("76629030-11d1-4ed3-8d37-04e4d0716835"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8587a6d6-c5b6-4e08-86f4-aa257769b113"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5e786d38-5d54-44e4-901a-14d78ab5feb7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("97cc2ca7-8f6b-40af-b1f4-9cf834b07597"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a8120c73-e16e-4ac7-acd8-0897e7d44894"));

            migrationBuilder.AddColumn<int>(
                name: "Sold",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("afe4875d-14fa-4a60-98cf-ac3187514df9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b0dbbd31-db63-4a5c-b7cb-a5c91a358d72"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3237acfb-ba4b-4dc2-a57e-c30750784062"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f8bd5ce6-3cd6-442c-9d9f-7a93aa6ae59a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "048646ee-4aaf-424c-a015-f7c202d932f1", "be877a36-85bb-4ad0-8a8b-5ca99d928c9d", "Manager", "MANAGER" },
                    { "40490c64-c6a0-4619-930d-a7dea060eccd", "92d1461a-9bb3-4a70-bc1a-f8258e080747", "Customer", "CUSTOMER" },
                    { "97f40063-cf7e-4b38-b4a1-6d8ae4c0de4f", "bf4d4810-2c31-452f-bfd2-2142dfa0f803", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "048646ee-4aaf-424c-a015-f7c202d932f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40490c64-c6a0-4619-930d-a7dea060eccd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97f40063-cf7e-4b38-b4a1-6d8ae4c0de4f");

            migrationBuilder.DropColumn(
                name: "Sold",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6a846fe9-1c88-4a99-8f7e-69983f4edca0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dc2268a4-42b4-4681-a6bf-d0ada3cd8ddf"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("76629030-11d1-4ed3-8d37-04e4d0716835"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("61a0334f-fabf-401a-9f32-3d5cee3ca1ed"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5e786d38-5d54-44e4-901a-14d78ab5feb7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8587a6d6-c5b6-4e08-86f4-aa257769b113"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a8120c73-e16e-4ac7-acd8-0897e7d44894"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("97cc2ca7-8f6b-40af-b1f4-9cf834b07597"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b0dbbd31-db63-4a5c-b7cb-a5c91a358d72"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("afe4875d-14fa-4a60-98cf-ac3187514df9"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f8bd5ce6-3cd6-442c-9d9f-7a93aa6ae59a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3237acfb-ba4b-4dc2-a57e-c30750784062"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e5f9941-dd51-43d2-9f73-9b0dfbd7e9b6", "e4e6006a-f23c-4cc9-a6b8-af2f91ce247e", "Employee", "EMPLOYEE" },
                    { "73995847-3a41-4bed-8966-47092083a25c", "6c46eb3c-ef45-413f-af04-a2b351a52e94", "Customer", "CUSTOMER" },
                    { "8566ef57-b81c-49b6-b44b-7cfaa586a7aa", "6e93bf50-955b-4142-892d-32b76fc4c59a", "Manager", "MANAGER" }
                });
        }
    }
}
