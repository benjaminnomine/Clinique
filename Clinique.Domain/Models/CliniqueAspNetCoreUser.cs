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
        [Required]
        [Display(Name = "Compte")]
        public TypeCompte TypeCompte { get; set; }
    }
}
