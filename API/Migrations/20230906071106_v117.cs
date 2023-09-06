using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v117 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 890, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3e94927a-5aea-4cdc-8716-05a1158bfeb7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b99a9763-7409-4d0f-bbb2-9d70ecc04fd5"));

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "Product",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(5305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b36c4cf2-6c28-4946-a1d3-a1471e1653c4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d2b68a38-2dd2-4f99-a4a2-5b38d820fb52"));

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(4208),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(8489));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fd3fa73f-c95f-4fe1-aa1e-53071f05e6b0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("960348a3-f3b2-4a35-995f-f50b142d89d2"));

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "Bill",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(3014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("64209926-22fd-4511-be90-99f9e9ba4d84"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3057d7d6-9f4b-4e12-b9bb-99911903f55c"));

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "Account",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("76c42825-1fb4-4201-8c6d-285f349359a1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2b6c953f-dfe3-46f8-8433-69a2476b47bc"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 890, DateTimeKind.Local).AddTicks(690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b99a9763-7409-4d0f-bbb2-9d70ecc04fd5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3e94927a-5aea-4cdc-8716-05a1158bfeb7"));

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "Product",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d2b68a38-2dd2-4f99-a4a2-5b38d820fb52"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b36c4cf2-6c28-4946-a1d3-a1471e1653c4"));

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(8489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("960348a3-f3b2-4a35-995f-f50b142d89d2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fd3fa73f-c95f-4fe1-aa1e-53071f05e6b0"));

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "Bill",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(7635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3057d7d6-9f4b-4e12-b9bb-99911903f55c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("64209926-22fd-4511-be90-99f9e9ba4d84"));

            migrationBuilder.AlterColumn<bool>(
                name: "isDelete",
                table: "Account",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 5, 22, 16, 54, 889, DateTimeKind.Local).AddTicks(5133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 6, 14, 11, 6, 531, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2b6c953f-dfe3-46f8-8433-69a2476b47bc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("76c42825-1fb4-4201-8c6d-285f349359a1"));
        }
    }
}
