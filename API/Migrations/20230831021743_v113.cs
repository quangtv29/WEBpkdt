using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v113 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "ProductType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "OrderDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6902f9b5-8b72-425c-ac24-aed2e82e60fe"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1947c256-1b0d-4a2a-8f4c-6fb3221aa542"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "Customer",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "Bill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "Account",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modification",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Modification",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Bill");

            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Account");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1947c256-1b0d-4a2a-8f4c-6fb3221aa542"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6902f9b5-8b72-425c-ac24-aed2e82e60fe"));
        }
    }
}
