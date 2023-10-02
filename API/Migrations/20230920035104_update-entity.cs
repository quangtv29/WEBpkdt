using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class updateentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 626, DateTimeKind.Local).AddTicks(878),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("52f236f4-ce54-48c7-b93b-69c63dc33625"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("883f78f8-18d9-482c-b5a7-3bf930b45c10"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(9661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(3614));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b7f76c65-eb06-4980-97e2-fd612fc477a2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("63ba663c-218c-4085-9972-7b4bd12dffb8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(8319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cfd1b14c-d1a3-4c15-9015-76a029e08e2f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5da0d3ce-50d4-4c93-a207-9c8fade02811"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(7035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("96c51d81-7432-416a-9d5c-82f96644b2f3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4073d4d7-c40b-48b3-bd12-651e04bea4d5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(4002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 92, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f9edf927-519e-4d22-96df-97342e49b24c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4ab5e92d-371a-4cb6-b2e8-a80e0ee1738f"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(4796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 626, DateTimeKind.Local).AddTicks(878));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("883f78f8-18d9-482c-b5a7-3bf930b45c10"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("52f236f4-ce54-48c7-b93b-69c63dc33625"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(3614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("63ba663c-218c-4085-9972-7b4bd12dffb8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b7f76c65-eb06-4980-97e2-fd612fc477a2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(2486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5da0d3ce-50d4-4c93-a207-9c8fade02811"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cfd1b14c-d1a3-4c15-9015-76a029e08e2f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 93, DateTimeKind.Local).AddTicks(1228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4073d4d7-c40b-48b3-bd12-651e04bea4d5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("96c51d81-7432-416a-9d5c-82f96644b2f3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 59, 7, 92, DateTimeKind.Local).AddTicks(8569),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 20, 10, 51, 4, 625, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4ab5e92d-371a-4cb6-b2e8-a80e0ee1738f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f9edf927-519e-4d22-96df-97342e49b24c"));

            migrationBuilder.CreateTable(
                name: "Test1",
                columns: table => new
                {
                    Test1ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1", x => x.Test1ID);
                });

            migrationBuilder.CreateTable(
                name: "Test2",
                columns: table => new
                {
                    Test2ID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test2", x => x.Test2ID);
                    table.ForeignKey(
                        name: "FK_Test2_Test1_Test2ID",
                        column: x => x.Test2ID,
                        principalTable: "Test1",
                        principalColumn: "Test1ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
