using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ispravkaKoordinata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { 43.988964000000003, 18.178795999999998 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { 43.823810999999999, 18.357901999999999 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { 43.851329999999997, 18.392914000000001 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { 18.178795999999998, 43.988964000000003 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { 18.357901999999999, 43.823810999999999 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { 18.392914000000001, 43.851329999999997 });
        }
    }
}
