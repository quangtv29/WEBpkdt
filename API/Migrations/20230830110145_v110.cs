using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSave",
                table: "Bill");

            migrationBuilder.AddColumn<bool>(
                name: "isSave",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1947c256-1b0d-4a2a-8f4c-6fb3221aa542"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9d7b4625-561c-4848-9d0d-6c8f06137533"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSave",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9d7b4625-561c-4848-9d0d-6c8f06137533"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1947c256-1b0d-4a2a-8f4c-6fb3221aa542"));

            migrationBuilder.AddColumn<bool>(
                name: "isSave",
                table: "Bill",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
