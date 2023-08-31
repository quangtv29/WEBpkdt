using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9d7b4625-561c-4848-9d0d-6c8f06137533"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dd9d3577-decb-432d-9927-c6bcafcbe921"));

            migrationBuilder.AddColumn<bool>(
                name: "isSave",
                table: "Bill",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSave",
                table: "Bill");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dd9d3577-decb-432d-9927-c6bcafcbe921"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9d7b4625-561c-4848-9d0d-6c8f06137533"));
        }
    }
}
