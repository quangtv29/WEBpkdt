using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class sale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51c743f7-5067-468a-897b-ba21875524d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97567d17-e10e-43c1-9e34-97afdb9d0e5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3045383-4644-4263-b8eb-4aaa6c818568");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(3326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("65d9df4d-2a92-4498-b954-bd12d222ebc2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("13716fd7-b872-4918-9cc3-9ef0bd6c0d2f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("09d9b645-757c-4a26-aeeb-ee444364a3fd"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("80ab680f-0d26-4434-9dbc-74d0fa1bf0af"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(6878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("be7dd726-6abd-4d55-862d-43ec83b9ee4b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3e49c7d8-adc4-49e7-bf66-dfb69a540cea"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(3650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f658c473-3771-4e04-962c-e520cb33711f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ac72a231-c602-47b6-9084-0641b54782ca"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 320, DateTimeKind.Local).AddTicks(8424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(5823));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("23f7e97c-784a-4fae-9048-cfd49918ff5b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a841014e-fc30-48a6-8cba-153aeb0fcfae"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(2370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("13716fd7-b872-4918-9cc3-9ef0bd6c0d2f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("65d9df4d-2a92-4498-b954-bd12d222ebc2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 943, DateTimeKind.Local).AddTicks(1008),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 322, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("80ab680f-0d26-4434-9dbc-74d0fa1bf0af"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("09d9b645-757c-4a26-aeeb-ee444364a3fd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(9671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3e49c7d8-adc4-49e7-bf66-dfb69a540cea"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("be7dd726-6abd-4d55-862d-43ec83b9ee4b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(8388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 321, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ac72a231-c602-47b6-9084-0641b54782ca"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f658c473-3771-4e04-962c-e520cb33711f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 6, 11, 48, 16, 942, DateTimeKind.Local).AddTicks(5823),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 9, 17, 49, 43, 320, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a841014e-fc30-48a6-8cba-153aeb0fcfae"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("23f7e97c-784a-4fae-9048-cfd49918ff5b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51c743f7-5067-468a-897b-ba21875524d1", "5779a149-1f77-438f-89b4-c6896c414df5", "Customer", "CUSTOMER" },
                    { "97567d17-e10e-43c1-9e34-97afdb9d0e5b", "be0d61ad-3889-46fa-a921-d9ccd121f461", "Employee", "EMPLOYEE" },
                    { "f3045383-4644-4263-b8eb-4aaa6c818568", "a8accd52-ab83-43d7-8754-cb72b70a656d", "Manager", "MANAGER" }
                });
        }
    }
}
