using Clinique.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Services
{
    public interface ICoronavirusCountryService
    {
        Task<IEnumerable<CoronavirusCountry>> GetTopCases(int amountOfCountries);
    }
}
