using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.Controllers
{
    public class DocteursController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public DocteursController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: Docteurs
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["SpecSortParm"] = sortOrder == "Specialite" ? "spec_desc" : "Specialite";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var docteurs = from s in _contextFactory.CreateDbContext().Docteurs.Include(d => d.Specialite) select s;

            switch (sortOrder)
            {
                case "id_desc":
                    docteurs = docteurs.OrderByDescending(s => s.Id);
                    break;
                case "Specialite":
                    docteurs = docteurs.OrderBy(s => s.Specialite.Titre);
                    break;
                case "spec_desc":
                    docteurs = docteurs.OrderByDescending(s => s.Specialite.Titre);
                    break;
                default:
                    docteurs = docteurs.OrderBy(s => s.Id);
                    break;
            }
            int pageSize = 8;
            return View(await PaginatedList<Docteur>.CreateAsync(docteurs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Docteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docteur = await _contextFactory.CreateDbContext().Docteurs
                .Include(d => d.Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docteur == null)
            {
                return NotFound();
            }

            return View(docteur);
        }

        // GET: Docteurs/Create
        public IActionResult Create()
        {
            ViewData["IdSpecialite"] = new SelectList(_contextFactory.CreateDbContext().Specialites, "Id", "Titre");
            return View();
        }

        // POST: Docteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricule,NomM,PrenomM,IdSpecialite,Ville,Adresse,Niveau,NbrPatients,Id")] Docteur docteur)
        {
            if (ModelState.IsValid)
            {
                CliniqueDbContext context = _contextFactory.CreateDbContext();
                context.Add(docteur);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSpecialite"] = new SelectList(_contextFactory.CreateDbContext().Specialites, "Id", "Titre", docteur.IdSpecialite);
            return View(docteur);
        }

        // GET: Docteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docteur = await _contextFactory.CreateDbContext().Docteurs.FindAsync(id);
            if (docteur == null)
            {
                return NotFound();
            }
            ViewData["IdSpecialite"] = new SelectList(_contextFactory.CreateDbContext().Specialites, "Id", "Id", docteur.IdSpecialite);
            return View(docteur);
        }

        // POST: Docteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricule,NomM,PrenomM,IdSpecialite,Ville,Adresse,Niveau,NbrPatients,Id")] Docteur docteur)
        {
            if (id != docteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CliniqueDbContext context = _contextFactory.CreateDbContext();
                    context.Update(docteur);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocteurExists(docteur.Id))
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
            ViewData["IdSpecialite"] = new SelectList(_contextFactory.CreateDbContext().Specialites, "Id", "Titre", docteur.IdSpecialite);
            return View(docteur);
        }

        // GET: Docteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docteur = await _contextFactory.CreateDbContext().Docteurs
                .Include(d => d.Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docteur == null)
            {
                return NotFound();
            }

            return View(docteur);
        }

        // POST: Docteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CliniqueDbContext context = _contextFactory.CreateDbContext();
            var docteur = await context.Docteurs.FindAsync(id);
            context.Docteurs.Remove(docteur);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocteurExists(int id)
        {
            return _contextFactory.CreateDbContext().Docteurs.Any(e => e.Id == id);
        }
    }
}
