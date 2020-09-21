using Clinique.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clinique.Domain.Models
{
    public class Utilisateur : DomainObject
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email non valide")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Mot de passe")]
        public string HashPassword { get; set; }
        [Display(Name = "Compte")]
        public TypeCompte TypeCompte { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
