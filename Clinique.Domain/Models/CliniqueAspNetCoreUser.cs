using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Clinique.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Clinique.Domain.Models
{
    // Add profile data for application users by adding properties to the CliniqueAspNetCoreUser class
    public class CliniqueAspNetCoreUser : IdentityUser
    {
        //[Key]
        //public string Id { get; set; }
        //[Required]
        //[Display(Name = "Email")]
        //[EmailAddress(ErrorMessage = "Email non valide")]
        //public string Email { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Display(Name = "Mot de passe")]
        //public string HashPassword { get; set; }
        [Required]
        [Display(Name = "Compte")]
        public TypeCompte TypeCompte { get; set; }
        //public DateTime DateJoined { get; set; }
    }
}
