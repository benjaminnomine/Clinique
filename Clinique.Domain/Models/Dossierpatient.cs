using Clinique.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique.Domain.Models
{

    public class Dossierpatient : DomainObject
    {
        public string NomP { get; set; }
        public string PrenomP { get; set; }
        public Genre Genre { get; set; }
        public int NumAS { get; set; }
        public DateTime DateNaiss { get; set; }
        public DateTime DateC { get; set; }
        [ForeignKey("Docteur")]
        public int IdDocteur { get; set; }
        public Docteur Docteur { get; set; }

        public virtual ICollection<Consultation> Consultations { get;set;}
        public virtual ICollection<RendezVous> RendezVous { get; set; }

        //public Dossierpatient()
        //{

        //}

        //public Dossierpatient(string nomP, string prenomP, Genre genre, int numAS, DateTime dateNaiss, DateTime dateC)
        //{
        //    NomP = nomP;
        //    PrenomP = prenomP;
        //    Genre = genre;
        //    NumAS = numAS;
        //    DateNaiss = dateNaiss;
        //    DateC = dateC;
        //}

        //public Dossierpatient(string nomP, string prenomP, Genre genre, int numAS, DateTime dateNaiss)
        //{
        //    NomP = nomP;
        //    PrenomP = prenomP;
        //    Genre = genre;
        //    NumAS = numAS;
        //    DateNaiss = dateNaiss;
        //    DateC = DateTime.Now;
        //}
    }
}
