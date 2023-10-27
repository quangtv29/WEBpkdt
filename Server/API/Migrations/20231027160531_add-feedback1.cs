using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addfeedback1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bbdc46b-01b7-420c-966b-87bb5ecf4e47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3907244f-93d9-4a2d-86a8-deaef3cf13c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb36212b-c21b-419a-8508-e92cd094edd1");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6a846fe9-1c88-4a99-8f7e-69983f4edca0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("2012331f-d044-4513-8269-f88dc7b24374"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("76629030-11d1-4ed3-8d37-04e4d0716835"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("cca52c2d-6388-4173-ac7c-1aefc3efda81"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("5e786d38-5d54-44e4-901a-14d78ab5feb7"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("4d5535e6-a046-4194-b1c8-4dec1ce47fc4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a8120c73-e16e-4ac7-acd8-0897e7d44894"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6a504510-005e-4a18-9b7a-77d77e3a160b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b0dbbd31-db63-4a5c-b7cb-a5c91a358d72"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("251788d2-00da-477d-956a-54dd3942b6f1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("f8bd5ce6-3cd6-442c-9d9f-7a93aa6ae59a"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("c551b853-fc1c-4969-b082-a128a0429c23"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e5f9941-dd51-43d2-9f73-9b0dfbd7e9b6", "e4e6006a-f23c-4cc9-a6b8-af2f91ce247e", "Employee", "EMPLOYEE" },
                    { "73995847-3a41-4bed-8966-47092083a25c", "6c46eb3c-ef45-413f-af04-a2b351a52e94", "Customer", "CUSTOMER" },
                    { "8566ef57-b81c-49b6-b44b-7cfaa586a7aa", "6e93bf50-955b-4142-892d-32b76fc4c59a", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e5f9941-dd51-43d2-9f73-9b0dfbd7e9b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73995847-3a41-4bed-8966-47092083a25c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8566ef57-b81c-49b6-b44b-7cfaa586a7aa");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("2012331f-d044-4513-8269-f88dc7b24374"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("6a846fe9-1c88-4a99-8f7e-69983f4edca0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("cca52c2d-6388-4173-ac7c-1aefc3efda81"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("76629030-11d1-4ed3-8d37-04e4d0716835"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductList",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4d5535e6-a046-4194-b1c8-4dec1ce47fc4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("5e786d38-5d54-44e4-901a-14d78ab5feb7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("6a504510-005e-4a18-9b7a-77d77e3a160b"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("a8120c73-e16e-4ac7-acd8-0897e7d44894"));

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedback",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("251788d2-00da-477d-956a-54dd3942b6f1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b0dbbd31-db63-4a5c-b7cb-a5c91a358d72"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Bill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("c551b853-fc1c-4969-b082-a128a0429c23"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("f8bd5ce6-3cd6-442c-9d9f-7a93aa6ae59a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bbdc46b-01b7-420c-966b-87bb5ecf4e47", "da2bf729-42ed-49d8-bf21-1d5f1e476e2c", "Employee", "EMPLOYEE" },
                    { "3907244f-93d9-4a2d-86a8-deaef3cf13c3", "61192793-3008-4e7f-b872-9753f08a7d31", "Manager", "MANAGER" },
                    { "fb36212b-c21b-419a-8508-e92cd094edd1", "212aa488-d7b8-44be-8500-02fc27957e1f", "Customer", "CUSTOMER" }
                });
        }
    }
}
