using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23096bfb-4d7d-40f7-8988-e3c27a827420");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0bab4f3-e9f8-466b-8331-e6c693170557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbf72970-c346-43e8-9fc5-505340e149bd");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("1935e5b1-487c-446f-a65d-6b1d41bcc26a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d472ca6e-6540-4fdd-b436-49f5b8b06c65"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9c49c1c9-9564-4285-927b-edac4f691102"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("590edb75-211f-44d7-ba75-b054c699c084"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7f5def69-1748-4657-ad99-b9b947c561ed"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b6d9a910-fc7e-4450-8180-d9b3ce626e59"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c2a9bbdb-f111-43e4-9095-a133b19258b5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e2ddc595-59fb-4bb0-b19e-ff6d9993ac77"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d09545e4-1901-4491-9a23-096734008b4c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ca080b7b-121b-4d70-bbb5-2c43d2843a8c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("477913e7-59a5-4631-9486-414b88aec7f0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("65272161-415a-44f7-a78f-cf2dc4e223a3"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("7a752fc4-f9ca-47a8-8ad0-792dd0691732"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("85eb56db-aff6-415a-8ce7-8d912176b33d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49b5ae2a-06ab-4aea-8512-74ae528000d4", "6305741c-6650-41cf-8e6a-3a1a442810a6", "Customer", "CUSTOMER" },
                    { "84ace02b-4dd3-4e74-ac20-454962bd3fb8", "e0bb0c1d-5f26-4f71-906f-aa7a80216882", "Employee", "EMPLOYEE" },
                    { "a5bc451a-281d-4bcd-bde5-cac2d09df773", "2dc17271-2509-4855-9fcb-6fe3c97d1ba8", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49b5ae2a-06ab-4aea-8512-74ae528000d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84ace02b-4dd3-4e74-ac20-454962bd3fb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5bc451a-281d-4bcd-bde5-cac2d09df773");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d472ca6e-6540-4fdd-b436-49f5b8b06c65"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("1935e5b1-487c-446f-a65d-6b1d41bcc26a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("590edb75-211f-44d7-ba75-b054c699c084"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9c49c1c9-9564-4285-927b-edac4f691102"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b6d9a910-fc7e-4450-8180-d9b3ce626e59"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7f5def69-1748-4657-ad99-b9b947c561ed"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e2ddc595-59fb-4bb0-b19e-ff6d9993ac77"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c2a9bbdb-f111-43e4-9095-a133b19258b5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ca080b7b-121b-4d70-bbb5-2c43d2843a8c"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d09545e4-1901-4491-9a23-096734008b4c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("65272161-415a-44f7-a78f-cf2dc4e223a3"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("477913e7-59a5-4631-9486-414b88aec7f0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("85eb56db-aff6-415a-8ce7-8d912176b33d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("7a752fc4-f9ca-47a8-8ad0-792dd0691732"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23096bfb-4d7d-40f7-8988-e3c27a827420", "daa6f6ba-f6dc-4213-b258-89c4cce8dec3", "Employee", "EMPLOYEE" },
                    { "d0bab4f3-e9f8-466b-8331-e6c693170557", "e641083c-0c52-4ae6-b1f3-d757e6ab6b8f", "Manager", "MANAGER" },
                    { "fbf72970-c346-43e8-9fc5-505340e149bd", "86da7f71-5210-47dd-bef6-600a866e193d", "Customer", "CUSTOMER" }
                });
        }
    }
}
