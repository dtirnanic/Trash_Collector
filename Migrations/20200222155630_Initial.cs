using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "181ca8a5-e51c-4f13-bd06-f6e87086e3f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56422964-aa54-4359-8d85-6732a896bff3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03bdedc6-d802-4fa7-995f-e4c592646ea6", "af7d9f50-396f-45d3-88a2-d61b64845c6f", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a44f82a1-8c5b-4a04-bb3d-fa2c55662a57", "22eab3d3-45a3-43e7-95ab-21cd27b59f7e", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03bdedc6-d802-4fa7-995f-e4c592646ea6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a44f82a1-8c5b-4a04-bb3d-fa2c55662a57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56422964-aa54-4359-8d85-6732a896bff3", "41623e91-4c09-4434-82c9-447fe14abacd", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "181ca8a5-e51c-4f13-bd06-f6e87086e3f5", "38e71e13-0690-42be-886a-5d73b0020a83", "Customer", "CUSTOMER" });
        }
    }
}
