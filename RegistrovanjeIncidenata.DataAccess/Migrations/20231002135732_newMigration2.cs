using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9113684c-b690-46bb-8566-601254ff6327", "AQAAAAIAAYagAAAAELZZgSSVmSv+4O3Sc0/m7MoMg+pLRXsC/MNYuQDdU9HM7BBaCz+1B0dyHl6IHnqd2Q==", "837abd38-9292-415d-839e-2bd5b1ee568f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe - afbf - 59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff075f17-592d-4958-a705-9d01b07cf94b", "AQAAAAIAAYagAAAAELK9yuIm/sanVDpcfDGypzL7CJahiU4/HHxjyjDNVSCFU7PLO/n+1uPUcITSai13SA==", "45f5e5c6-fe42-4b58-8b2a-3a84eedd445a" });
        }
    }
}
