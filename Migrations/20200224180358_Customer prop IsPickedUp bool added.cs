using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class CustomerpropIsPickedUpbooladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80aa06f9-a0b0-40d6-8b3d-19661626940c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9497e9ba-a0a6-4987-915b-e3ff0a2bbff8");

            migrationBuilder.AddColumn<bool>(
                name: "IsPickedUp",
                table: "Account",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d034e2d3-8d8f-49e9-b77e-1b6f1c527b29", "7244f75f-1240-496e-a6b8-b6e30c9299eb", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a562df7c-9747-43e4-86e5-212e4eaa00a0", "9ddfb357-9f00-447a-a1c2-b613fbc8afae", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a562df7c-9747-43e4-86e5-212e4eaa00a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d034e2d3-8d8f-49e9-b77e-1b6f1c527b29");

            migrationBuilder.DropColumn(
                name: "IsPickedUp",
                table: "Account");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80aa06f9-a0b0-40d6-8b3d-19661626940c", "fc5206a4-ba16-4e17-9129-877baded0b62", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9497e9ba-a0a6-4987-915b-e3ff0a2bbff8", "453d5a1f-be43-4b95-869b-1a25d8961286", "Customer", "CUSTOMER" });
        }
    }
}
