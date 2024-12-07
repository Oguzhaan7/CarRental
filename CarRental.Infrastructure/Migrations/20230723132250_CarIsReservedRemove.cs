using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarIsReservedRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c621abec-44e6-4448-a205-7fc6aeaae63e"));

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDateTime", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedDateTime" },
                values: new object[] { new Guid("90364661-43f3-4480-a555-c62a13f305d9"), new DateTime(2023, 7, 23, 13, 22, 50, 182, DateTimeKind.Utc).AddTicks(573), "admin@admin.com", "Admin", "Admin", "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", "5412256532", 0, new DateTime(2023, 7, 23, 13, 22, 50, 182, DateTimeKind.Utc).AddTicks(575) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90364661-43f3-4480-a555-c62a13f305d9"));

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Cars",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDateTime", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "UpdatedDateTime" },
                values: new object[] { new Guid("c621abec-44e6-4448-a205-7fc6aeaae63e"), new DateTime(2023, 7, 23, 11, 58, 23, 263, DateTimeKind.Utc).AddTicks(6602), "admin@admin.com", "Admin", "Admin", "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", "5412256532", 0, new DateTime(2023, 7, 23, 11, 58, 23, 263, DateTimeKind.Utc).AddTicks(6604) });
        }
    }
}
