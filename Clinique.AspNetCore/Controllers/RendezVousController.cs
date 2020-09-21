using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Clinique.AspNetCore.Controllers
{
    public class RendezVousController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public RendezVousController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: RendezVous
        public async Task<IActionResult> Index()
        {
            return View(await _contextFactory.CreateDbContext().RendezVous.ToListAsync());
        }

        // GET: RendezVous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _contextFactory.CreateDbContext().RendezVous
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
            return View();
        }

        // POST: RendezVous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateRdv,Duree,IdDocteur,IdDossierpatient,Id")] RendezVous rendezVous)
        {
            if (ModelState.IsValid)
            {
                _contextFactory.CreateDbContext().Add(rendezVous);
                await _contextFactory.CreateDbContext().SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(rendezVous);
        }

        // POST: RendezVous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DateRdv,Duree,IdDocteur,IdDossierpatient,Id")] RendezVous rendezVous)
        {
            if (id != rendezVous.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contextFactory.CreateDbContext().Update(rendezVous);
                    await _contextFactory.CreateDbContext().SaveChangesAsync();
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
            var rendezVous = await _contextFactory.CreateDbContext().RendezVous.FindAsync(id);
            _contextFactory.CreateDbContext().RendezVous.Remove(rendezVous);
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezVousExists(int id)
        {
            return _contextFactory.CreateDbContext().RendezVous.Any(e => e.Id == id);
        }
    }
}
