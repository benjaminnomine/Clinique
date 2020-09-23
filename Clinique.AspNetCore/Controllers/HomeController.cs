using Clinique.AspNetCore.Models;

using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using Clinique.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IAuthenticator _authenticator;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ICoronavirusCountryService _coronavirusCountryService;

        //public HomeController(IAuthenticator authenticator, IStringLocalizer<HomeController> localizer)
        public HomeController(IStringLocalizer<HomeController> localizer, ICoronavirusCountryService coronavirusCountryService)
        {
            //_authenticator = authenticator;
            _localizer = localizer;
            _coronavirusCountryService = coronavirusCountryService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            CovidCountry country = await _coronavirusCountryService.GetHistoryCountry("CANADA");
            return View(country);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
