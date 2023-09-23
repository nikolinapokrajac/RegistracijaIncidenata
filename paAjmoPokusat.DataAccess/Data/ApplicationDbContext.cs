using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<Municipalitie> Municipalities { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentImage> IncidentImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IncidentType>().HasData(
                new IncidentType
                {
                    Id = 1,
                    Name = "Saobraćajni incidenti",
                    Description = "Nesreće na putevima, sudari vozila, pešaci koji su udareni, oštećenja infrastrukture (npr. srušeni semafori, oštećenja na putu).",
                    ImageUrl = ""
                },
                new IncidentType
                {
                    Id = 2,
                    Name = "Prirodne nepogode",
                    Description = "Poplave, zemljotresi, klizišta, požari, oluje, suše i druge prirodne katastrofe.",
                    ImageUrl = ""
                },
                new IncidentType
                {
                    Id = 3,
                    Name = "Kriminal",
                    Description = "Krađe, pljačke, napadi, vandalizam, trgovina drogom, nasilje u porodici, prevara i druge kriminalne aktivnosti.",
                    ImageUrl = ""
                },
                 new IncidentType
                 {
                     Id = 4,
                     Name = "Zdravstveni incidenti",
                     Description = "Epidemije, zarazne bolesti, nesreće na radu, trovanja hranom ili vodom, medicinske greške.",
                     ImageUrl = ""
                 },
                 new IncidentType
                 {
                     Id = 5,
                     Name = "Incidenti javne bezbednosti",
                     Description = "Teroristički napadi, oružani napadi, pretnje, incidenti vezani za nacionalnu bezbednost.",
                     ImageUrl = ""
                 }
                );
            modelBuilder.Entity<Municipalitie>().HasData(new Municipalitie { Id = 1, Name = "Istočni Stari Grad", Address = "Crepoljsko", Latitude = "43.923302668378604", Longitude = "18.479616005630987", UrlImage = "" },
                new Municipalitie { Id = 2, Name = "Novi Grad", Address = "Petra Kočića 2", Latitude = "43.837512769364075", Longitude = "18.400499081072937", UrlImage = "" },
                new Municipalitie { Id = 3, Name = "Pale", Address = "Romanijska 15", Latitude = "43.81936393519571", Longitude = "18.56738589641413", UrlImage = "" });
            modelBuilder.Entity<Incident>().HasData(new Incident { Id = 1, Name = "Lažno predstavljanje", Description = "U 10,50 časova Policijskoj upravi Bijeljina prijavilo je lice D. O. iz Bijeljine, da joj se u Ulici Baje Pivljanina iz putničkog motornog vozila marke ''Golf'', bijele boje, obratilo nepoznato lice, predstavljajući se kao policijski službenik i da je isti tražio da pokaže ličnu kartu. Navedena je tom prilikom, kako je navela, zatražila da joj isti pokaže službenu legitimaciju i da se predstavi kako bi se uvjerila da se radi o policijskom službeniku, nakon čega joj je isti vratio ličnu kartu i udaljio se u nepoznatom pravcu. O događaju je obavješten dežurni tužilac Okružnog javnog tužilaštva Bijeljina koji se izjasnio da se radi  o krivičnom djelu ''Lažno predstavljanje''.", InjuredPeopleCount = 0, DeadPeopleCount = 0, IncidentTypeId = 1, MunicipalitieId = 2, UserNameOfPersonThatAddedIncident = "pokrajacnikolina3@gmail.com" },
                new Incident { Id = 2, Name = "Incident br 2", Description = "Opis 2.incidenta", InjuredPeopleCount = 4, DeadPeopleCount = 2, IncidentTypeId = 4, MunicipalitieId = 2, UserNameOfPersonThatAddedIncident = "pokrajacnikolina3@gmail.com" },
                new Incident { Id = 3, Name = "Incident br 3", Description = "Opis 3.incidenta", InjuredPeopleCount = 7, DeadPeopleCount = 1, IncidentTypeId = 2, MunicipalitieId = 1, UserNameOfPersonThatAddedIncident = "pokrajacnikolina3@gmail.com" });
        }
    }
}
