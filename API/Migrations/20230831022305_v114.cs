using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v114 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "ProductType",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "OrderDetail",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Customer",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Bill",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Account",
                newName: "LastModificationTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 9, 23, 4, 849, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f72a32e5-8979-4d24-821f-3f19fce43a28"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6902f9b5-8b72-425c-ac24-aed2e82e60fe"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "ProductType",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "OrderDetail",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Customer",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Bill",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "Account",
                newName: "Modification");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "Product",
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
                oldDefaultValue: new Guid("f72a32e5-8979-4d24-821f-3f19fce43a28"));
        }
    }
}
