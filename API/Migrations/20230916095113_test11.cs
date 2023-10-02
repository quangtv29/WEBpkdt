using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class test11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(5509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5100d197-5d6b-44de-b278-3daa7c16e780"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7bfea0f6-8e50-4bb3-a207-8a0ee8974138"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(2357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("84468352-70d5-4b3a-ae61-07113016fed2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5c25997e-860b-460f-bb30-2c99da41ceee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(7276),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8bb7edd7-cc39-430c-ae9a-37fb5ce48a1b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1e3b83b9-c374-4446-8810-df923d723ab6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(1582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("162ef7d0-a8fa-45f1-af9a-c8405c70c857"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ee04fca3-a89d-467d-b6bf-7d7d5ce0ac0c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 780, DateTimeKind.Local).AddTicks(4068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a6918de1-1caa-4de5-b6d9-bdc5b774a7c4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ba3ecfb1-7330-4785-89d6-c107b1ff1017"));

            migrationBuilder.CreateTable(
                name: "Test1",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Test2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Test2_Test1_ID",
                        column: x => x.ID,
                        principalTable: "Test1",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test2");

            migrationBuilder.DropTable(
                name: "Test1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(9204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7bfea0f6-8e50-4bb3-a207-8a0ee8974138"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5100d197-5d6b-44de-b278-3daa7c16e780"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5c25997e-860b-460f-bb30-2c99da41ceee"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("84468352-70d5-4b3a-ae61-07113016fed2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(5777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1e3b83b9-c374-4446-8810-df923d723ab6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8bb7edd7-cc39-430c-ae9a-37fb5ce48a1b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(4004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ee04fca3-a89d-467d-b6bf-7d7d5ce0ac0c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("162ef7d0-a8fa-45f1-af9a-c8405c70c857"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 39, 31, 176, DateTimeKind.Local).AddTicks(350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 780, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ba3ecfb1-7330-4785-89d6-c107b1ff1017"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a6918de1-1caa-4de5-b6d9-bdc5b774a7c4"));
        }
    }
}
