using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "047527a5-e7cf-47fb-95ba-db7ac083063b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58346c7e-fd0b-459b-8597-55f107d2efe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6163d6f4-c6b3-4429-8a9f-9f8a55bbe5d6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5bc451a-281d-4bcd-bde5-cac2d09df773", "db2ef474-d30b-490f-a98c-15a3347b2ab9" });

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("acf29619-eaf9-44f1-9e2b-92ad6d4ef38a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("28fb2eb4-465d-46ba-8215-16ddfa0e0dad"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("710468e8-f4d0-437b-a9f3-9ab0042bc404"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cfcfcad6-879d-4bc8-8986-9e1d7cc31bd0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2c323540-a375-4ca9-98b3-bad9b9035dc1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5d572926-c68c-4025-8da9-17b7c70755b9"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cf62c347-e5eb-49af-ae03-db22836b4739"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f3796e39-dc06-41e1-b329-097088265c58"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2d7b91ec-cf22-4025-9a73-db76d47a46a2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9dcf7fb7-b419-403a-ac0d-40a503a771ea"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("171dfbe2-7a54-41e6-944c-6c007dfb15c8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("958cefcc-2100-4cb9-abf0-00fd98170add"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d01040f3-6bc2-4a69-b897-96feb2c4d47a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("99e93d6b-862d-46a6-9556-2ecf28f3a79d"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new Guid("28fb2eb4-465d-46ba-8215-16ddfa0e0dad"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("acf29619-eaf9-44f1-9e2b-92ad6d4ef38a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cfcfcad6-879d-4bc8-8986-9e1d7cc31bd0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("710468e8-f4d0-437b-a9f3-9ab0042bc404"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5d572926-c68c-4025-8da9-17b7c70755b9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2c323540-a375-4ca9-98b3-bad9b9035dc1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f3796e39-dc06-41e1-b329-097088265c58"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cf62c347-e5eb-49af-ae03-db22836b4739"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9dcf7fb7-b419-403a-ac0d-40a503a771ea"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2d7b91ec-cf22-4025-9a73-db76d47a46a2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("958cefcc-2100-4cb9-abf0-00fd98170add"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("171dfbe2-7a54-41e6-944c-6c007dfb15c8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("99e93d6b-862d-46a6-9556-2ecf28f3a79d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d01040f3-6bc2-4a69-b897-96feb2c4d47a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "047527a5-e7cf-47fb-95ba-db7ac083063b", "d5fb2722-b223-42a8-948a-6bd982fdbda1", "Manager", "MANAGER" },
                    { "58346c7e-fd0b-459b-8597-55f107d2efe8", "7a6bab39-d264-4be9-97f8-807aa04b6882", "Employee", "EMPLOYEE" },
                    { "6163d6f4-c6b3-4429-8a9f-9f8a55bbe5d6", "ac8402f1-7318-42c0-8e2a-580b5d4c55f5", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a5bc451a-281d-4bcd-bde5-cac2d09df773", "db2ef474-d30b-490f-a98c-15a3347b2ab9" });
        }
    }
}
