using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clinique.Domain.Models
{
    public class DomainObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;set;}
    }
}
