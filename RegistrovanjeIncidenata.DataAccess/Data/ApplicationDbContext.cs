using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Data
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
                    ImageUrl = "\\images\\incidentType\\56ac8ec3-dc74-4bd7-910b-fed4a55a07c3.webp"
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
                    ImageUrl = "\\images\\incidentType\\56ac8ec3-dc74-4bd7-910b-fed4a55a07c3.webp"
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
            modelBuilder.Entity<Municipalitie>().HasData(new Municipalitie { Id = 1, Name = "Istočni Stari Grad", Address = "Crepoljsko", Latitude = "43.923302668378604", Longitude = "18.479616005630987", UrlImage = "\\images\\municipalitie\\223a5d1c-9b35-4417-9ed3-f885e82697e7.jpg" },
                new Municipalitie { Id = 2, Name = "Novi Grad", Address = "Petra Kočića 2", Latitude = "43.837512769364075", Longitude = "18.400499081072937", UrlImage = "\\images\\municipalitie\\26534751-2e54-4437-b719-3697a756534b.png" },
                new Municipalitie { Id = 3, Name = "Pale", Address = "Romanijska 15", Latitude = "43.81936393519571", Longitude = "18.56738589641413", UrlImage = "\\images\\municipalitie\\pale.jpg" });
            modelBuilder.Entity<Incident>().HasData(new Incident { Id = 1, Name = "Lažno predstavljanje", Description = "U 10,50 časova Policijskoj upravi Bijeljina prijavilo je lice D. O. iz Bijeljine, da joj se u Ulici Baje Pivljanina iz putničkog motornog vozila marke ''Golf'', bijele boje, obratilo nepoznato lice, predstavljajući se kao policijski službenik i da je isti tražio da pokaže ličnu kartu. Navedena je tom prilikom, kako je navela, zatražila da joj isti pokaže službenu legitimaciju i da se predstavi kako bi se uvjerila da se radi o policijskom službeniku, nakon čega joj je isti vratio ličnu kartu i udaljio se u nepoznatom pravcu. O događaju je obavješten dežurni tužilac Okružnog javnog tužilaštva Bijeljina koji se izjasnio da se radi  o krivičnom djelu ''Lažno predstavljanje''.", InjuredPeopleCount = 0, DeadPeopleCount = 0, IncidentTypeId = 1, MunicipalitieId = 2, UserNameOfPersonThatAddedIncident = "pokrajacnikolina3@gmail.com", dateIncident = DateTime.Parse("2023-01-02T12:15:00"), IncidentAddress = "Visoko", IncidentLongitude = 18.178796, IncidentLatitude = 43.988964 },
                new Incident { Id = 2, Name = "Incident br 2", Description = "Opis 2.incidenta", InjuredPeopleCount = 4, DeadPeopleCount = 2, IncidentTypeId = 4, MunicipalitieId = 2, UserNameOfPersonThatAddedIncident = "pokrajacnikolina3@gmail.com", dateIncident = DateTime.Parse("2023-01-02T12:15:00"), IncidentAddress = "Dobrinja", IncidentLongitude = 18.357902, IncidentLatitude = 43.823811 },
                new Incident { Id = 3, Name = "Incident br 3", Description = "Opis 3.incidenta", InjuredPeopleCount = 7, DeadPeopleCount = 1, IncidentTypeId = 2, MunicipalitieId = 1, UserNameOfPersonThatAddedIncident = "pokrajacnikolina3@gmail.com", dateIncident = DateTime.Parse("2022-05-05T12:12:00"), IncidentAddress = "Grbavica", IncidentLongitude = 18.392914, IncidentLatitude = 43.851330 });

            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Operater",
                NormalizedName = "OPERATER",
                Id = "1533fe23-dcad-4a7d-a42c-22e256d663d9",
                ConcurrencyStamp = "1533fe23-dcad-4a7d-a42c-22e256d663d9"
            });
            //create user
            var appUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                Name = "admin",
                LastName = "admin",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM"
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Lozinka1_");

            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(appUser);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
