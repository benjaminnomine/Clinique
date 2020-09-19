using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Services
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthentificationService
    {
        Task<RegistrationResult> Register(string email, string username, TypeCompte typeCompte , string password, string confirmpassword);
        Task<Utilisateur> Login(string username, string password);
    }
}
