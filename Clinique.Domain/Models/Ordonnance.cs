using Clinique.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique.Domain.Models
{
    public class Ordonnance : DomainObject
    {
        public int NumOrd { get; set; }
        public string Recommandations { get; set; }
        public TypeO TypeO { get; set; }
        public DateTime DateC { get; set; }

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
