using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "072701e4-d292-47f8-a9fa-2c6a9d4e14ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f1c820d-0bbb-469f-be25-43ed07b9796c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6c06e1b-1d2f-4b3b-bdce-09e5f8499793");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("48584d68-fd06-42b7-af7a-8963cd43052b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("10a61cca-bda6-40eb-b51b-e3148d196e8e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a678b8d9-d3fe-4391-bc21-6db14a6d225a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d4e26c8-826f-420e-b292-2a786ddcc80b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0a44e688-640b-433d-adc9-c94e9c4ee117"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cbe2bee0-1fbf-400d-bf44-fa15d5a39a98"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cc602e0f-5e88-441b-9a3f-b539265c4a23"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8acf6758-d7ff-4f47-a013-00760680072c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9304e30e-d230-43cf-8058-70073f50812a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ad2bb85b-7351-460b-9a01-eb79ae12aefc"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("090a6382-9b97-414f-a8fd-858c9b9f0ac8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a536d8af-aad0-490f-a13e-0da311108227"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAccount",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreateAccount",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("10a61cca-bda6-40eb-b51b-e3148d196e8e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("48584d68-fd06-42b7-af7a-8963cd43052b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d4e26c8-826f-420e-b292-2a786ddcc80b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a678b8d9-d3fe-4391-bc21-6db14a6d225a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cbe2bee0-1fbf-400d-bf44-fa15d5a39a98"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0a44e688-640b-433d-adc9-c94e9c4ee117"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8acf6758-d7ff-4f47-a013-00760680072c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cc602e0f-5e88-441b-9a3f-b539265c4a23"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ad2bb85b-7351-460b-9a01-eb79ae12aefc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9304e30e-d230-43cf-8058-70073f50812a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a536d8af-aad0-490f-a13e-0da311108227"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("090a6382-9b97-414f-a8fd-858c9b9f0ac8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "072701e4-d292-47f8-a9fa-2c6a9d4e14ef", "b1927570-c3e7-482d-a56e-c75940ba2252", "Customer", "CUSTOMER" },
                    { "1f1c820d-0bbb-469f-be25-43ed07b9796c", "7dd5044e-9c07-486b-b031-c3a92f80efa9", "Employee", "EMPLOYEE" },
                    { "c6c06e1b-1d2f-4b3b-bdce-09e5f8499793", "1fb2394d-3713-46d9-9dfd-5e2379955aae", "Manager", "MANAGER" }
                });
        }
    }
}
