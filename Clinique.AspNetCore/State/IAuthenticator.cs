//using Clinique.Domain.Enums;
//using Clinique.Domain.Models;
//using Clinique.Domain.Services;
//using System;
//using System.Threading.Tasks;

//namespace Clinique.AspNetCore.State
//{
//    public interface IAuthenticator
//    {
//        Utilisateur CurrentUtilisateur { get; }
//        bool IsLoggedIn { get; }

//        event Action StateChanged;

//        Task<RegistrationResult> Register(string email, string username,TypeCompte typeCompte ,string password, string confirmPassword);

//        Task<bool> Login(string username, string password);

//        void Logout();
//    }
//}
