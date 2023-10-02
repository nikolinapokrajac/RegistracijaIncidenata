using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newmigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85439842-34e6-42e8-98ab-a0e2761ab3d9", "AQAAAAIAAYagAAAAEIrQ9xuHS2eBpcflwk9jx8Y3raTUaYcgxzRhpMAQq3FQU0nlrOXnud5lDcRaPERlLQ==", "848bfbad-a466-400a-bfe4-d0cc6f2b676d" });

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "\\images\\incidentType\\56ac8ec3-dc74-4bd7-910b-fed4a55a07c3.webp");

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "\\images\\incidentType\\56ac8ec3-dc74-4bd7-910b-fed4a55a07c3.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "014dbda7-94a2-4af0-93dc-9dd4bcb0041e", "AQAAAAIAAYagAAAAEO97ifxLYX18CKuBitPP/UnzaJVZjTMlT5vx8cINPOFsPZU4vDQZtRlCMKKem8bN2Q==", "8255a1b1-1707-4b43-9797-36e64f5626b1" });

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "images\\incidentType\\dd64b58d-e339-4c81-ab7f-693e12483b2e.jpg");

            migrationBuilder.UpdateData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "images\\incidentType\\dd64b58d-e339-4c81-ab7f-693e12483b2e.jpg");
        }
    }
}
