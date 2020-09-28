using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDossier"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet");
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet");

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
                patient = rdv.Dossierpatient.NomComplet,
                docteur = rdv.Docteur.NomComplet,
            });

            return new JsonResult(events);
        }

        // GET: RendezVous/Create
        public IActionResult Create()
        {
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet");
            ViewData["IdDossier"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet");
            return View();
        }

        public ActionResult PartialModal()
        {
            return PartialView("_ModalRendezVousPartial", new RendezVous { Start = DateTime.Now });
        }

        // POST: Secretaire/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject,Description,Start,End,ThemeColor,IdDocteur,IdDossierpatient,Id")] RendezVous rendezVous)
        {
            rendezVous.IsFullDay = false;
            if (ModelState.IsValid)
            {
                CliniqueDbContext context = _contextFactory.CreateDbContext();
                context.Add(rendezVous);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet", rendezVous.IdDocteur);
            ViewData["IdDossier"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet", rendezVous.IdDossierpatient);
            return View(rendezVous);
        }
        // GET: RendezVous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _contextFactory.CreateDbContext().RendezVous.FindAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet", rendezVous.IdDocteur);
            ViewData["IdDossier"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet", rendezVous.IdDossierpatient);
            return PartialView("_ModalRendezVousPartial", rendezVous);
        }
        public IActionResult CreatePartial(string date)
        {
            ViewData["DateEvent"] = date;
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet");
            ViewData["IdDossier"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet");
            return PartialView("_CreateRendezVousPartial");
        }
        // POST: RendezVous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subject,Description,Start,End,ThemeColor,IdDocteur,IdDossierpatient,Id")] RendezVous rendezVous)
        {
            if (id != rendezVous.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CliniqueDbContext context = _contextFactory.CreateDbContext();
                    context.Update(rendezVous);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendezVousExists(rendezVous.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet", rendezVous.IdDocteur);
            ViewData["IdDossier"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet", rendezVous.IdDossierpatient);
            return View(rendezVous);
        }

        // GET: RendezVous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _contextFactory.CreateDbContext().RendezVous
                .Include(r => r.Docteur)
                .Include(r => r.Dossierpatient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet", rendezVous.IdDocteur);
            ViewData["IdDossierpatient"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet", rendezVous.IdDossierpatient);
            return View(rendezVous);
        }

        // POST: RendezVous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CliniqueDbContext context = _contextFactory.CreateDbContext();
            var rendezVous = await context.RendezVous.FindAsync(id);
            context.RendezVous.Remove(rendezVous);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezVousExists(int id)
        {
            return _contextFactory.CreateDbContext().RendezVous.Any(e => e.Id == id);
        }
    }
}
