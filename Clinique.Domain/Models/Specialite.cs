using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class Specialite : DomainObject
    {
        public string Titre { get; set; }
        public string Description { get; set; }

        public Specialite()
        {

        }

        public Specialite(string titre, string description)
        {
            Titre = titre;
            Description = description;
        }
    }
}
