using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c807ca-acbb-403b-adf1-9bf6b5b4c876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "827656fa-d6f4-4018-baa3-3cad477d674e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afc562b4-50cd-4329-b56e-6985257764f9");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("10a61cca-bda6-40eb-b51b-e3148d196e8e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ff6ef95b-2cea-4012-9930-ce0455f51fdb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0d4e26c8-826f-420e-b292-2a786ddcc80b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f0d33bcc-317a-401d-b447-8dd515310720"));

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cbe2bee0-1fbf-400d-bf44-fa15d5a39a98"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00e010f7-328c-4a2a-bd99-5800d602a52d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8acf6758-d7ff-4f47-a013-00760680072c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8f336c67-1b08-4bfc-9db8-f8a9dc96bb07"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ad2bb85b-7351-460b-9a01-eb79ae12aefc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c27fdd51-79cd-462f-ae5a-9ad5d6a8ac75"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a536d8af-aad0-490f-a13e-0da311108227"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("52d4fc15-9cac-40d5-b6a1-db227503fa5f"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new Guid("ff6ef95b-2cea-4012-9930-ce0455f51fdb"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("10a61cca-bda6-40eb-b51b-e3148d196e8e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f0d33bcc-317a-401d-b447-8dd515310720"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0d4e26c8-826f-420e-b292-2a786ddcc80b"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Image",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00e010f7-328c-4a2a-bd99-5800d602a52d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cbe2bee0-1fbf-400d-bf44-fa15d5a39a98"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8f336c67-1b08-4bfc-9db8-f8a9dc96bb07"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8acf6758-d7ff-4f47-a013-00760680072c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c27fdd51-79cd-462f-ae5a-9ad5d6a8ac75"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ad2bb85b-7351-460b-9a01-eb79ae12aefc"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("52d4fc15-9cac-40d5-b6a1-db227503fa5f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a536d8af-aad0-490f-a13e-0da311108227"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32c807ca-acbb-403b-adf1-9bf6b5b4c876", "0c110361-3ff2-495d-9936-0143d96bbc53", "Customer", "CUSTOMER" },
                    { "827656fa-d6f4-4018-baa3-3cad477d674e", "f0c2810e-224e-4a25-bf00-559273aac38e", "Manager", "MANAGER" },
                    { "afc562b4-50cd-4329-b56e-6985257764f9", "43dad1ae-6569-4ebc-8d51-ae66c0d86161", "Employee", "EMPLOYEE" }
                });
        }
    }
}
