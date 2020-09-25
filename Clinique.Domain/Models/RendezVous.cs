using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clinique.Domain.Models
{
    public class RendezVous : DomainObject
    {
        public DateTime DateRdv { get; set; }
        public double Duree { get; set; }
        public DateTime DateFin { get; set; }

        [ForeignKey("Docteur")]
        public int IdDocteur { get;set;}
        public Docteur Docteur { get; set; }
        [ForeignKey("Dossierpatient")]
        public int IdDossierpatient { get; set; }
        public Dossierpatient Dossierpatient { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }

        public RendezVous()
        {

        }

        public RendezVous(DateTime dateRdv, double duree)
        {
            DateRdv = dateRdv;
            Duree = duree;
            DateFin = dateRdv.AddHours(duree);
        }
    }
}
