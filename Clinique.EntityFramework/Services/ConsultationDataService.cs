using Clinique.Domain.Models;
using Clinique.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clinique.EntityFramework.Services
{
    public class ConsultationDataService : IDataService<Consultation>
    {
        private readonly CliniqueDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Consultation> _nonQueryDataService;

        public ConsultationDataService(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Consultation>(contextFactory);
        }

        public async Task<Consultation> Create(Consultation entity)
        {
            return await _nonQueryDataService.Create(entity);
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

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Consultation> Get(DateTime datec, int iddocteur, int iddossierpatient)
        {
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                Consultation entity = await context.Set<Consultation>().FirstOrDefaultAsync((e) => e.IdDocteur == iddocteur && e.IdDossierpatient == iddossierpatient && e.DateC == datec);
                return entity;
            }
        }

        public async Task<Consultation> Get(int id)
        {
            using(CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Set<Consultation>().FirstOrDefaultAsync((e) => e.Id == id);
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

        public async Task<Consultation> Update(int id, Consultation entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
