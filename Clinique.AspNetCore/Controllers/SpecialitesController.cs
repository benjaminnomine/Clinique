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
        private readonly CliniqueDbContext _context;

        public SpecialitesController(CliniqueDbContext context)
        {
            _context = context;
        }

        // GET: Specialites
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specialites.ToListAsync());
        }

        // GET: Specialites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialite = await _context.Specialites
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
                _context.Add(specialite);
                await _context.SaveChangesAsync();
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

            var specialite = await _context.Specialites.FindAsync(id);
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
                    _context.Update(specialite);
                    await _context.SaveChangesAsync();
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

            var specialite = await _context.Specialites
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
            var specialite = await _context.Specialites.FindAsync(id);
            _context.Specialites.Remove(specialite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialiteExists(int id)
        {
            return _context.Specialites.Any(e => e.Id == id);
        }
    }
}
