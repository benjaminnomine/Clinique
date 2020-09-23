using Clinique.Domain.Models;
using Clinique.Domain.Services.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinique.Domain.Services
{
    public interface ICoronavirusCountryService
    {
        Task<IEnumerable<CoronavirusCountry>> GetTopCases(int amountOfCountries);
        Task<CovidCountry> GetHistoryCountry(string country);
    }
}
