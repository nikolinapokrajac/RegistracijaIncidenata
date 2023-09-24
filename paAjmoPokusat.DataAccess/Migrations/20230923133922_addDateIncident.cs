using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paAjmoPokusat.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDateIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateIncident",
                table: "Incidents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                column: "dateIncident",
                value: new DateTime(2023, 1, 2, 12, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2,
                column: "dateIncident",
                value: new DateTime(2023, 1, 2, 12, 15, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3,
                column: "dateIncident",
                value: new DateTime(2022, 5, 5, 12, 12, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateIncident",
                table: "Incidents");
        }
    }
}
