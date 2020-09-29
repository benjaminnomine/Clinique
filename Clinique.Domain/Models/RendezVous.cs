using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinique.Domain.Models
{
    public class RendezVous : DomainObject
    {
        [Required]
        [Display(Name = "Sujet")]
        public string Subject { get; set; }
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Date de début")]
        public DateTime Start { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Date de fin")]
        public DateTime End { get; set; }
        [Display(Name = "Couleur du rendez-vous")]
        public string ThemeColor { get; set; }
        [Display(Name = "Journée complète")]
        public bool IsFullDay { get; set; } = false;

        [ForeignKey("Docteur")]
        public int IdDocteur { get; set; }
        public Docteur Docteur { get; set; }
        [ForeignKey("Dossierpatient")]
        public int IdDossierpatient { get; set; }
        public Dossierpatient Dossierpatient { get; set; }

    }
}
