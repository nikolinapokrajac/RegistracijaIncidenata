using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5001157c-0a2e-4b48-8677-ed0c850dcdd9", "AQAAAAIAAYagAAAAENzNwt1CdcUQ+xTSw0jmh/n08kBZsU7ib4mEXOh96fbMA+vvr83uhEpfHPILqZxXbQ==", "5400689d-fb55-42f4-abdc-b8f42de57d53" });

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "\\images\\municipalitie\\223a5d1c-9b35-4417-9ed3-f885e82697e7.jpg");

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlImage",
                value: "\\images\\municipalitie\\26534751-2e54-4437-b719-3697a756534b.png");

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlImage",
                value: "\\images\\municipalitie\\pale.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85439842-34e6-42e8-98ab-a0e2761ab3d9", "AQAAAAIAAYagAAAAEIrQ9xuHS2eBpcflwk9jx8Y3raTUaYcgxzRhpMAQq3FQU0nlrOXnud5lDcRaPERlLQ==", "848bfbad-a466-400a-bfe4-d0cc6f2b676d" });

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Municipalities",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlImage",
                value: "");
        }
    }
}
