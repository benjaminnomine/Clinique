using Clinique.AspNetCore.Models;
using Clinique.AspNetCore.State;
using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthenticator _authenticator;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IAuthenticator authenticator, IStringLocalizer<HomeController> localizer)
        {
            _authenticator = authenticator;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authentifier(Utilisateur utilisateur)
        {
            if(await _authenticator.Login(utilisateur.Name, utilisateur.HashPassword))
            {
                HttpContext.Session.SetString("nom", utilisateur.Name);
                if(utilisateur.TypeCompte == TypeCompte.Docteur)
                {
                    return RedirectToAction("", "");
                }
                else if(utilisateur.TypeCompte == TypeCompte.Secretaire)
                {
                    return RedirectToAction("","");
                }
            }
            return View("Index",utilisateur);
        }

        public IActionResult Register()
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
