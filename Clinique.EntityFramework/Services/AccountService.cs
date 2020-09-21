//using Clinique.Domain.Models;
//using Clinique.EntityFramework;
//using Clinique.EntityFramework.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Clinique.Domain.Services
//{
//    public class AccountService : IAccountService
//    {
//        private readonly CliniqueDbContextFactory _contextFactory;
//        //private readonly NonQueryDataService<Utilisateur> _nonQueryDataService;

//        public AccountService(CliniqueDbContextFactory contextFactory)
//        {
//            _contextFactory = contextFactory;
//            //_nonQueryDataService = new NonQueryDataService<Utilisateur>(contextFactory);
//        }

//        public async Task<Utilisateur> Create(Utilisateur entity)
//        {
//            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                EntityEntry<Utilisateur> createdResult = await context.Set<Utilisateur>().AddAsync(entity);
//                await context.SaveChangesAsync();

//                return createdResult.Entity;
//            }
//        }

//        public async Task<bool> Delete(int id)
//        {
//            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                Utilisateur entity = await context.Set<Utilisateur>().FirstOrDefaultAsync((e) => e.Id == id);
//                context.Set<Utilisateur>().Remove(entity);
//                await context.SaveChangesAsync();

//                return true;
//            }
//        }

//        public async Task<Utilisateur> Get(int id)
//        {
//            using(CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                Utilisateur utilisateur = await context.Set<Utilisateur>().FirstOrDefaultAsync(e => e.Id == id);
//                return utilisateur;
//            }
//        }

//        public async Task<IEnumerable<Utilisateur>> GetAll()
//        {
//            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                IEnumerable<Utilisateur> utilisateurs = await context.Set<Utilisateur>().ToListAsync();
//                return utilisateurs;
//            }
//        }

//        public async Task<Utilisateur> GetByEmail(string email)
//        {
//            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                return await context.Set<Utilisateur>().FirstOrDefaultAsync(u => u.Email.Equals(email));
//            }
//        }

//        public async Task<Utilisateur> GetByUsername(string username)
//        {
//            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                return await context.Set<Utilisateur>().FirstOrDefaultAsync(u => u.Name.Equals(username));
//            }
//        }

//        public async Task<Utilisateur> Update(int id, Utilisateur entity)
//        {
//            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
//            {
//                entity.Id = id;

//                context.Set<Utilisateur>().Update(entity);
//                await context.SaveChangesAsync();

//                return entity;
//            }
//        }
//    }
//}
