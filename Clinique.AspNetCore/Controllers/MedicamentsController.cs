using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var cliniqueDbContext = _contextFactory.CreateDbContext().Medicaments.Include(m => m.Categorie);
            return View(await cliniqueDbContext.ToListAsync());
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
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Id");
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
                _contextFactory.CreateDbContext().Add(medicament);
                await _contextFactory.CreateDbContext().SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Id", medicament.IdCategorie);
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
            ViewData["IdCategorie"] = new SelectList(_contextFactory.CreateDbContext().Categories, "Id", "Id", medicament.IdCategorie);
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
                    _contextFactory.CreateDbContext().Update(medicament);
                    await _contextFactory.CreateDbContext().SaveChangesAsync();
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
            var medicament = await _contextFactory.CreateDbContext().Medicaments.FindAsync(id);
            _contextFactory.CreateDbContext().Medicaments.Remove(medicament);
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentExists(int id)
        {
            return _contextFactory.CreateDbContext().Medicaments.Any(e => e.Id == id);
        }
    }
}
