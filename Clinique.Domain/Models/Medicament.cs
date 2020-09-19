using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class Medicament : DomainObject
    {
        public string NomMed { get; set; }
        public double Prix { get; set; }
        [ForeignKey("Categorie")]
        public int IdCategorie { get; set; }
        public Categorie Categorie { get; set; }

        public virtual ICollection<Ordonnancemedicament> Ordonnancemedicaments { get;set;}

        public Medicament()
        {

        }

        public Medicament(string nomMed, double prix = 0)
        {
            NomMed = nomMed;
            Prix = prix;
        }
    }
}
