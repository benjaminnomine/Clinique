using Clinique.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique.Domain.Models
{
    public class Docteur : DomainObject
    {
        [Display(Name = "Matricule")]
        public int Matricule { get; set; }
        [Display(Name = "Nom")]
        public string NomM { get; set; }
        [Display(Name = "Prenom")]
        public string PrenomM { get; set; }
        [ForeignKey("Specialite")]
        public int IdSpecialite { get; set; }
        [Display(Name = "Specialite")]
        public Specialite Specialite { get; set; }
        [Display(Name = "Ville")]
        public string Ville { get; set; }
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }
        [Display(Name = "Niveau")]
        public Niveau Niveau { get; set; }
        [Display(Name = "Nombre de patients")]
        public int NbrPatients { get; set; }
        [NotMapped]
        [Display(Name = "Nom Docteur")]
        public string NomComplet { get
            {
                return NomM + " " + PrenomM;
            }
        }
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
