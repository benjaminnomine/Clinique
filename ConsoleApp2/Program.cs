using Clinique.Domain.Models;
using Clinique.Domain.Enums;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Clinique.EntityFramework.Services;
using Clinique.Domain.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Clinique.AspNetCore.Models;
using Clinique.Domain.Services.API;
using System.Collections.Generic;
using System.Linq;
using Clinique.EntityFramework.Seed;

namespace ConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            APICoronavirusCountryService coronavirusCountryService = new APICoronavirusCountryService();
            CovidCountry result = await coronavirusCountryService.GetHistoryCountry("CANADA");

            Console.ReadLine();
        }
    }
}
