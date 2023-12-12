using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38379c14-4765-49e2-b448-d907f2c59694");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b99ab5a1-cf39-46dc-85a8-4a826e787490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa10d331-f09f-4648-8f85-93ea91d2159d");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2e723263-fbb2-462e-aeed-5f7b49dc8438"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("51c3d228-2ec3-4e78-a305-3285eb06fced"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f58174fe-dad8-49d4-bc79-08c083279d3e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("3db4697b-bc23-43cd-9af2-47eac79794fb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("377c1eff-bfee-4525-a46f-103f2782d9fa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("37e82429-2f92-430f-85a3-3eec016c9008"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d2e89e12-c069-4858-bc9c-6311199abafe"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("303664e9-a002-470b-be8a-8cf4345ab7e5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5b408ffd-7afb-4140-8f60-69d702643981"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4ceb4275-8dee-4bea-8274-04d48e51f031"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("686b2860-11cb-4e2c-b44e-152cddffd64f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1c5e3393-7e87-40bd-8e9c-099ab44a1762"));

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("84c53959-dba3-427b-bea2-295453c19570")),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Watched = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47fe6f0e-f96b-4d4d-88db-9787f2b0e6a2", "31a76f7c-4435-4a26-beb8-db53bb3adde1", "Customer", "CUSTOMER" },
                    { "880074c7-a8cd-40a0-9187-bb7b0af1d4bc", "84d28d31-d281-460e-960f-035a52836fa8", "Employee", "EMPLOYEE" },
                    { "8f958d98-f1da-4881-acb0-b2bb7587288b", "dfc88b10-51c0-41cf-b8cc-c0fedea24d49", "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CustomerID",
                table: "Notification",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47fe6f0e-f96b-4d4d-88db-9787f2b0e6a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "880074c7-a8cd-40a0-9187-bb7b0af1d4bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f958d98-f1da-4881-acb0-b2bb7587288b");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("51c3d228-2ec3-4e78-a305-3285eb06fced"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2e723263-fbb2-462e-aeed-5f7b49dc8438"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("3db4697b-bc23-43cd-9af2-47eac79794fb"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f58174fe-dad8-49d4-bc79-08c083279d3e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("37e82429-2f92-430f-85a3-3eec016c9008"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("377c1eff-bfee-4525-a46f-103f2782d9fa"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("303664e9-a002-470b-be8a-8cf4345ab7e5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d2e89e12-c069-4858-bc9c-6311199abafe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4ceb4275-8dee-4bea-8274-04d48e51f031"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5b408ffd-7afb-4140-8f60-69d702643981"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1c5e3393-7e87-40bd-8e9c-099ab44a1762"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("686b2860-11cb-4e2c-b44e-152cddffd64f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38379c14-4765-49e2-b448-d907f2c59694", "dcc8fbca-4794-43c7-ab10-589a7657be3a", "Customer", "CUSTOMER" },
                    { "b99ab5a1-cf39-46dc-85a8-4a826e787490", "767edcf3-8237-4fbb-93a0-d296a0e1a151", "Manager", "MANAGER" },
                    { "fa10d331-f09f-4648-8f85-93ea91d2159d", "6ee2b288-390c-406e-a32d-4d5ea289a931", "Employee", "EMPLOYEE" }
                });
        }
    }
}
