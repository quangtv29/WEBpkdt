using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f28a04a-a1d8-4eb2-8918-5fa52b922a2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93c0d892-6e9e-4212-8ce9-4faecb3af592");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf46f723-fe39-4c7d-b44a-52b528311420");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5f86519b-a833-492a-8836-7fe9a52c3e36"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("526f0fd9-6f1c-4fa3-a8f9-0c1c471e5318"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8b7d6002-6a6d-4395-b827-e5fb8860bbc4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("79cbfa15-108c-4dd5-a228-42a5ac908197"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a580a285-2fad-405f-af54-eae2f32db634"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("060a1b49-e200-4302-8ba1-6dc379214d73"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0efbd180-4bda-40c2-b12b-66e0ce6a01ea"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("be1fab0a-85ae-45c4-ac5b-506c270a5ac5"));

            migrationBuilder.AlterColumn<int>(
                name: "Watched",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Create",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("92594653-2a4b-46e8-84cb-3ac6ff94ce43"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a562e374-191c-4540-887b-be1fc86500fe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8f817d8b-544c-4567-80e3-4f650c8f4e50"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9cc0e26a-aebb-4961-be8c-24c59f8b7c75"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("958b73f0-f489-4e28-89c2-1772c934cf4f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f357f7f0-0b64-4f63-bc05-2792f71554c0"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d7c4e97-78ec-40be-8e2b-b29ac4fe974a", "811cc269-c4d5-4a12-aee7-9ee982a3c020", "Manager", "MANAGER" },
                    { "86a7afc1-2215-4a40-bcbc-3047fbb031f6", "8dbe67f3-8117-47ee-9425-f0f12c112a89", "Employee", "EMPLOYEE" },
                    { "babb8358-60ad-4202-9d69-266df5f205f5", "2ffd9551-67b3-4e7d-8e2e-ab2758ea4514", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d7c4e97-78ec-40be-8e2b-b29ac4fe974a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86a7afc1-2215-4a40-bcbc-3047fbb031f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "babb8358-60ad-4202-9d69-266df5f205f5");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("526f0fd9-6f1c-4fa3-a8f9-0c1c471e5318"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5f86519b-a833-492a-8836-7fe9a52c3e36"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("79cbfa15-108c-4dd5-a228-42a5ac908197"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8b7d6002-6a6d-4395-b827-e5fb8860bbc4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("060a1b49-e200-4302-8ba1-6dc379214d73"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a580a285-2fad-405f-af54-eae2f32db634"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("be1fab0a-85ae-45c4-ac5b-506c270a5ac5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0efbd180-4bda-40c2-b12b-66e0ce6a01ea"));

            migrationBuilder.AlterColumn<int>(
                name: "Watched",
                table: "Notification",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Create",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a562e374-191c-4540-887b-be1fc86500fe"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("92594653-2a4b-46e8-84cb-3ac6ff94ce43"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9cc0e26a-aebb-4961-be8c-24c59f8b7c75"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8f817d8b-544c-4567-80e3-4f650c8f4e50"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f357f7f0-0b64-4f63-bc05-2792f71554c0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("958b73f0-f489-4e28-89c2-1772c934cf4f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f28a04a-a1d8-4eb2-8918-5fa52b922a2a", "06f5b5cd-c5e8-451e-b8a7-98ce3328478f", "Manager", "MANAGER" },
                    { "93c0d892-6e9e-4212-8ce9-4faecb3af592", "3847330b-6216-4f85-ae10-1e3c379955d5", "Customer", "CUSTOMER" },
                    { "bf46f723-fe39-4c7d-b44a-52b528311420", "b622a18f-bd15-448a-ad27-4a7a5655beb4", "Employee", "EMPLOYEE" }
                });
        }
    }
}
