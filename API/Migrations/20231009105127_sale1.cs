using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class sale1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b32ef8e-607b-4785-8ed9-3ff82d2ed568");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7073234c-7b7c-4ddd-a2e8-255179707a91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b55e0318-15b0-46c3-9582-aef253e21cf8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 762, DateTimeKind.Local).AddTicks(2712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9b2d3674-dacb-4652-826b-a193d3df4622"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("65d9df4d-2a92-4498-b954-bd12d222ebc2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(9454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("077328ea-360f-4dea-aedb-ec633b35a571"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("09d9b645-757c-4a26-aeeb-ee444364a3fd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(6400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("67d67fd5-041d-4e44-b385-798f4c523971"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("be7dd726-6abd-4d55-862d-43ec83b9ee4b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(3268),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d2a8e7fb-4785-4960-be6a-fc3f6584d7dc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f658c473-3771-4e04-962c-e520cb33711f"));

            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 760, DateTimeKind.Local).AddTicks(7131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 320, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ac722b78-da25-4129-bc17-e7a3db176f82"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("23f7e97c-784a-4fae-9048-cfd49918ff5b"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Bill");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(3326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 762, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("65d9df4d-2a92-4498-b954-bd12d222ebc2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9b2d3674-dacb-4652-826b-a193d3df4622"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("09d9b645-757c-4a26-aeeb-ee444364a3fd"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("077328ea-360f-4dea-aedb-ec633b35a571"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(6878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("be7dd726-6abd-4d55-862d-43ec83b9ee4b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("67d67fd5-041d-4e44-b385-798f4c523971"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(3650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 761, DateTimeKind.Local).AddTicks(3268));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f658c473-3771-4e04-962c-e520cb33711f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d2a8e7fb-4785-4960-be6a-fc3f6584d7dc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 320, DateTimeKind.Local).AddTicks(8424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 51, 26, 760, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("23f7e97c-784a-4fae-9048-cfd49918ff5b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ac722b78-da25-4129-bc17-e7a3db176f82"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b32ef8e-607b-4785-8ed9-3ff82d2ed568", "1c23b111-f81a-489d-acbb-e6d7f5bf5a19", "Employee", "EMPLOYEE" },
                    { "7073234c-7b7c-4ddd-a2e8-255179707a91", "409a460b-0583-4502-a8ee-ac7dd6c4cc7b", "Manager", "MANAGER" },
                    { "b55e0318-15b0-46c3-9582-aef253e21cf8", "5d00f7e8-7601-47f6-87ed-d209c6c370b2", "Customer", "CUSTOMER" }
                });
        }
    }
}
