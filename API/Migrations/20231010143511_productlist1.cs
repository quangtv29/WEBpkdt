using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class productlist1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1078bb72-54df-4123-ab2f-42feff5bb7e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aaaeff2-ff18-4f13-9ca6-64c877fbb8b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7540f60-2076-4008-9bf9-c6f9bf5a8db7");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 295, DateTimeKind.Local).AddTicks(9181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("87d1ffc8-b10b-4fe2-b3e4-1647648e9ac2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9f108f1a-d104-4b70-8a3a-6150eefc6ff1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d5e5436f-01e7-48d7-886f-a4a096d85f4d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("de6e1a7a-4910-4c24-af7b-a3b1927380ae"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductListId",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 295, DateTimeKind.Local).AddTicks(2700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3751f91d-b742-46b9-bcc0-3b242328abc7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ab3400b2-1972-4ade-8c64-0d97c6606add"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 294, DateTimeKind.Local).AddTicks(9401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c6566a72-8c60-460a-9836-80a532487a94"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5924bbb8-18ff-4941-b17d-e3e0b3c41ad8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 294, DateTimeKind.Local).AddTicks(5876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(219));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1520b5cd-5aec-4c5c-b809-c07b30584bbc"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dbbc9a3f-056e-4b7a-80ce-638a908c404c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 293, DateTimeKind.Local).AddTicks(430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 998, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b263cdb4-cbe5-42db-a6d6-7b9fe8cdee3d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e2225d6b-fd32-4f1a-bc68-7f02bbfd0974"));

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("ae069d6d-10d6-4599-854a-6732b5be8a2c")),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "384cb82d-f04d-4714-9580-1a4dbc047190", "cdbda0f8-f4aa-4ca9-bedb-2273583a6f5b", "Customer", "CUSTOMER" },
                    { "3df1645e-23a1-485d-b869-d110dd7cc4bd", "fe651d6b-2089-4920-84fe-3a0dba9e8cf2", "Manager", "MANAGER" },
                    { "5a9d9ad5-3647-4131-9d4f-12d7c2a6324a", "a702e003-0ba0-44a3-bc13-93531712aa4e", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductListId",
                table: "ProductType",
                column: "ProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_ProductList_ProductListId",
                table: "ProductType",
                column: "ProductListId",
                principalTable: "ProductList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_ProductList_ProductListId",
                table: "ProductType");

            migrationBuilder.DropTable(
                name: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_ProductListId",
                table: "ProductType");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "384cb82d-f04d-4714-9580-1a4dbc047190");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3df1645e-23a1-485d-b869-d110dd7cc4bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a9d9ad5-3647-4131-9d4f-12d7c2a6324a");

            migrationBuilder.DropColumn(
                name: "ProductListId",
                table: "ProductType");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 295, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9f108f1a-d104-4b70-8a3a-6150eefc6ff1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("87d1ffc8-b10b-4fe2-b3e4-1647648e9ac2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(3782),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("de6e1a7a-4910-4c24-af7b-a3b1927380ae"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d5e5436f-01e7-48d7-886f-a4a096d85f4d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(2713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 295, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ab3400b2-1972-4ade-8c64-0d97c6606add"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3751f91d-b742-46b9-bcc0-3b242328abc7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(1580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 294, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5924bbb8-18ff-4941-b17d-e3e0b3c41ad8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c6566a72-8c60-460a-9836-80a532487a94"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Bill",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 999, DateTimeKind.Local).AddTicks(219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 294, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dbbc9a3f-056e-4b7a-80ce-638a908c404c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1520b5cd-5aec-4c5c-b809-c07b30584bbc"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModificationTime",
                table: "Account",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 10, 10, 15, 33, 55, 998, DateTimeKind.Local).AddTicks(7163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 10, 10, 21, 35, 11, 293, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e2225d6b-fd32-4f1a-bc68-7f02bbfd0974"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b263cdb4-cbe5-42db-a6d6-7b9fe8cdee3d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1078bb72-54df-4123-ab2f-42feff5bb7e8", "6606e3a9-97a2-40c0-a4a4-923f98548c1c", "Customer", "CUSTOMER" },
                    { "4aaaeff2-ff18-4f13-9ca6-64c877fbb8b3", "02c52c43-e171-4ca2-8412-8857d878a87d", "Employee", "EMPLOYEE" },
                    { "f7540f60-2076-4008-9bf9-c6f9bf5a8db7", "7088ea7e-de8d-4688-8b2c-0d4c07cd075e", "Manager", "MANAGER" }
                });
        }
    }
}
