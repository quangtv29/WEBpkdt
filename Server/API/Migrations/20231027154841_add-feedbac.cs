using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addfeedbac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new Guid("2012331f-d044-4513-8269-f88dc7b24374"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5e9f9f77-5280-4aba-b6f7-24dff75699b7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cca52c2d-6388-4173-ac7c-1aefc3efda81"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("43370a4d-da32-44c0-9284-b142b2298523"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4d5535e6-a046-4194-b1c8-4dec1ce47fc4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8afc86e5-f615-4bbb-8f84-3248a7350490"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6a504510-005e-4a18-9b7a-77d77e3a160b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("62c91a90-321a-49a7-ac49-f3383a769d33"));

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("251788d2-00da-477d-956a-54dd3942b6f1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0c47d947-8e39-44fd-93af-2445c72c0993"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "DATEADD(hour, 7, GETUTCDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "DATEADD(hour, 7, GETUTCDATE())");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c551b853-fc1c-4969-b082-a128a0429c23"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e8e05a63-78fa-43f5-8c02-23d68b0fa14b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bbdc46b-01b7-420c-966b-87bb5ecf4e47", "da2bf729-42ed-49d8-bf21-1d5f1e476e2c", "Employee", "EMPLOYEE" },
                    { "3907244f-93d9-4a2d-86a8-deaef3cf13c3", "61192793-3008-4e7f-b872-9753f08a7d31", "Manager", "MANAGER" },
                    { "fb36212b-c21b-419a-8508-e92cd094edd1", "212aa488-d7b8-44be-8500-02fc27957e1f", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bbdc46b-01b7-420c-966b-87bb5ecf4e47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3907244f-93d9-4a2d-86a8-deaef3cf13c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb36212b-c21b-419a-8508-e92cd094edd1");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5e9f9f77-5280-4aba-b6f7-24dff75699b7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2012331f-d044-4513-8269-f88dc7b24374"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("43370a4d-da32-44c0-9284-b142b2298523"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cca52c2d-6388-4173-ac7c-1aefc3efda81"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8afc86e5-f615-4bbb-8f84-3248a7350490"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4d5535e6-a046-4194-b1c8-4dec1ce47fc4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("62c91a90-321a-49a7-ac49-f3383a769d33"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6a504510-005e-4a18-9b7a-77d77e3a160b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0c47d947-8e39-44fd-93af-2445c72c0993"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("251788d2-00da-477d-956a-54dd3942b6f1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "DATEADD(hour, 7, GETUTCDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "DATEADD(hour, 7, GETUTCDATE())");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e8e05a63-78fa-43f5-8c02-23d68b0fa14b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c551b853-fc1c-4969-b082-a128a0429c23"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a5cc262-1b56-47d6-a3d3-84c96d403610", "2a4364a1-ed1d-47d4-b8f7-32946e31a83b", "Employee", "EMPLOYEE" },
                    { "3b9cbfbd-9e06-4b3f-b3b7-dd2f8043f8bd", "ff48f765-2649-4a48-8a0c-979765cb8ee0", "Customer", "CUSTOMER" },
                    { "620968bb-489a-4089-b03f-50583fe5b139", "1d6f72b4-4212-495b-9fbd-1bf18e0fffb9", "Manager", "MANAGER" }
                });
        }
    }
}
