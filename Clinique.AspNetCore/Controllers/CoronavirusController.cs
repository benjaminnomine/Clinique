using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinique.AspNetCore.Models;
using Clinique.Domain.Models;
using Clinique.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clinique.AspNetCore.Controllers
{
    public class CoronavirusController : Controller
    {
        private readonly ICoronavirusCountryService _coronavirusCountryService;

        public CoronavirusController(ICoronavirusCountryService coronavirusCountryService)
        {
            _coronavirusCountryService = coronavirusCountryService;
        }

        public IActionResult Index()
        {
            return View(_coronavirusCountryService.GetTopCases(10).Result.ToList());
        }
    }
}
