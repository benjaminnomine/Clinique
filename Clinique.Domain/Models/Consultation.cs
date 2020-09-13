using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class Consultation : DomainObject
    {
        public int CodeDocteur { get; set; }
        public int NumDos { get; set; }
        public DateTime DateC { get; set; }
        public string Diagnostic { get; set; }
        public int NumOrd { get;set;}

        public Ordonnance Ordonnance { get;set;}
        public Docteur Docteur { get;set;}
        public Dossierpatient Dossierpatient { get;set;}

        public Consultation()
        {

        }

        public Consultation(int codeDocteur, int numDos, DateTime dateC, string diagnostic, int numOrd)
        {
            CodeDocteur = codeDocteur;
            NumDos = numDos;
            DateC = dateC;
            Diagnostic = diagnostic;
            NumOrd = numOrd;
        }
    }
}
