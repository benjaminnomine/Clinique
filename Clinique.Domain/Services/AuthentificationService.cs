using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher<Utilisateur> _passwordHasher;

        public AuthentificationService(IAccountService accountService, IPasswordHasher<Utilisateur> passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<Utilisateur> Login(string username, string password)
        {
            Utilisateur storedAccount = await _accountService.GetByUsername(username);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount, storedAccount.HashPassword, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string email, string username, TypeCompte typeCompte ,string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            Utilisateur emailAccount = await _accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            Utilisateur usernameAccount = await _accountService.GetByUsername(username);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(usernameAccount, password);

                Utilisateur utilisateur = new Utilisateur()
                {
                    Email = email,
                    Name = username,
                    HashPassword = hashedPassword,
                    DateJoined = DateTime.Now,
                    TypeCompte = typeCompte
                };


                await _accountService.Create(utilisateur);
            }

            return result;
        }
    }
}