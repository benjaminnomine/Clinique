using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Clinique.Domain.Enums;

namespace Clinique.AspNetCore.Controllers
{
    public class RendezVousController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public RendezVousController(CliniqueDbContextFactory context)
        {
            _contextFactory = context;
        }

        // GET: RendezVous
        public async Task<IActionResult> Index()
        {
            var cliniqueDbContext = _contextFactory.CreateDbContext().RendezVous.Include(r => r.Docteur).Include(r => r.Dossierpatient);
            return View(await cliniqueDbContext.ToListAsync());
        }

        // GET: RendezVous/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(rendezVous);
        }

        // GET: RendezVous/Create
        public IActionResult Create()
        {
            ViewData["Couleurs"] = Couleur.CreerSelectList();
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomComplet");
            ViewData["IdDossierpatient"] = new SelectList(_contextFactory.CreateDbContext().Dossierpatients, "Id", "NomComplet");
            return View();
        }

        // POST: RendezVous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Subject,Description,Start,End,ThemeColor,IdDocteur,IdDossierpatient,Id")] RendezVous rendezVous)
        {
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
            return View(rendezVous);
        }

        // POST: RendezVous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Subject,Description,Start,End,ThemeColor,IsFullDay,IdDocteur,IdDossierpatient,Id")] RendezVous rendezVous)
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
