using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newmigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "014dbda7-94a2-4af0-93dc-9dd4bcb0041e", "AQAAAAIAAYagAAAAEO97ifxLYX18CKuBitPP/UnzaJVZjTMlT5vx8cINPOFsPZU4vDQZtRlCMKKem8bN2Q==", "8255a1b1-1707-4b43-9797-36e64f5626b1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef695a2-7695-4f0a-ac63-c7903537eb2f", "AQAAAAIAAYagAAAAEHDAw8lOyX9GXmPAd6g1eftYIEsQef9lZIni8Iih4K+uk4iP5yMKkm05JRY48H1e/w==", "783a5875-a9c3-485d-a124-db4303ae9436" });
        }
    }
}
