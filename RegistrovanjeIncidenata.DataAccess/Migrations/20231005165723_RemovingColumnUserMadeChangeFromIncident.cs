using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovingColumnUserMadeChangeFromIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17adaa00-d49f-4ba9-b9ff-0a6208c271e6", "AQAAAAIAAYagAAAAEC5ydotX9nDP4zPdh0vGcCTrUVmTkWagAhtjbPOV1RnYnGrpaWM5g2mL/QP17yIu9g==", "b7be6d66-0b4b-4677-9c97-435f78961fcd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e7aa9ed-a54c-4249-b745-62e40e1d4e84", "AQAAAAIAAYagAAAAECDRWVx8xbCY90mdl443x6JI0py1fPfbjm5vzjjm1Lt5f8RaiR68N7UfRhGTike2Uw==", "7ee2d5e8-a64f-4785-82b5-302634fed8ba" });
        }
    }
}
