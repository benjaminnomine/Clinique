using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Clinique.AspNetCore.Controllers
{
    public class DocteurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
