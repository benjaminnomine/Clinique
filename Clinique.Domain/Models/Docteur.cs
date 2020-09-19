using Clinique.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique.Domain.Models
{
    public class Docteur : DomainObject
    {
        public int Matricule { get; set; }
        public string NomM { get; set; }
        public string PrenomM { get; set; }
        [ForeignKey("Specialite")]
        public int IdSpecialite { get; set; }
        public Specialite Specialite { get; set; }
        public string Ville { get; set; }
        public string Adresse { get; set; }
        public Niveau Niveau { get; set; }
        public int NbrPatients { get; set; }

        public virtual ICollection<RendezVous> RendezVous { get;set;}
        public virtual ICollection<Consultation> Consultations { get;set;}
        public virtual ICollection<Dossierpatient> Dossierspatients { get; set; }

        public Docteur()
        {

        }

        public Docteur(string nomM, string prenomM, string ville, string adresse, Niveau niveau, int nbrPatients)
        {
            NomM = nomM;
            PrenomM = prenomM;
            Ville = ville;
            Adresse = adresse;
            Niveau = niveau;
            NbrPatients = nbrPatients;
        }
    }
}
