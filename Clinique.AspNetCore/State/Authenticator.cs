using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using Clinique.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.State
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthentificationService _authentificationService;

        public Authenticator(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }

        public Utilisateur CurrentUtilisateur { get;set;}

        public bool IsLoggedIn => CurrentUtilisateur != null;

        public event Action StateChanged;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;

            try {
                CurrentUtilisateur = await _authentificationService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;

        }

        public void Logout()
        {
            CurrentUtilisateur = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, TypeCompte typeCompte ,string password, string confirmPassword)
        {
            return await _authentificationService.Register(email, username, typeCompte,password, confirmPassword);
        }
    }
}
