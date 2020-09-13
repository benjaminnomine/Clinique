﻿// <auto-generated />
using System;
using Clinique.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinique.EntityFramework.Migrations
{
    [DbContext(typeof(CliniqueDbContext))]
    [Migration("20200912191145_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinique.Domain.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeDocteur")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnostic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocteurId")
                        .HasColumnType("int");

                    b.Property<int?>("DossierpatientId")
                        .HasColumnType("int");

                    b.Property<int>("NumDos")
                        .HasColumnType("int");

                    b.Property<int>("NumOrd")
                        .HasColumnType("int");

                    b.Property<int?>("OrdonnanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocteurId");

                    b.HasIndex("DossierpatientId");

                    b.HasIndex("OrdonnanceId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Docteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSpecialite")
                        .HasColumnType("int");

                    b.Property<int>("Matricule")
                        .HasColumnType("int");

                    b.Property<int>("NbrPatients")
                        .HasColumnType("int");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenomM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecialiteId")
                        .HasColumnType("int");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SpecialiteId");

                    b.ToTable("Docteurs");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Dossierpatient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaiss")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocteurId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Matricule")
                        .HasColumnType("int");

                    b.Property<string>("NomP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumAS")
                        .HasColumnType("int");

                    b.Property<int>("NumDos")
                        .HasColumnType("int");

                    b.Property<string>("PrenomP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocteurId");

                    b.ToTable("Dossierpatients");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Medicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.Property<int>("IdMed")
                        .HasColumnType("int");

                    b.Property<string>("NomMed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateC")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumOrd")
                        .HasColumnType("int");

                    b.Property<string>("Recommandations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ordonnances");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancechirurgie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomChirurgie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOrd")
                        .HasColumnType("int");

                    b.Property<int?>("OrdonnanceId")
                        .HasColumnType("int");

                    b.Property<int>("Rang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdonnanceId");

                    b.ToTable("Ordonnancechirurgies");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancemedicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMed")
                        .HasColumnType("int");

                    b.Property<int?>("MedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("NbBoites")
                        .HasColumnType("int");

                    b.Property<int>("NumOrd")
                        .HasColumnType("int");

                    b.Property<int?>("OrdonnanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentId");

                    b.HasIndex("OrdonnanceId");

                    b.ToTable("Ordonnancemedicaments");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Specialite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialites");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Consultation", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Docteur", "Docteur")
                        .WithMany()
                        .HasForeignKey("DocteurId");

                    b.HasOne("Clinique.Domain.Models.Dossierpatient", "Dossierpatient")
                        .WithMany()
                        .HasForeignKey("DossierpatientId");

                    b.HasOne("Clinique.Domain.Models.Ordonnance", "Ordonnance")
                        .WithMany()
                        .HasForeignKey("OrdonnanceId");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Docteur", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Specialite", "Specialite")
                        .WithMany()
                        .HasForeignKey("SpecialiteId");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Dossierpatient", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Docteur", "Docteur")
                        .WithMany()
                        .HasForeignKey("DocteurId");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Medicament", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancechirurgie", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Ordonnance", "Ordonnance")
                        .WithMany()
                        .HasForeignKey("OrdonnanceId");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancemedicament", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Medicament", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentId");

                    b.HasOne("Clinique.Domain.Models.Ordonnance", "Ordonnance")
                        .WithMany()
                        .HasForeignKey("OrdonnanceId");
                });
#pragma warning restore 612, 618
        }
    }
}
