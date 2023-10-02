using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(9204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7bfea0f6-8e50-4bb3-a207-8a0ee8974138"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3e94927a-5aea-4cdc-8716-05a1158bfeb7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5c25997e-860b-460f-bb30-2c99da41ceee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b36c4cf2-6c28-4946-a1d3-a1471e1653c4"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(5777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1e3b83b9-c374-4446-8810-df923d723ab6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fd3fa73f-c95f-4fe1-aa1e-53071f05e6b0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(4004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ee04fca3-a89d-467d-b6bf-7d7d5ce0ac0c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("64209926-22fd-4511-be90-99f9e9ba4d84"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ba3ecfb1-7330-4785-89d6-c107b1ff1017"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("76c42825-1fb4-4201-8c6d-285f349359a1"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(6515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3e94927a-5aea-4cdc-8716-05a1158bfeb7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7bfea0f6-8e50-4bb3-a207-8a0ee8974138"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(5305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b36c4cf2-6c28-4946-a1d3-a1471e1653c4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5c25997e-860b-460f-bb30-2c99da41ceee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(4208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fd3fa73f-c95f-4fe1-aa1e-53071f05e6b0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1e3b83b9-c374-4446-8810-df923d723ab6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(3014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("64209926-22fd-4511-be90-99f9e9ba4d84"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ee04fca3-a89d-467d-b6bf-7d7d5ce0ac0c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("76c42825-1fb4-4201-8c6d-285f349359a1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ba3ecfb1-7330-4785-89d6-c107b1ff1017"));
        }
    }
}
