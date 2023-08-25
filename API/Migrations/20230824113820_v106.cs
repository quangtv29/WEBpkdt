using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "ProductType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "DATEADD(hour, 7, GETUTCDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Bill",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Account");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "DATEADD(hour, 7, GETUTCDATE())");
        }
    }
}
