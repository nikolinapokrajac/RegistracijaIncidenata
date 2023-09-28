using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff075f17-592d-4958-a705-9d01b07cf94b", "AQAAAAIAAYagAAAAELK9yuIm/sanVDpcfDGypzL7CJahiU4/HHxjyjDNVSCFU7PLO/n+1uPUcITSai13SA==", "45f5e5c6-fe42-4b58-8b2a-3a84eedd445a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28791cd7-0182-420e-abdb-926492a08238", "AQAAAAIAAYagAAAAEC0+xHGDcG8AQskMuDFIiatwsgdSoVc7QTHruTECEEXapriQYOt3ZB0jRVJ7jL9IuA==", "a1825d3f-8449-495d-a9f9-6f6cb357682f" });
        }
    }
}
