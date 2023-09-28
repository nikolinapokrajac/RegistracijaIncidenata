﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistrovanjeIncidenata.DataAccess.Data;

#nullable disable

namespace RegistrovanjeIncidenata.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230902132112_addIncidentImageToDb")]
    partial class addIncidentImageToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("paAjmoPokusat.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeadPeopleCount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IncidentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("InjuredPeopleCount")
                        .HasColumnType("int");

                    b.Property<int>("MunicipalitieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentTypeId");

                    b.HasIndex("MunicipalitieId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeadPeopleCount = 0,
                            Description = "U 10,50 časova Policijskoj upravi Bijeljina prijavilo je lice D. O. iz Bijeljine, da joj se u Ulici Baje Pivljanina iz putničkog motornog vozila marke ''Golf'', bijele boje, obratilo nepoznato lice, predstavljajući se kao policijski službenik i da je isti tražio da pokaže ličnu kartu. Navedena je tom prilikom, kako je navela, zatražila da joj isti pokaže službenu legitimaciju i da se predstavi kako bi se uvjerila da se radi o policijskom službeniku, nakon čega joj je isti vratio ličnu kartu i udaljio se u nepoznatom pravcu. O događaju je obavješten dežurni tužilac Okružnog javnog tužilaštva Bijeljina koji se izjasnio da se radi  o krivičnom djelu ''Lažno predstavljanje''.",
                            IncidentTypeId = 1,
                            InjuredPeopleCount = 0,
                            MunicipalitieId = 2,
                            Name = "Lažno predstavljanje"
                        },
                        new
                        {
                            Id = 2,
                            DeadPeopleCount = 2,
                            Description = "Opis 2.incidenta",
                            IncidentTypeId = 4,
                            InjuredPeopleCount = 4,
                            MunicipalitieId = 2,
                            Name = "Incident br 2"
                        },
                        new
                        {
                            Id = 3,
                            DeadPeopleCount = 1,
                            Description = "Opis 3.incidenta",
                            IncidentTypeId = 2,
                            InjuredPeopleCount = 7,
                            MunicipalitieId = 1,
                            Name = "Incident br 3"
                        });
                });

            modelBuilder.Entity("paAjmoPokusat.Models.IncidentImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.ToTable("IncidentImages");
                });

            modelBuilder.Entity("paAjmoPokusat.Models.IncidentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IncidentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Nesreće na putevima, sudari vozila, pešaci koji su udareni, oštećenja infrastrukture (npr. srušeni semafori, oštećenja na putu).",
                            ImageUrl = "",
                            Name = "Saobraćajni incidenti"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Poplave, zemljotresi, klizišta, požari, oluje, suše i druge prirodne katastrofe.",
                            ImageUrl = "",
                            Name = "Prirodne nepogode"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Krađe, pljačke, napadi, vandalizam, trgovina drogom, nasilje u porodici, prevara i druge kriminalne aktivnosti.",
                            ImageUrl = "",
                            Name = "Kriminal"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Epidemije, zarazne bolesti, nesreće na radu, trovanja hranom ili vodom, medicinske greške.",
                            ImageUrl = "",
                            Name = "Zdravstveni incidenti"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Teroristički napadi, oružani napadi, pretnje, incidenti vezani za nacionalnu bezbednost.",
                            ImageUrl = "",
                            Name = "Incidenti javne bezbednosti"
                        });
                });

            modelBuilder.Entity("paAjmoPokusat.Models.Municipalitie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Municipalities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Crepoljsko",
                            Latitude = "43.923302668378604",
                            Longitude = "18.479616005630987",
                            Name = "Istočni Stari Grad",
                            UrlImage = ""
                        },
                        new
                        {
                            Id = 2,
                            Address = "Petra Kočića 2",
                            Latitude = "43.837512769364075",
                            Longitude = "18.400499081072937",
                            Name = "Novi Grad",
                            UrlImage = ""
                        },
                        new
                        {
                            Id = 3,
                            Address = "Romanijska 15",
                            Latitude = "43.81936393519571",
                            Longitude = "18.56738589641413",
                            Name = "Pale",
                            UrlImage = ""
                        });
                });

            modelBuilder.Entity("paAjmoPokusat.Models.Incident", b =>
                {
                    b.HasOne("paAjmoPokusat.Models.IncidentType", "IncidentType")
                        .WithMany()
                        .HasForeignKey("IncidentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("paAjmoPokusat.Models.Municipalitie", "Municipalitie")
                        .WithMany()
                        .HasForeignKey("MunicipalitieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IncidentType");

                    b.Navigation("Municipalitie");
                });

            modelBuilder.Entity("paAjmoPokusat.Models.IncidentImage", b =>
                {
                    b.HasOne("paAjmoPokusat.Models.Incident", "Incident")
                        .WithMany("IncidentImages")
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("paAjmoPokusat.Models.Incident", b =>
                {
                    b.Navigation("IncidentImages");
                });
#pragma warning restore 612, 618
        }
    }
}
