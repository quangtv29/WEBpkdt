using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c1ce0ca-2532-4d60-9514-3c04753b3a55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d3edca-eb18-415b-8a30-5b4af90077ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c98c8a-f7e6-48ef-9441-0938c96f2648");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("51c3d228-2ec3-4e78-a305-3285eb06fced"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("48584d68-fd06-42b7-af7a-8963cd43052b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3db4697b-bc23-43cd-9af2-47eac79794fb"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a678b8d9-d3fe-4391-bc21-6db14a6d225a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("37e82429-2f92-430f-85a3-3eec016c9008"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0a44e688-640b-433d-adc9-c94e9c4ee117"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("303664e9-a002-470b-be8a-8cf4345ab7e5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cc602e0f-5e88-441b-9a3f-b539265c4a23"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4ceb4275-8dee-4bea-8274-04d48e51f031"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9304e30e-d230-43cf-8058-70073f50812a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1c5e3393-7e87-40bd-8e9c-099ab44a1762"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("090a6382-9b97-414f-a8fd-858c9b9f0ac8"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LimitReset",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38379c14-4765-49e2-b448-d907f2c59694", "dcc8fbca-4794-43c7-ab10-589a7657be3a", "Customer", "CUSTOMER" },
                    { "b99ab5a1-cf39-46dc-85a8-4a826e787490", "767edcf3-8237-4fbb-93a0-d296a0e1a151", "Manager", "MANAGER" },
                    { "fa10d331-f09f-4648-8f85-93ea91d2159d", "6ee2b288-390c-406e-a32d-4d5ea289a931", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38379c14-4765-49e2-b448-d907f2c59694");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b99ab5a1-cf39-46dc-85a8-4a826e787490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa10d331-f09f-4648-8f85-93ea91d2159d");

            migrationBuilder.DropColumn(
                name: "LimitReset",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("48584d68-fd06-42b7-af7a-8963cd43052b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("51c3d228-2ec3-4e78-a305-3285eb06fced"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a678b8d9-d3fe-4391-bc21-6db14a6d225a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3db4697b-bc23-43cd-9af2-47eac79794fb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0a44e688-640b-433d-adc9-c94e9c4ee117"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("37e82429-2f92-430f-85a3-3eec016c9008"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cc602e0f-5e88-441b-9a3f-b539265c4a23"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("303664e9-a002-470b-be8a-8cf4345ab7e5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9304e30e-d230-43cf-8058-70073f50812a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4ceb4275-8dee-4bea-8274-04d48e51f031"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("090a6382-9b97-414f-a8fd-858c9b9f0ac8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1c5e3393-7e87-40bd-8e9c-099ab44a1762"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c1ce0ca-2532-4d60-9514-3c04753b3a55", "01a6fb82-8f8b-4c90-a2b4-4a0652cee2ea", "Employee", "EMPLOYEE" },
                    { "b4d3edca-eb18-415b-8a30-5b4af90077ed", "6cbc1a00-55cf-434d-aba9-7d5bac9672ca", "Manager", "MANAGER" },
                    { "c9c98c8a-f7e6-48ef-9441-0938c96f2648", "f4d33eaf-287c-4512-bf85-13a871527f89", "Customer", "CUSTOMER" }
                });
        }
    }
}
