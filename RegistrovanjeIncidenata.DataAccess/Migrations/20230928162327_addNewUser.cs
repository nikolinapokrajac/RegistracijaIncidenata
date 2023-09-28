using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1533fe23-dcad-4a7d-a42c-22e256d663d9", "1533fe23-dcad-4a7d-a42c-22e256d663d9", "Operater", "OPERATER" },
                    { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "Role", "SecurityStamp", "State", "StreetAdress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", 0, null, "28791cd7-0182-420e-abdb-926492a08238", "ApplicationUser", "admin@gmail.com", true, "admin", false, null, "admin", null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEC0+xHGDcG8AQskMuDFIiatwsgdSoVc7QTHruTECEEXapriQYOt3ZB0jRVJ7jL9IuA==", null, false, null, null, "a1825d3f-8449-495d-a9f9-6f6cb357682f", null, null, false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1533fe23-dcad-4a7d-a42c-22e256d663d9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6", "02174cf0–9412–4cfe - afbf - 59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6");
        }
    }
}
