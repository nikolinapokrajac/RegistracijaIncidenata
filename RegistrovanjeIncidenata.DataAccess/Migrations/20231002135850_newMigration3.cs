using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef695a2-7695-4f0a-ac63-c7903537eb2f", "AQAAAAIAAYagAAAAEHDAw8lOyX9GXmPAd6g1eftYIEsQef9lZIni8Iih4K+uk4iP5yMKkm05JRY48H1e/w==", "783a5875-a9c3-485d-a124-db4303ae9436" });

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "\\images\\incidentType\\dd64b58d-e339-4c81-ab7f-693e12483b2e.jpg");

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "\\images\\incidentType\\dd64b58d-e339-4c81-ab7f-693e12483b2e.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9113684c-b690-46bb-8566-601254ff6327", "AQAAAAIAAYagAAAAELZZgSSVmSv+4O3Sc0/m7MoMg+pLRXsC/MNYuQDdU9HM7BBaCz+1B0dyHl6IHnqd2Q==", "837abd38-9292-415d-839e-2bd5b1ee568f" });

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");
        }
    }
}
