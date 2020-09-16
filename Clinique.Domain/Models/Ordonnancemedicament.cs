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
        public int NbBoites { get; set; }
        [ForeignKey("Ordonnance")]
        public int IdOrdonnance { get; set; }
        public Ordonnance Ordonnance { get; set; }
        [ForeignKey("Medicament")]
        public int IdMedicament { get; set; }
        public Medicament Medicament { get;set;}

        //public Ordonnancemedicament()
        //{

        //}

        //public Ordonnancemedicament(int nbboites)
        //{
        //    NbBoites = nbboites;
        //}
    }
}
