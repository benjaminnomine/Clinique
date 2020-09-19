using Clinique.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Services
{
    public interface IAccountService : IDataService<Utilisateur>
    {
        Task<Utilisateur> GetByUsername(string username);
        Task<Utilisateur> GetByEmail(string email);
    }
}
