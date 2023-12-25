using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88c69f79-57d7-42d2-b9b2-b9e600e704fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a47def8-0145-4345-a96d-37d44acd1f8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6864e27-6874-446d-a46d-6ebddf5dac2e");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("47635693-8440-49f3-a047-eb60afb50ca3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9ac0c1a1-3b1f-4471-962d-7c961524cf66"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fb264382-263a-45c9-9ba5-038449a6ce1b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c997549e-5b61-4977-b403-a97eb5dce4ab"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e9cdd72a-10c4-4ef7-a507-fe1db4cd3996"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4146a5c0-9a8b-45bf-93e7-c918329bf15d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7523fc47-b8cb-4dcf-b79b-72b01947d3aa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("86c23bc2-0681-40a2-88fd-1208a3249dd8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("91527c24-a6f5-4111-99ba-1721466d8075"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7597fd3d-a9ec-4bf4-a3db-04595c87c59b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e3a5f7a3-19e1-4c9b-a1b0-ed0682b34f11"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7adf037a-d6bc-4c13-a120-f3327e888005"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("73cd69ae-e0e9-48df-bf17-05f12afde66e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("811c2392-09cb-43c5-b6aa-3efa1499c7e4"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingDate",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "Bill");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9ac0c1a1-3b1f-4471-962d-7c961524cf66"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("47635693-8440-49f3-a047-eb60afb50ca3"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c997549e-5b61-4977-b403-a97eb5dce4ab"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fb264382-263a-45c9-9ba5-038449a6ce1b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4146a5c0-9a8b-45bf-93e7-c918329bf15d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e9cdd72a-10c4-4ef7-a507-fe1db4cd3996"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("86c23bc2-0681-40a2-88fd-1208a3249dd8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7523fc47-b8cb-4dcf-b79b-72b01947d3aa"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7597fd3d-a9ec-4bf4-a3db-04595c87c59b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("91527c24-a6f5-4111-99ba-1721466d8075"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7adf037a-d6bc-4c13-a120-f3327e888005"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e3a5f7a3-19e1-4c9b-a1b0-ed0682b34f11"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("811c2392-09cb-43c5-b6aa-3efa1499c7e4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("73cd69ae-e0e9-48df-bf17-05f12afde66e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88c69f79-57d7-42d2-b9b2-b9e600e704fe", "4b91c993-4979-4aa5-876b-63e334cf51b4", "Employee", "EMPLOYEE" },
                    { "8a47def8-0145-4345-a96d-37d44acd1f8e", "97eb6641-de0e-4e79-8cd9-0407765ad3be", "Manager", "MANAGER" },
                    { "d6864e27-6874-446d-a46d-6ebddf5dac2e", "49e3d518-2ec8-44de-8c9b-a041adaeb278", "Customer", "CUSTOMER" }
                });
        }
    }
}
