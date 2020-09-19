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
        //[ForeignKey("Docteur")]
        public int IdDocteur { get; set; }
        //public Docteur Docteur { get;set;}
        //[ForeignKey("Dossierpatient")]
        public int IdDossierpatient { get; set; }
        //public Dossierpatient Dossierpatient { get;set;}
        public DateTime DateC { get; set; }
        public string Diagnostic { get; set; }

        //[ForeignKey("Ordonnance")]
        public int IdOrdonnance { get; set; }
        //public Ordonnance Ordonnance { get;set;}
        public Consultation()
        {

        }

        public Consultation(DateTime dateC, string diagnostic)
        {
            DateC = dateC;
            Diagnostic = diagnostic;
        }
    }
}
