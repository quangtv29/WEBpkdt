using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class test123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Test1",
                newName: "Test1ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(4796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 486, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("883f78f8-18d9-482c-b5a7-3bf930b45c10"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bce92cba-e046-4ace-af6c-7d27d46467a2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(3614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("63ba663c-218c-4085-9972-7b4bd12dffb8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3aa60172-b0d8-4cf3-9a24-1bceb9cdf952"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(2486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5da0d3ce-50d4-4c93-a207-9c8fade02811"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4690b068-d255-46cc-94bc-10c001fb296f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(1228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4073d4d7-c40b-48b3-bd12-651e04bea4d5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b248c65d-c5a9-4281-829b-a82ebd6a2496"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 92, DateTimeKind.Local).AddTicks(8569),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4ab5e92d-371a-4cb6-b2e8-a80e0ee1738f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("62919d6e-ac81-4821-894b-fb2eaa6a6576"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test1ID",
                table: "Test1",
                newName: "ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 486, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bce92cba-e046-4ace-af6c-7d27d46467a2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("883f78f8-18d9-482c-b5a7-3bf930b45c10"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(9009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3aa60172-b0d8-4cf3-9a24-1bceb9cdf952"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("63ba663c-218c-4085-9972-7b4bd12dffb8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(7829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4690b068-d255-46cc-94bc-10c001fb296f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5da0d3ce-50d4-4c93-a207-9c8fade02811"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(6581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b248c65d-c5a9-4281-829b-a82ebd6a2496"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4073d4d7-c40b-48b3-bd12-651e04bea4d5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(3798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 92, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("62919d6e-ac81-4821-894b-fb2eaa6a6576"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4ab5e92d-371a-4cb6-b2e8-a80e0ee1738f"));
        }
    }
}
