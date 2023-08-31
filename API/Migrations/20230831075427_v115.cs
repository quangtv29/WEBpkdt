using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v115 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(2130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(1717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 31, 9, 23, 4, 849, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2891cdd2-143c-4e7e-a368-37e8ffb48373"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f72a32e5-8979-4d24-821f-3f19fce43a28"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(22),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 541, DateTimeKind.Local).AddTicks(7828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(2130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 31, 9, 23, 4, 849, DateTimeKind.Local).AddTicks(7600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f72a32e5-8979-4d24-821f-3f19fce43a28"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2891cdd2-143c-4e7e-a368-37e8ffb48373"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 542, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 31, 14, 54, 27, 541, DateTimeKind.Local).AddTicks(7828));
        }
    }
}
