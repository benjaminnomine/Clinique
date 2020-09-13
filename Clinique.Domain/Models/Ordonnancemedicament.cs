using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class Ordonnancemedicament : DomainObject
    {
        public int NumOrd { get; set; }
        public int IdMed { get; set; }
        public int NbBoites { get; set; }
        public Ordonnance Ordonnance { get; set; }
        public Medicament Medicament { get;set;}

        public Ordonnancemedicament()
        {

        }

        public Ordonnancemedicament(int numOrd, int idmed, int nbboites)
        {
            NumOrd = numOrd;
            IdMed = idmed;
            NbBoites = nbboites;
        }
    }
}
