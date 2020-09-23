using System;
using System.Collections.Generic;
using System.Text;

namespace Clinique.Domain.Models
{
    public class CovidCountry
    {
        public string CountryName { get; set; }
        public IEnumerable<string> Dates { get; set; }
        public IEnumerable<int> Cases { get; set; }
        public IEnumerable<int> Deaths { get; set; }
    }
}
