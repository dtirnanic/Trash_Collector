using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class EmployeeandCustomerRolesaddedtoOnModelCreatingmethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5acefc3-2fc7-4a48-a9a3-386b25300b26");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpDay = table.Column<string>(nullable: true),
                    OneTimePickup = table.Column<DateTime>(nullable: false),
                    StartDay = table.Column<DateTime>(nullable: false),
                    EndDay = table.Column<DateTime>(nullable: false),
                    IsSuspended = table.Column<bool>(nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "406316d3-cc52-4850-8072-be8356c2df66", "9fa304f7-8cad-475f-ace0-815f9f6da54a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b96d5bf-ef36-4c08-baa8-f276bc3e0541", "e13702de-a9fb-4e5f-88de-4257e64830b1", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c55699b9-d0b1-474d-9bfa-2ab49a396072", "fa790928-ace8-4656-8fca-1d6a4adbbfda", "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountId",
                table: "Customer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressId",
                table: "Customer",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Account_AccountId",
                table: "Customer",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Account_AccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AccountId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AddressId",
                table: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "406316d3-cc52-4850-8072-be8356c2df66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b96d5bf-ef36-4c08-baa8-f276bc3e0541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c55699b9-d0b1-474d-9bfa-2ab49a396072");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5acefc3-2fc7-4a48-a9a3-386b25300b26", "26ffe174-6573-4c46-ac8a-cfaa8f538173", "Admin", "ADMIN" });
        }
    }
}
