using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class sale2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f255d2e-a82c-4f21-8095-b8f4a3f218f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ffbb5ac-9fc6-4e1e-804c-05785b9876fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c669f94-7aa9-4851-8b5a-1075503fff87");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 390, DateTimeKind.Local).AddTicks(1942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 762, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7448d147-cb37-4eb7-bfeb-74b9f67e9d41"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9b2d3674-dacb-4652-826b-a193d3df4622"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(9263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("56e20107-8638-4908-a691-8d25723c6257"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("077328ea-360f-4dea-aedb-ec633b35a571"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(6751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ab403421-1b5a-43cb-89b5-23a2305fe731"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("67d67fd5-041d-4e44-b385-798f4c523971"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(2260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(3268));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5025bdc7-d4fd-4e9c-b435-8d37d2e7b039"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d2a8e7fb-4785-4960-be6a-fc3f6584d7dc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 388, DateTimeKind.Local).AddTicks(4133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 760, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e9cf25a6-bbf0-414d-be8a-5cdd7bae672b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ac722b78-da25-4129-bc17-e7a3db176f82"));

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Money = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<int>(type: "int", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80e644e2-fb78-4b89-868d-be38066495c3", "f889d848-b257-4328-9c1c-66e8e824f5b7", "Customer", "CUSTOMER" },
                    { "8cac9c1b-c09f-422a-b08f-4782aa6e17a5", "f9c7f0a7-fab7-4c7f-bd6e-2487c85aef68", "Employee", "EMPLOYEE" },
                    { "f9d54c42-dfe4-4264-941f-87e7aca875e2", "8d2f47b0-d1b8-4a6a-9177-813eb5084087", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80e644e2-fb78-4b89-868d-be38066495c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cac9c1b-c09f-422a-b08f-4782aa6e17a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9d54c42-dfe4-4264-941f-87e7aca875e2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 762, DateTimeKind.Local).AddTicks(2712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 390, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9b2d3674-dacb-4652-826b-a193d3df4622"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7448d147-cb37-4eb7-bfeb-74b9f67e9d41"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(9454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("077328ea-360f-4dea-aedb-ec633b35a571"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("56e20107-8638-4908-a691-8d25723c6257"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(6400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("67d67fd5-041d-4e44-b385-798f4c523971"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ab403421-1b5a-43cb-89b5-23a2305fe731"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(3268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 389, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d2a8e7fb-4785-4960-be6a-fc3f6584d7dc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5025bdc7-d4fd-4e9c-b435-8d37d2e7b039"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 760, DateTimeKind.Local).AddTicks(7131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 18, 2, 15, 388, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ac722b78-da25-4129-bc17-e7a3db176f82"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e9cf25a6-bbf0-414d-be8a-5cdd7bae672b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f255d2e-a82c-4f21-8095-b8f4a3f218f3", "c315bc1d-9805-4ffd-adc4-660b113bf44a", "Employee", "EMPLOYEE" },
                    { "1ffbb5ac-9fc6-4e1e-804c-05785b9876fc", "35051e2e-ca03-4348-81a1-55c45da223d0", "Customer", "CUSTOMER" },
                    { "4c669f94-7aa9-4851-8b5a-1075503fff87", "b3a9ce39-f109-4505-8d61-1a5513024e40", "Manager", "MANAGER" }
                });
        }
    }
}
