using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class Ordonnancechirurgie : DomainObject
    {
        [Display(Name = "Rang")]
        public int Rang { get; set; }
        [Display(Name = "Chirurgie")]
        public string NomChirurgie { get; set; }
        [ForeignKey("Ordonnance")]
        public int IdOrdonnance { get;set;}
        [Display(Name = "Ordonnance")]
        public Ordonnance Ordonnance { get; set; }

        public Ordonnancechirurgie()
        {

        }

        public Ordonnancechirurgie(int rang, string nomChirurgie)
        {
            Rang = rang;
            NomChirurgie = nomChirurgie;
        }
    }
}
