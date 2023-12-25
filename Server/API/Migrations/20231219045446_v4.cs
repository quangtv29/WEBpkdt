using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78e5bea9-f458-474d-a95a-16634f506799");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc19bc3-b458-4d7a-8582-a2c7f918bb68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de7376fb-e932-41b8-b393-cdc0d9009614");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9ac0c1a1-3b1f-4471-962d-7c961524cf66"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("acf29619-eaf9-44f1-9e2b-92ad6d4ef38a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c997549e-5b61-4977-b403-a97eb5dce4ab"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("710468e8-f4d0-437b-a9f3-9ab0042bc404"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4146a5c0-9a8b-45bf-93e7-c918329bf15d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2c323540-a375-4ca9-98b3-bad9b9035dc1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("86c23bc2-0681-40a2-88fd-1208a3249dd8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cf62c347-e5eb-49af-ae03-db22836b4739"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7597fd3d-a9ec-4bf4-a3db-04595c87c59b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2d7b91ec-cf22-4025-9a73-db76d47a46a2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7adf037a-d6bc-4c13-a120-f3327e888005"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("171dfbe2-7a54-41e6-944c-6c007dfb15c8"));

            migrationBuilder.AddColumn<bool>(
                name: "isShow",
                table: "Feedback",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("811c2392-09cb-43c5-b6aa-3efa1499c7e4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d01040f3-6bc2-4a69-b897-96feb2c4d47a"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "isShow",
                table: "Feedback");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("acf29619-eaf9-44f1-9e2b-92ad6d4ef38a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9ac0c1a1-3b1f-4471-962d-7c961524cf66"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("710468e8-f4d0-437b-a9f3-9ab0042bc404"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c997549e-5b61-4977-b403-a97eb5dce4ab"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2c323540-a375-4ca9-98b3-bad9b9035dc1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4146a5c0-9a8b-45bf-93e7-c918329bf15d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cf62c347-e5eb-49af-ae03-db22836b4739"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("86c23bc2-0681-40a2-88fd-1208a3249dd8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2d7b91ec-cf22-4025-9a73-db76d47a46a2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7597fd3d-a9ec-4bf4-a3db-04595c87c59b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("171dfbe2-7a54-41e6-944c-6c007dfb15c8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7adf037a-d6bc-4c13-a120-f3327e888005"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d01040f3-6bc2-4a69-b897-96feb2c4d47a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("811c2392-09cb-43c5-b6aa-3efa1499c7e4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78e5bea9-f458-474d-a95a-16634f506799", "72c914ae-1c21-4ddc-ba64-28cae7085338", "Manager", "MANAGER" },
                    { "8cc19bc3-b458-4d7a-8582-a2c7f918bb68", "3cef161e-537c-456d-b0e6-df95a4d17b96", "Customer", "CUSTOMER" },
                    { "de7376fb-e932-41b8-b393-cdc0d9009614", "d16ac787-a3e6-4d45-9b60-26edeee17f5c", "Employee", "EMPLOYEE" }
                });
        }
    }
}
