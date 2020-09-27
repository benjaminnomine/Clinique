using Clinique.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinique.EntityFramework
{
    public class CliniqueDbContext : IdentityDbContext
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
        public DbSet<RendezVous> RendezVous { get;set;}
        public DbSet<CliniqueAspNetCoreUser> CliniqueAspNetCoreUsers { get; set; }

        public CliniqueDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Docteur>().Property(o => o.Niveau).HasConversion<string>();
            modelBuilder.Entity<Dossierpatient>().Property(o => o.Genre).HasConversion<string>();
            modelBuilder.Entity<Ordonnance>().Property(o => o.TypeO).HasConversion<string>();
            modelBuilder.Entity<CliniqueAspNetCoreUser>().Property(c => c.TypeCompte).HasConversion<string>();

            modelBuilder.Entity<Consultation>().HasAlternateKey(c => new { c.IdDocteur, c.IdDossierpatient, c.DateC});
            //modelBuilder.Entity<Consultation>().HasOne<Docteur>().WithMany(d => d.Consultations).HasForeignKey(c => c.IdDocteur).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Consultation>().HasOne<Dossierpatient>().WithMany(d => d.Consultations).HasForeignKey(c => c.IdDossierpatient).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<RendezVous>().HasAlternateKey(r => new { r.Start, r.IdDocteur, r.IdDossierpatient});
            //modelBuilder.Entity<RendezVous>().HasOne<Docteur>().WithMany(d => d.RendezVous).HasForeignKey(r => r.IdDocteur).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<RendezVous>().HasOne<Dossierpatient>().WithMany(d => d.RendezVous).HasForeignKey(r => r.IdDossierpatient).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
