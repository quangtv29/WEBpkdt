using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class test12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test2_Test1_ID",
                table: "Test2");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Test2",
                newName: "Test2ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 486, DateTimeKind.Local).AddTicks(285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("bce92cba-e046-4ace-af6c-7d27d46467a2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5100d197-5d6b-44de-b278-3daa7c16e780"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(9009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3aa60172-b0d8-4cf3-9a24-1bceb9cdf952"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("84468352-70d5-4b3a-ae61-07113016fed2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(7829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4690b068-d255-46cc-94bc-10c001fb296f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8bb7edd7-cc39-430c-ae9a-37fb5ce48a1b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(6581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b248c65d-c5a9-4281-829b-a82ebd6a2496"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("162ef7d0-a8fa-45f1-af9a-c8405c70c857"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(3798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 780, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("62919d6e-ac81-4821-894b-fb2eaa6a6576"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a6918de1-1caa-4de5-b6d9-bdc5b774a7c4"));

            migrationBuilder.AddForeignKey(
                name: "FK_Test2_Test1_Test2ID",
                table: "Test2",
                column: "Test2ID",
                principalTable: "Test1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test2_Test1_Test2ID",
                table: "Test2");

            migrationBuilder.RenameColumn(
                name: "Test2ID",
                table: "Test2",
                newName: "ID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(5509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 486, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5100d197-5d6b-44de-b278-3daa7c16e780"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("bce92cba-e046-4ace-af6c-7d27d46467a2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 782, DateTimeKind.Local).AddTicks(2357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("84468352-70d5-4b3a-ae61-07113016fed2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3aa60172-b0d8-4cf3-9a24-1bceb9cdf952"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(7276),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8bb7edd7-cc39-430c-ae9a-37fb5ce48a1b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4690b068-d255-46cc-94bc-10c001fb296f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 781, DateTimeKind.Local).AddTicks(1582),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("162ef7d0-a8fa-45f1-af9a-c8405c70c857"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b248c65d-c5a9-4281-829b-a82ebd6a2496"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 9, 16, 16, 51, 12, 780, DateTimeKind.Local).AddTicks(4068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 9, 16, 16, 53, 34, 485, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a6918de1-1caa-4de5-b6d9-bdc5b774a7c4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("62919d6e-ac81-4821-894b-fb2eaa6a6576"));

            migrationBuilder.AddForeignKey(
                name: "FK_Test2_Test1_ID",
                table: "Test2",
                column: "ID",
                principalTable: "Test1",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
