using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinique.Domain.Models;
using Clinique.EntityFramework;

namespace Clinique.AspNetCore.Controllers
{
    public class MedicamentsController : Controller
    {
        private readonly CliniqueDbContext _context;

        public MedicamentsController(CliniqueDbContext context)
        {
            _context = context;
        }

        // GET: Medicaments
        public async Task<IActionResult> Index()
        {
            var cliniqueDbContext = _context.Medicaments.Include(m => m.Categorie);
            return View(await cliniqueDbContext.ToListAsync());
        }

        // GET: Medicaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _context.Medicaments
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
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "Id", "Id");
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
                _context.Add(medicament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "Id", "Id", medicament.IdCategorie);
            return View(medicament);
        }

        // GET: Medicaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _context.Medicaments.FindAsync(id);
            if (medicament == null)
            {
                return NotFound();
            }
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "Id", "Id", medicament.IdCategorie);
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
                    _context.Update(medicament);
                    await _context.SaveChangesAsync();
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
            ViewData["IdCategorie"] = new SelectList(_context.Categories, "Id", "Id", medicament.IdCategorie);
            return View(medicament);
        }

        // GET: Medicaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicament = await _context.Medicaments
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
            var medicament = await _context.Medicaments.FindAsync(id);
            _context.Medicaments.Remove(medicament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentExists(int id)
        {
            return _context.Medicaments.Any(e => e.Id == id);
        }
    }
}
