using Clinique.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinique.EntityFramework
{
    public class CliniqueDbContext : DbContext
    {
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Docteur> Docteurs { get; set; }
        public DbSet<Dossierpatient> Dossierpatients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Ordonnance> Ordonnances { get; set; }
        public DbSet<Ordonnancechirurgie> Ordonnancechirurgies { get; set; }
        public DbSet<Ordonnancemedicament> Ordonnancemedicaments { get; set; }
        public DbSet<Specialite> Specialites { get; set; }

        public CliniqueDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docteur>().Property(o => o.Niveau).HasConversion<string>();
            modelBuilder.Entity<Dossierpatient>().Property(o => o.Genre).HasConversion<string>();
            modelBuilder.Entity<Ordonnance>().Property(o => o.TypeO).HasConversion<string>();
        }
    }
}
