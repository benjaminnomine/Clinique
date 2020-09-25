using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Clinique.AspNetCore.Controllers
{
    public class SecretaireController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly CliniqueDbContextFactory _contextFactory;

        public SecretaireController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            var events = _contextFactory.CreateDbContext().RendezVous.Include(d => d.Docteur).Include(d => d.Dossierpatient).Select(rdv => new
            {
                eventid = rdv.Id,
                title = rdv.Subject,
                description = rdv.Description,
                start = rdv.Start,
                end = rdv.End,
                color = rdv.ThemeColor,
                allDay = rdv.IsFullDay,
                patient = rdv.Dossierpatient.NomP,
                docteur = rdv.Docteur.NomM,
            });

            return new JsonResult(events);
        }

        [HttpPost]
        public JsonResult SaveEvent(RendezVous e)
        {
            var status = false;
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                if (e.Id > 0)
                {
                    //Update the event
                    var v = context.RendezVous.Where(a => a.Id == e.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.DateRdv = e.Start;
                        v.End = e.End;
                        v.DateFin = e.DateFin;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                        v.Duree = 0;
                        v.IdDocteur = e.IdDocteur;
                        v.IdDossierpatient = e.IdDossierpatient;
                    }
                }
                else
                {
                    context.Add(e);
                }
                context.SaveChangesAsync().Wait();
                status = true;
            }
            return new JsonResult(status);
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (CliniqueDbContext context = _contextFactory.CreateDbContext())
            {
                var v = context.RendezVous.Where(a => a.Id == eventID).FirstOrDefault();
                if (v != null)
                {
                    context.RendezVous.Remove(v);
                    context.SaveChangesAsync().Wait();
                    status = true;
                }
            }
            return new JsonResult(status);
        }

    }
}
