using Clinique.Domain.Models;
using Clinique.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique.Domain.Models
{
    public class CoronavirusResults
    {
        private const int AMOUNT_OF_COUNTRIES = 10;

        private readonly ICoronavirusCountryService _coronavirusCountryService;

        public int[] CoronavirusCountryCaseCounts { get;set;}

        public string[] CoronavirusCountryNames { get; set;}

        public CoronavirusResults(ICoronavirusCountryService coronavirusCountryService)
        {
            _coronavirusCountryService = coronavirusCountryService;

            CoronavirusCountryNames = null;
            CoronavirusCountryCaseCounts = null;
        }

        public static CoronavirusResults Factory(ICoronavirusCountryService coronavirusCountryService, Action<Task> onLoaded = null)
        {
            CoronavirusResults coronavirusResults = new CoronavirusResults(coronavirusCountryService);

            coronavirusResults.Load().ContinueWith(t => onLoaded?.Invoke(t));

            return coronavirusResults;
        }

        public async Task Load()
        {
            IEnumerable<CoronavirusCountry> countries = await _coronavirusCountryService.GetTopCases(AMOUNT_OF_COUNTRIES);

            CoronavirusCountryCaseCounts = new List<int>(countries.Select(c => c.CaseCount)).ToArray();
            CoronavirusCountryNames = new List<string>(countries.Select(c => c.CountryName)).ToArray();
        }
    }
}
