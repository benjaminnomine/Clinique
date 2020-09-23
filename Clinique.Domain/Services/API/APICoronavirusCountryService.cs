using Clinique.Domain.Models;
using Clinique.Domain.Services.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Clinique.Domain.Services.API
{
    public class APICoronavirusCountryService : ICoronavirusCountryService
    {
        public async Task<IEnumerable<CoronavirusCountry>> GetTopCases(int amountOfCountries)
        {
            using(HttpClient client = new HttpClient())
            {
                string requestUri = "https://corona.lmao.ninja/v3/covid-19/countries?sort=cases";

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                List<APICoronavirusCountry> apiCountries = System.Text.Json.JsonSerializer.Deserialize<List<APICoronavirusCountry>>(jsonResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiCountries.Take(amountOfCountries).Select(apiCountry => new CoronavirusCountry()
                {
                    CountryName = apiCountry.Country,
                    CaseCount = apiCountry.Cases,
                    DeathCount = apiCountry.Deaths,
                    FlagUri = apiCountry.CountryInfo.Flag
                });
            }
        }

        public async Task<CovidCountry> GetHistoryCountry(string country)
        {
            using(HttpClient client = new HttpClient())
            {
                string requestUri = "https://disease.sh/v3/covid-19/historical/" + country + "?lastdays=all";

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                APICountry aPICountry = JsonConvert.DeserializeObject<APICountry>(jsonResponse);

                List<string> dateTimes = new List<string>();
                List<int> cases = new List<int>();
                List<int> deaths = new List<int>();
                foreach(KeyValuePair<string, int> date in aPICountry.Timeline.Cases)
                {
                    //TODO A faire en revenant sur du DateTime!
                    //dateTimes.Add(DateTime.ParseExact(date.Key, "M/d/yy", System.Globalization.CultureInfo.InvariantCulture));
                    dateTimes.Add(date.Key);
                    cases.Add(date.Value);
                }
                foreach(KeyValuePair<string, int> date in aPICountry.Timeline.Deaths)
                {
                    deaths.Add(date.Value);
                }

                return new CovidCountry() { CountryName = aPICountry.Country, Dates = dateTimes , Cases = cases, Deaths = deaths };
            }
        }
    }
}
