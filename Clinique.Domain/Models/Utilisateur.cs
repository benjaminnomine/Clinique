using Clinique.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinique.Domain.Models
{
    public class Utilisateur : DomainObject
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string HashPassword { get; set; }
        public TypeCompte TypeCompte { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
