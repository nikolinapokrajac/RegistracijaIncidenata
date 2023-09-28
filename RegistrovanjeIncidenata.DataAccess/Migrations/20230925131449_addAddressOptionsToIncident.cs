using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAddressOptionsToIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IncidentAddress",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "IncidentLatitude",
                table: "Incidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "IncidentLongitude",
                table: "Incidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IncidentAddress", "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { "Visoko", 18.178795999999998, 43.988964000000003 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IncidentAddress", "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { "Dobrinja", 18.357901999999999, 43.823810999999999 });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IncidentAddress", "IncidentLatitude", "IncidentLongitude" },
                values: new object[] { "Grbavica", 18.392914000000001, 43.851329999999997 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncidentAddress",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "IncidentLatitude",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "IncidentLongitude",
                table: "Incidents");
        }
    }
}
