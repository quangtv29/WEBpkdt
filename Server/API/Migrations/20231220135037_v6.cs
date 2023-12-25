using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c5bc3e0-d531-40e4-b2af-a71e4e61eee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f76af0dc-abf6-47bb-b071-3db83d3426a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7d129f-e08a-48dd-aa48-906e87a93b41");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7175dcf6-6780-4fdd-811a-c4a66b4af7d0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("47635693-8440-49f3-a047-eb60afb50ca3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("61a3eed0-8cea-439a-9ca2-8dedb394c7f5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fb264382-263a-45c9-9ba5-038449a6ce1b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fb65930f-2a74-4d83-b332-b54a4124c6d8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e9cdd72a-10c4-4ef7-a507-fe1db4cd3996"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4bcc32e9-14f5-4860-9323-a94c3cbd91a9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7523fc47-b8cb-4dcf-b79b-72b01947d3aa"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Notification",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("47a3ad9b-99ad-4962-9d34-b8c093d3f0ed"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("91527c24-a6f5-4111-99ba-1721466d8075"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e24693d0-e461-4266-bd74-55b897b94a36"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e3a5f7a3-19e1-4c9b-a1b0-ed0682b34f11"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("324ab43d-8540-4c5f-9b7d-cf5f1790d7b0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("73cd69ae-e0e9-48df-bf17-05f12afde66e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29b7aa63-b828-4b89-86e3-86568a5c9b8c", "1903c592-083a-4d2f-9639-baa3854b684f", "Customer", "CUSTOMER" },
                    { "5861582a-215d-4eed-b8a0-55f0cbf661bb", "d4ee3aaa-81df-497e-bbce-9dad0f3b95ce", "Employee", "EMPLOYEE" },
                    { "6cabd9d5-cb5f-499d-b217-a350987d0d31", "e693396f-d8ff-49ee-b77a-4360d38cf2f2", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b7aa63-b828-4b89-86e3-86568a5c9b8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5861582a-215d-4eed-b8a0-55f0cbf661bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cabd9d5-cb5f-499d-b217-a350987d0d31");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Feedback");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("47635693-8440-49f3-a047-eb60afb50ca3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7175dcf6-6780-4fdd-811a-c4a66b4af7d0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fb264382-263a-45c9-9ba5-038449a6ce1b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("61a3eed0-8cea-439a-9ca2-8dedb394c7f5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e9cdd72a-10c4-4ef7-a507-fe1db4cd3996"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fb65930f-2a74-4d83-b332-b54a4124c6d8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "OrderDetail",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7523fc47-b8cb-4dcf-b79b-72b01947d3aa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4bcc32e9-14f5-4860-9323-a94c3cbd91a9"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("91527c24-a6f5-4111-99ba-1721466d8075"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("47a3ad9b-99ad-4962-9d34-b8c093d3f0ed"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Feedback",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e3a5f7a3-19e1-4c9b-a1b0-ed0682b34f11"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e24693d0-e461-4266-bd74-55b897b94a36"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("73cd69ae-e0e9-48df-bf17-05f12afde66e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("324ab43d-8540-4c5f-9b7d-cf5f1790d7b0"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c5bc3e0-d531-40e4-b2af-a71e4e61eee9", "6cf476ac-08da-424c-9c72-e6cc090bf18a", "Customer", "CUSTOMER" },
                    { "f76af0dc-abf6-47bb-b071-3db83d3426a2", "b8237295-42df-4a47-965b-a67e13096782", "Manager", "MANAGER" },
                    { "fe7d129f-e08a-48dd-aa48-906e87a93b41", "99873e4c-9956-48d4-89c8-4489eb7ca058", "Employee", "EMPLOYEE" }
                });
        }
    }
}
