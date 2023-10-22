using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_UserId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UserId",
                table: "Customer");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5e9f9f77-5280-4aba-b6f7-24dff75699b7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("53f44416-d853-477d-a95a-31d67370c94b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("43370a4d-da32-44c0-9284-b142b2298523"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("189d949a-d40a-4f35-9b60-1bb76a7bed86"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8afc86e5-f615-4bbb-8f84-3248a7350490"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9d4afda6-f89d-4cd4-8ce8-ffb5da16b5b4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("62c91a90-321a-49a7-ac49-f3383a769d33"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b7639ff3-5666-4818-9bae-6ac456613925"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0c47d947-8e39-44fd-93af-2445c72c0993"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7b5f479b-354a-4497-aea6-02ec3843838a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e8e05a63-78fa-43f5-8c02-23d68b0fa14b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a7be09a9-0d0c-40e3-9716-0ee393454ed1"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a5cc262-1b56-47d6-a3d3-84c96d403610", "2a4364a1-ed1d-47d4-b8f7-32946e31a83b", "Employee", "EMPLOYEE" },
                    { "3b9cbfbd-9e06-4b3f-b3b7-dd2f8043f8bd", "ff48f765-2649-4a48-8a0c-979765cb8ee0", "Customer", "CUSTOMER" },
                    { "620968bb-489a-4089-b03f-50583fe5b139", "1d6f72b4-4212-495b-9fbd-1bf18e0fffb9", "Manager", "MANAGER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_Id",
                table: "Customer",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_Id",
                table: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a5cc262-1b56-47d6-a3d3-84c96d403610");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b9cbfbd-9e06-4b3f-b3b7-dd2f8043f8bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "620968bb-489a-4089-b03f-50583fe5b139");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("53f44416-d853-477d-a95a-31d67370c94b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5e9f9f77-5280-4aba-b6f7-24dff75699b7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("189d949a-d40a-4f35-9b60-1bb76a7bed86"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("43370a4d-da32-44c0-9284-b142b2298523"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9d4afda6-f89d-4cd4-8ce8-ffb5da16b5b4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8afc86e5-f615-4bbb-8f84-3248a7350490"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b7639ff3-5666-4818-9bae-6ac456613925"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("62c91a90-321a-49a7-ac49-f3383a769d33"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7b5f479b-354a-4497-aea6-02ec3843838a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0c47d947-8e39-44fd-93af-2445c72c0993"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a7be09a9-0d0c-40e3-9716-0ee393454ed1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e8e05a63-78fa-43f5-8c02-23d68b0fa14b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1eb40834-8304-4f23-ac59-be86990b431d", "40280bc5-a497-421b-8478-82d5aa0a3645", "Manager", "MANAGER" },
                    { "331dd680-0162-4548-8aaa-e4e6bf05fed4", "89145dea-50e2-465d-9a7f-78592d3ec70f", "Customer", "CUSTOMER" },
                    { "934f6eb5-8215-46b1-b847-79fb92f7f897", "a3153deb-b158-43d7-b037-5b220066f945", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_UserId",
                table: "Customer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
