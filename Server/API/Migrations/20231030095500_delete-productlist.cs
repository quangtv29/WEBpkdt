using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class deleteproductlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "0e1e2478-ac2b-4491-bde0-29ff31120ec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32dfac1f-8467-4c55-8b7c-6fda9369891e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85136479-21de-4ff9-a779-fdb9654b24f2");

            migrationBuilder.DropColumn(
                name: "ProductListId",
                table: "ProductType");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ff6ef95b-2cea-4012-9930-ce0455f51fdb"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("19e01031-6def-47a6-b3ec-4b2c67615426"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f0d33bcc-317a-401d-b447-8dd515310720"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c3a29ab6-b1eb-4e1f-9810-ddee90c889c0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00e010f7-328c-4a2a-bd99-5800d602a52d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8b63c989-9304-432b-9ff2-dbbcd6324c49"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8f336c67-1b08-4bfc-9db8-f8a9dc96bb07"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ebcea88e-5479-472b-b51a-c236bf91313d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c27fdd51-79cd-462f-ae5a-9ad5d6a8ac75"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("20b2cd51-ea67-4073-866c-3c41a6505778"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("52d4fc15-9cac-40d5-b6a1-db227503fa5f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4128a167-b10b-415c-ade6-317bf73a85b8"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32c807ca-acbb-403b-adf1-9bf6b5b4c876", "0c110361-3ff2-495d-9936-0143d96bbc53", "Customer", "CUSTOMER" },
                    { "827656fa-d6f4-4018-baa3-3cad477d674e", "f0c2810e-224e-4a25-bf00-559273aac38e", "Manager", "MANAGER" },
                    { "afc562b4-50cd-4329-b56e-6985257764f9", "43dad1ae-6569-4ebc-8d51-ae66c0d86161", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c807ca-acbb-403b-adf1-9bf6b5b4c876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "827656fa-d6f4-4018-baa3-3cad477d674e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afc562b4-50cd-4329-b56e-6985257764f9");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("19e01031-6def-47a6-b3ec-4b2c67615426"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ff6ef95b-2cea-4012-9930-ce0455f51fdb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c3a29ab6-b1eb-4e1f-9810-ddee90c889c0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f0d33bcc-317a-401d-b447-8dd515310720"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductListId",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("8b63c989-9304-432b-9ff2-dbbcd6324c49"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00e010f7-328c-4a2a-bd99-5800d602a52d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ebcea88e-5479-472b-b51a-c236bf91313d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("8f336c67-1b08-4bfc-9db8-f8a9dc96bb07"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("20b2cd51-ea67-4073-866c-3c41a6505778"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c27fdd51-79cd-462f-ae5a-9ad5d6a8ac75"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4128a167-b10b-415c-ade6-317bf73a85b8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("52d4fc15-9cac-40d5-b6a1-db227503fa5f"));

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("4fb3f1f7-fad5-433a-9858-464b26011119")),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
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
                    { "0e1e2478-ac2b-4491-bde0-29ff31120ec0", "1f401363-0722-47f6-9376-829275017824", "Manager", "MANAGER" },
                    { "32dfac1f-8467-4c55-8b7c-6fda9369891e", "95a19a8b-a151-4a6a-930f-5d39fd048b5f", "Customer", "CUSTOMER" },
                    { "85136479-21de-4ff9-a779-fdb9654b24f2", "590a694a-d8a9-428d-a613-56f0c8fa6e10", "Employee", "EMPLOYEE" }
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
    }
}
