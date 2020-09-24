using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.Controllers
{
    public class SpecialitesController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public SpecialitesController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: Specialites
        public async Task<IActionResult> Index()
        {
            return View(await _contextFactory.CreateDbContext().Specialites.ToListAsync());
        }

        // GET: Specialites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialite = await _contextFactory.CreateDbContext().Specialites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialite == null)
            {
                return NotFound();
            }

            return View(specialite);
        }

        // GET: Specialites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titre,Description,Id")] Specialite specialite)
        {
            if (ModelState.IsValid)
            {
                CliniqueDbContext context = _contextFactory.CreateDbContext();
                context.Add(specialite);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialite);
        }

        // GET: Specialites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialite = await _contextFactory.CreateDbContext().Specialites.FindAsync(id);
            if (specialite == null)
            {
                return NotFound();
            }
            return View(specialite);
        }

        // POST: Specialites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titre,Description,Id")] Specialite specialite)
        {
            if (id != specialite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CliniqueDbContext context = _contextFactory.CreateDbContext();
                    context.Update(specialite);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialiteExists(specialite.Id))
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
            return View(specialite);
        }

        // GET: Specialites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialite = await _contextFactory.CreateDbContext().Specialites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialite == null)
            {
                return NotFound();
            }

            return View(specialite);
        }

        // POST: Specialites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CliniqueDbContext context = _contextFactory.CreateDbContext();
            var specialite = await context.Specialites.FindAsync(id);
            context.Specialites.Remove(specialite);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialiteExists(int id)
        {
            return _contextFactory.CreateDbContext().Specialites.Any(e => e.Id == id);
        }
    }
}
