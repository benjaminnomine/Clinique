using Clinique.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique.Domain.Models
{
    public class Ordonnance : DomainObject
    {
        [Display(Name = "Recommandations")]
        public string Recommandations { get; set; }
        [Display(Name = "Type ordonnance")]
        public TypeO TypeO { get; set; }
        [Display(Name = "Date creation")]
        public DateTime DateC { get; set; }

        public virtual ICollection<Ordonnancechirurgie> Ordonnancechirurgies { get;set;}
        public virtual ICollection<Ordonnancemedicament> Ordonnancemedicaments { get;set;}


        public Ordonnance()
        {

        }

        public Ordonnance(string recommandations, TypeO typeO)
        {
            Recommandations = recommandations;
            TypeO = typeO;
            DateC = DateTime.Now;
        }

        public Ordonnance(string recommandations, TypeO typeO, DateTime datec)
        {
            Recommandations = recommandations;
            TypeO = typeO;
            DateC = datec;
        }
    }
}
