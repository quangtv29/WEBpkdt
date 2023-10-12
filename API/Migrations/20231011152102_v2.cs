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
                keyValue: "01c43cf6-078d-4967-9dbc-ccaea323e26d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21079dd9-fd88-4f60-b5e7-ec05eadf3511");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee72cdad-3dac-49dd-93a1-4436acf5cbb8");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6db2b195-db47-44b8-97e6-948654b19fec"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("153c54a5-412e-4e16-919e-8d885c8be5c5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0c5c6d14-d99b-406f-96d4-bfbb45e1e8f5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("20512648-e7dc-49a5-8906-3429651d5775"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b846c343-b032-4c55-92e2-168981e1c673"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d1537ea7-f9a3-4014-8ac5-95bfcdab111e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2dd49965-bac5-43f2-882f-77c6c690dc7b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7282a7a2-fc4e-4750-98ae-d2085e6a531e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("afd3e130-8f83-4656-8f20-1ca757d5bb21"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2d179555-a387-4aaf-9c98-0f36db8a8a26"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d3f1ded5-34a6-4ec1-9562-142be60c0766"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dee664df-60e2-43de-b8d5-2695fc101ea5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5838e44a-43bd-4d11-abd7-26c17fad1a75"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("74cb8642-b646-49bc-8a7b-bc82dee62c43"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d73f8d1-8fe5-4d60-8559-91971aeba65a", "978ddcaf-f9d1-47af-8458-fdde06f412d8", "Customer", "CUSTOMER" },
                    { "64a7f932-7116-4f9b-b216-ea7ff67eef73", "5dcbe6c3-e516-4ff6-a6d3-1eb0c3f6f1db", "Manager", "MANAGER" },
                    { "98d11ae5-7cc0-4f2d-a0dc-a782295b8bae", "c0645364-0000-4ba1-8542-b542da3dbbbd", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d73f8d1-8fe5-4d60-8559-91971aeba65a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a7f932-7116-4f9b-b216-ea7ff67eef73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98d11ae5-7cc0-4f2d-a0dc-a782295b8bae");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("153c54a5-412e-4e16-919e-8d885c8be5c5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6db2b195-db47-44b8-97e6-948654b19fec"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("20512648-e7dc-49a5-8906-3429651d5775"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0c5c6d14-d99b-406f-96d4-bfbb45e1e8f5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d1537ea7-f9a3-4014-8ac5-95bfcdab111e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b846c343-b032-4c55-92e2-168981e1c673"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7282a7a2-fc4e-4750-98ae-d2085e6a531e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2dd49965-bac5-43f2-882f-77c6c690dc7b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2d179555-a387-4aaf-9c98-0f36db8a8a26"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("afd3e130-8f83-4656-8f20-1ca757d5bb21"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dee664df-60e2-43de-b8d5-2695fc101ea5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d3f1ded5-34a6-4ec1-9562-142be60c0766"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("74cb8642-b646-49bc-8a7b-bc82dee62c43"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5838e44a-43bd-4d11-abd7-26c17fad1a75"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01c43cf6-078d-4967-9dbc-ccaea323e26d", "8fb3891c-39c0-4e0a-9818-f4326e19a262", "Customer", "CUSTOMER" },
                    { "21079dd9-fd88-4f60-b5e7-ec05eadf3511", "60c8492d-8462-412b-a73f-9f7058469cbe", "Employee", "EMPLOYEE" },
                    { "ee72cdad-3dac-49dd-93a1-4436acf5cbb8", "af144824-6022-4f3e-ab01-354fdbc7d4c5", "Manager", "MANAGER" }
                });
        }
    }
}
