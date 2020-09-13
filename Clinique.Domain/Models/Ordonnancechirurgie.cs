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
        public int NumOrd { get; set; }
        public int Rang { get; set; }
        public string NomChirurgie { get; set; }
        public Ordonnance Ordonnance { get; set; }

        public Ordonnancechirurgie()
        {

        }

        public Ordonnancechirurgie(int numOrd, int rang, string nomChirurgie)
        {
            NumOrd = numOrd;
            Rang = rang;
            NomChirurgie = nomChirurgie;
        }
    }
}
