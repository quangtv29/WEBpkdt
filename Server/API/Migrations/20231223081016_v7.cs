using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29b7aa63-b828-4b89-86e3-86568a5c9b8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5861582a-215d-4eed-b8a0-55f0cbf661bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cabd9d5-cb5f-499d-b217-a350987d0d31");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b4d3da73-74b4-47a2-9f5b-40a9cd78170d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7175dcf6-6780-4fdd-811a-c4a66b4af7d0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c625cdf8-3c94-4737-9b88-06187308be0f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("61a3eed0-8cea-439a-9ca2-8dedb394c7f5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ccc85fc0-0165-4696-b912-f7eaf7195233"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fb65930f-2a74-4d83-b332-b54a4124c6d8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c88e8a5f-f7eb-4d94-ba72-0abdb8f559a8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4bcc32e9-14f5-4860-9323-a94c3cbd91a9"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("03a67e14-ecf0-4b58-becf-75b62e7caec1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("47a3ad9b-99ad-4962-9d34-b8c093d3f0ed"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e1a90781-7d6d-48f5-a9d1-ec5ab0f994c6"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e24693d0-e461-4266-bd74-55b897b94a36"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6eb5dc19-79a7-4147-bdcb-210e82a0f226"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("324ab43d-8540-4c5f-9b7d-cf5f1790d7b0"));

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("0126da51-4822-4d80-8b4e-80bdfca2388a")),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("475afee6-a6a2-4a14-832d-8f0a6db51cb4")),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0da27ab0-4abe-4ad3-9800-3ee045177554", "50ffa86e-a800-4656-aae0-2930188c0447", "Employee", "EMPLOYEE" },
                    { "57d08f9f-053a-47e4-8429-bb0d27c90b78", "26364106-a657-4a82-b37e-c1284f6efc68", "Manager", "MANAGER" },
                    { "f8d0154b-4841-49d3-8b2c-b5038469c018", "69ad7098-873e-43e5-a0b3-03a0d554183b", "Customer", "CUSTOMER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_CustomerId",
                table: "SaleDetail",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId",
                table: "SaleDetail",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0da27ab0-4abe-4ad3-9800-3ee045177554");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57d08f9f-053a-47e4-8429-bb0d27c90b78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8d0154b-4841-49d3-8b2c-b5038469c018");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Customer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7175dcf6-6780-4fdd-811a-c4a66b4af7d0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b4d3da73-74b4-47a2-9f5b-40a9cd78170d"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("61a3eed0-8cea-439a-9ca2-8dedb394c7f5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c625cdf8-3c94-4737-9b88-06187308be0f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fb65930f-2a74-4d83-b332-b54a4124c6d8"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ccc85fc0-0165-4696-b912-f7eaf7195233"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4bcc32e9-14f5-4860-9323-a94c3cbd91a9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c88e8a5f-f7eb-4d94-ba72-0abdb8f559a8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("47a3ad9b-99ad-4962-9d34-b8c093d3f0ed"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("03a67e14-ecf0-4b58-becf-75b62e7caec1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e24693d0-e461-4266-bd74-55b897b94a36"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e1a90781-7d6d-48f5-a9d1-ec5ab0f994c6"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("324ab43d-8540-4c5f-9b7d-cf5f1790d7b0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6eb5dc19-79a7-4147-bdcb-210e82a0f226"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29b7aa63-b828-4b89-86e3-86568a5c9b8c", "1903c592-083a-4d2f-9639-baa3854b684f", "Customer", "CUSTOMER" },
                    { "5861582a-215d-4eed-b8a0-55f0cbf661bb", "d4ee3aaa-81df-497e-bbce-9dad0f3b95ce", "Employee", "EMPLOYEE" },
                    { "6cabd9d5-cb5f-499d-b217-a350987d0d31", "e693396f-d8ff-49ee-b77a-4360d38cf2f2", "Manager", "MANAGER" }
                });
        }
    }
}
