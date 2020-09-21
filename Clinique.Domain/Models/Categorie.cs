using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class Categorie : DomainObject
    {
        [Display(Name = "Nom")]
        public string Nom { get; set; }
        [Display(Name = "Description")]
        public string Description { get;set;}

        public virtual ICollection<Medicament> Medicaments { get;set;}

        public Categorie()
        {

        }

        public Categorie(string nom, string description)
        {
            Nom = nom;
            Description = description;
        }
    }
}
