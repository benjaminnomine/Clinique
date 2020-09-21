using System;
using System.Collections.Generic;
using System.Text;

namespace Clinique.Domain.Models
{
    public class CoronavirusCountry
    {
        public string CountryName { get; set; }
        public int CaseCount { get; set; }
        public string FlagUri { get; set; }
    }
}
