using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new Guid("526f0fd9-6f1c-4fa3-a8f9-0c1c471e5318"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2e723263-fbb2-462e-aeed-5f7b49dc8438"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("79cbfa15-108c-4dd5-a228-42a5ac908197"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f58174fe-dad8-49d4-bc79-08c083279d3e"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("060a1b49-e200-4302-8ba1-6dc379214d73"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("377c1eff-bfee-4525-a46f-103f2782d9fa"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("be1fab0a-85ae-45c4-ac5b-506c270a5ac5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d2e89e12-c069-4858-bc9c-6311199abafe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a562e374-191c-4540-887b-be1fc86500fe"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("84c53959-dba3-427b-bea2-295453c19570"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("9cc0e26a-aebb-4961-be8c-24c59f8b7c75"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5b408ffd-7afb-4140-8f60-69d702643981"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f357f7f0-0b64-4f63-bc05-2792f71554c0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("686b2860-11cb-4e2c-b44e-152cddffd64f"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f28a04a-a1d8-4eb2-8918-5fa52b922a2a", "06f5b5cd-c5e8-451e-b8a7-98ce3328478f", "Manager", "MANAGER" },
                    { "93c0d892-6e9e-4212-8ce9-4faecb3af592", "3847330b-6216-4f85-ae10-1e3c379955d5", "Customer", "CUSTOMER" },
                    { "bf46f723-fe39-4c7d-b44a-52b528311420", "b622a18f-bd15-448a-ad27-4a7a5655beb4", "Employee", "EMPLOYEE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f28a04a-a1d8-4eb2-8918-5fa52b922a2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93c0d892-6e9e-4212-8ce9-4faecb3af592");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf46f723-fe39-4c7d-b44a-52b528311420");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bill");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2e723263-fbb2-462e-aeed-5f7b49dc8438"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("526f0fd9-6f1c-4fa3-a8f9-0c1c471e5318"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f58174fe-dad8-49d4-bc79-08c083279d3e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("79cbfa15-108c-4dd5-a228-42a5ac908197"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("377c1eff-bfee-4525-a46f-103f2782d9fa"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("060a1b49-e200-4302-8ba1-6dc379214d73"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d2e89e12-c069-4858-bc9c-6311199abafe"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("be1fab0a-85ae-45c4-ac5b-506c270a5ac5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("84c53959-dba3-427b-bea2-295453c19570"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a562e374-191c-4540-887b-be1fc86500fe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5b408ffd-7afb-4140-8f60-69d702643981"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("9cc0e26a-aebb-4961-be8c-24c59f8b7c75"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("686b2860-11cb-4e2c-b44e-152cddffd64f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f357f7f0-0b64-4f63-bc05-2792f71554c0"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47fe6f0e-f96b-4d4d-88db-9787f2b0e6a2", "31a76f7c-4435-4a26-beb8-db53bb3adde1", "Customer", "CUSTOMER" },
                    { "880074c7-a8cd-40a0-9187-bb7b0af1d4bc", "84d28d31-d281-460e-960f-035a52836fa8", "Employee", "EMPLOYEE" },
                    { "8f958d98-f1da-4881-acb0-b2bb7587288b", "dfc88b10-51c0-41cf-b8cc-c0fedea24d49", "Manager", "MANAGER" }
                });
        }
    }
}
