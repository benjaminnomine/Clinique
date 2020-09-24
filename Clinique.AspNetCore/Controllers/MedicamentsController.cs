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
    public class MedicamentsController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public MedicamentsController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: Medicaments
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NomSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : "";
            ViewData["PrixSortParm"] = sortOrder == "Prix" ? "prix_desc" : "Prix";
            ViewData["CatSortParm"] = sortOrder == "Categorie" ? "cat_desc" : "Categorie";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var medicaments = from s in _contextFactory.CreateDbContext().Medicaments.Include(d => d.Categorie) select s;

            switch (sortOrder)
            {
                case "nom_desc":
                    medicaments = medicaments.OrderByDescending(s => s.NomMed);
                    break;
                case "Prix":
                    medicaments = medicaments.OrderBy(s => s.Prix);
                    break;
                case "prix_desc":
                    medicaments = medicaments.OrderByDescending(s => s.Prix);
                    break;
                case "Categorie":
                    medicaments = medicaments.OrderBy(s => s.Categorie);
                    break;
                case "cat_desc":
                    medicaments = medicaments.OrderByDescending(s => s.Categorie);
                    break;
                default:
                    medicaments = medicaments.OrderBy(s => s.NomMed);
                    break;
            }
            int pageSize = 8;
            return View(await PaginatedList<Medicament>.CreateAsync(medicaments.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Medicaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _contextFactory.CreateDbContext().Medicaments
                .Include(m => m.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        // GET: Medicaments/Create
        public IActionResult Create()
        {
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Nom");
            return View();
        }

        // POST: Medicaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomMed,Prix,IdCategorie,Id")] Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                CliniqueDbContext context = _contextFactory.CreateDbContext();
                context.Add(medicament);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Nom", medicament.IdCategorie);
            return View(medicament);
        }

        // GET: Medicaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _contextFactory.CreateDbContext().Medicaments.FindAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Nom", medicament.IdCategorie);
            return View(medicament);
        }

        // POST: Medicaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomMed,Prix,IdCategorie,Id")] Medicament medicament)
        {
            if (id != medicament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CliniqueDbContext context = _contextFactory.CreateDbContext();
                    context.Update(medicament);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentExists(medicament.Id))
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
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Id", medicament.IdCategorie);
            return View(medicament);
        }

        // GET: Medicaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _contextFactory.CreateDbContext().Medicaments
                .Include(m => m.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        // POST: Medicaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CliniqueDbContext context = _contextFactory.CreateDbContext();
            var medicament = await context.Medicaments.FindAsync(id);
            context.Medicaments.Remove(medicament);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentExists(int id)
        {
            return _contextFactory.CreateDbContext().Medicaments.Any(e => e.Id == id);
        }
    }
}
