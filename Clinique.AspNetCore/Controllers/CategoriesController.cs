using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public CategoriesController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _contextFactory.CreateDbContext().Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _contextFactory.CreateDbContext().Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Description,Id")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _contextFactory.CreateDbContext().Add(categorie);
                await _contextFactory.CreateDbContext().SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _contextFactory.CreateDbContext().Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nom,Description,Id")] Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contextFactory.CreateDbContext().Update(categorie);
                    await _contextFactory.CreateDbContext().SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.Id))
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
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _contextFactory.CreateDbContext().Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorie = await _contextFactory.CreateDbContext().Categories.FindAsync(id);
            _contextFactory.CreateDbContext().Categories.Remove(categorie);
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _contextFactory.CreateDbContext().Categories.Any(e => e.Id == id);
        }
    }
}
