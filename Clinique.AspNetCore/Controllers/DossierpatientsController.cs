using Clinique.Domain.Enums;
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
    public class DossierpatientsController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public DossierpatientsController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: Dossierpatients
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NumAsSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var patients = from s in _contextFactory.CreateDbContext().Dossierpatients.Include(d => d.Docteur) select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.NomP.Contains(searchString)
                                       || s.PrenomP.Contains(searchString));
            }
            patients = sortOrder switch
            {
                "id_desc" => patients.OrderByDescending(s => s.NumAS),
                "Date" => patients.OrderBy(s => s.DateNaiss),
                "date_desc" => patients.OrderByDescending(s => s.DateNaiss),
                _ => patients.OrderBy(s => s.NumAS),
            };
            int pageSize = 8;
            return View(await PaginatedList<Dossierpatient>.CreateAsync(patients.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Dossierpatients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierpatient = await _contextFactory.CreateDbContext().Dossierpatients
                .Include(d => d.Docteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dossierpatient == null)
            {
                return NotFound();
            }

            return View(dossierpatient);
        }

        // GET: Dossierpatients/Create
        public IActionResult Create()
        {
            ViewData["Genre"] = new SelectList(Enum.GetNames(typeof(Genre)));
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomM");
            return View();
        }

        // POST: Dossierpatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomP,PrenomP,Genre,NumAS,DateNaiss,DateC,IdDocteur,Id")] Dossierpatient dossierpatient)
        {
            if (ModelState.IsValid)
            {
                CliniqueDbContext context = _contextFactory.CreateDbContext();
                context.Add(dossierpatient);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Genre"] = new SelectList(Enum.GetNames(typeof(Genre)));
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomM", dossierpatient.IdDocteur);
            return View(dossierpatient);
        }

        // GET: Dossierpatients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierpatient = await _contextFactory.CreateDbContext().Dossierpatients.FindAsync(id);
            if (dossierpatient == null)
            {
                return NotFound();
            }
            ViewData["Genre"] = new SelectList(Enum.GetNames(typeof(Genre)));
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomM", dossierpatient.IdDocteur);
            return View(dossierpatient);
        }

        // POST: Dossierpatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomP,PrenomP,Genre,NumAS,DateNaiss,DateC,IdDocteur,Id")] Dossierpatient dossierpatient)
        {
            if (id != dossierpatient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CliniqueDbContext context = _contextFactory.CreateDbContext();
                    context.Update(dossierpatient);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DossierpatientExists(dossierpatient.Id))
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
            ViewData["Genre"] = new SelectList(Enum.GetNames(typeof(Genre)));
            ViewData["IdDocteur"] = new SelectList(_contextFactory.CreateDbContext().Docteurs, "Id", "NomM", dossierpatient.IdDocteur);
            return View(dossierpatient);
        }

        // GET: Dossierpatients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dossierpatient = await _contextFactory.CreateDbContext().Dossierpatients
                .Include(d => d.Docteur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dossierpatient == null)
            {
                return NotFound();
            }

            return View(dossierpatient);
        }

        // POST: Dossierpatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            CliniqueDbContext context = _contextFactory.CreateDbContext();
            var dossierpatient = await context.Dossierpatients.FindAsync(id);
            context.Dossierpatients.Remove(dossierpatient);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DossierpatientExists(int id)
        {
            return _contextFactory.CreateDbContext().Dossierpatients.Any(e => e.Id == id);
        }
    }
}
