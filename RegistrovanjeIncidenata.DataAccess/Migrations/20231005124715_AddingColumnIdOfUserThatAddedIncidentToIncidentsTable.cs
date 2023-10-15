using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingColumnIdOfUserThatAddedIncidentToIncidentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdOfUserThatAddedIncident",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e7aa9ed-a54c-4249-b745-62e40e1d4e84", "AQAAAAIAAYagAAAAECDRWVx8xbCY90mdl443x6JI0py1fPfbjm5vzjjm1Lt5f8RaiR68N7UfRhGTike2Uw==", "7ee2d5e8-a64f-4785-82b5-302634fed8ba" });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdOfUserThatAddedIncident", "UserNameOfPersonThatAddedIncident" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IdOfUserThatAddedIncident", "UserNameOfPersonThatAddedIncident" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IdOfUserThatAddedIncident", "UserNameOfPersonThatAddedIncident" },
                values: new object[] { "02174cf0–9412–4cfe - afbf - 59f706d72cf6", "admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOfUserThatAddedIncident",
                table: "Incidents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5001157c-0a2e-4b48-8677-ed0c850dcdd9", "AQAAAAIAAYagAAAAENzNwt1CdcUQ+xTSw0jmh/n08kBZsU7ib4mEXOh96fbMA+vvr83uhEpfHPILqZxXbQ==", "5400689d-fb55-42f4-abdc-b8f42de57d53" });

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserNameOfPersonThatAddedIncident",
                value: "pokrajacnikolina3@gmail.com");

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserNameOfPersonThatAddedIncident",
                value: "pokrajacnikolina3@gmail.com");

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserNameOfPersonThatAddedIncident",
                value: "pokrajacnikolina3@gmail.com");
        }
    }
}
