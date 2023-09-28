using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addAndSeedTablesIncidentTypeMunicipalitieIncidentToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuredPeopleCount = table.Column<int>(type: "int", nullable: false),
                    DeadPeopleCount = table.Column<int>(type: "int", nullable: false),
                    IncidentTypeId = table.Column<int>(type: "int", nullable: false),
                    MunicipalitieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Municipalities_MunicipalitieId",
                        column: x => x.MunicipalitieId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Nesreće na putevima, sudari vozila, pešaci koji su udareni, oštećenja infrastrukture (npr. srušeni semafori, oštećenja na putu).", "", "Saobraćajni incidenti" },
                    { 2, "Poplave, zemljotresi, klizišta, požari, oluje, suše i druge prirodne katastrofe.", "", "Prirodne nepogode" },
                    { 3, "Krađe, pljačke, napadi, vandalizam, trgovina drogom, nasilje u porodici, prevara i druge kriminalne aktivnosti.", "", "Kriminal" },
                    { 4, "Epidemije, zarazne bolesti, nesreće na radu, trovanja hranom ili vodom, medicinske greške.", "", "Zdravstveni incidenti" },
                    { 5, "Teroristički napadi, oružani napadi, pretnje, incidenti vezani za nacionalnu bezbednost.", "", "Incidenti javne bezbednosti" }
                });

            migrationBuilder.InsertData(
                table: "Municipalities",
                columns: new[] { "Id", "Address", "Latitude", "Longitude", "Name", "UrlImage" },
                values: new object[,]
                {
                    { 1, "Crepoljsko", "43.923302668378604", "18.479616005630987", "Istočni Stari Grad", "" },
                    { 2, "Petra Kočića 2", "43.837512769364075", "18.400499081072937", "Novi Grad", "" },
                    { 3, "Romanijska 15", "43.81936393519571", "18.56738589641413", "Pale", "" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "DeadPeopleCount", "Description", "IncidentTypeId", "InjuredPeopleCount", "MunicipalitieId", "Name" },
                values: new object[,]
                {
                    { 1, 0, "U 10,50 časova Policijskoj upravi Bijeljina prijavilo je lice D. O. iz Bijeljine, da joj se u Ulici Baje Pivljanina iz putničkog motornog vozila marke ''Golf'', bijele boje, obratilo nepoznato lice, predstavljajući se kao policijski službenik i da je isti tražio da pokaže ličnu kartu. Navedena je tom prilikom, kako je navela, zatražila da joj isti pokaže službenu legitimaciju i da se predstavi kako bi se uvjerila da se radi o policijskom službeniku, nakon čega joj je isti vratio ličnu kartu i udaljio se u nepoznatom pravcu. O događaju je obavješten dežurni tužilac Okružnog javnog tužilaštva Bijeljina koji se izjasnio da se radi  o krivičnom djelu ''Lažno predstavljanje''.", 1, 0, 2, "Lažno predstavljanje" },
                    { 2, 2, "Opis 2.incidenta", 4, 4, 2, "Incident br 2" },
                    { 3, 1, "Opis 3.incidenta", 2, 7, 1, "Incident br 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentTypeId",
                table: "Incidents",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_MunicipalitieId",
                table: "Incidents",
                column: "MunicipalitieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "IncidentTypes");

            migrationBuilder.DropTable(
                name: "Municipalities");
        }
    }
}
