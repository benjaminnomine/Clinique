using Clinique.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clinique.EntityFramework.Services
{
    class ConsultationDataService
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public ConsultationDataService(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Consultation> Create(Consultation entity)
        {
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<Consultation> newEntity = await context.Set<Consultation>().AddAsync(entity);
                await context.SaveChangesAsync();

                return newEntity.Entity;
            }
        }

        public async Task<bool> Delete(DateTime datec, int iddocteur, int iddossierpatient)
        {
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                Consultation entity = await context.Set<Consultation>().FirstOrDefaultAsync((e) => e.IdDocteur == iddocteur && e.IdDossierpatient == iddossierpatient && e.DateC == datec);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<Consultation> Get(DateTime datec, int iddocteur, int iddossierpatient)
        {
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                Consultation entity = await context.Set<Consultation>().FirstOrDefaultAsync((e) => e.IdDocteur == iddocteur && e.IdDossierpatient == iddossierpatient && e.DateC == datec);
                return entity;
            }
        }

        public async Task<IEnumerable<Consultation>> GetAll()
        {
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Consultation> entities = await context.Set<Consultation>().ToListAsync();
                return entities;
            }
        }

        public async Task<Consultation> Update(DateTime datec, int iddocteur, int iddossierpatient, Consultation entity)
        {
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                entity.DateC = datec;
                entity.IdDocteur = iddocteur;
                entity.IdDossierpatient = iddossierpatient;
                context.Set<Consultation>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
