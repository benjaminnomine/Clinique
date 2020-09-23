namespace Clinique.Domain.Services.API.Models
{
    public class APICoronavirusCountry
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Deaths { get; set; }
        public APICoronavirusCountryInfo CountryInfo { get; set; }
    }
}