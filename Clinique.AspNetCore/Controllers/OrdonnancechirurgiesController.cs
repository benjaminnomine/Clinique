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
    public class OrdonnancechirurgiesController : Controller
    {
        private readonly CliniqueDbContext _context;

        public OrdonnancechirurgiesController(CliniqueDbContext context)
        {
            _context = context;
        }

        // GET: Ordonnancechirurgies
        public async Task<IActionResult> Index()
        {
            var cliniqueDbContext = _context.Ordonnancechirurgies.Include(o => o.Ordonnance);
            return View(await cliniqueDbContext.ToListAsync());
        }

        // GET: Ordonnancechirurgies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnancechirurgie = await _context.Ordonnancechirurgies
                .Include(o => o.Ordonnance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordonnancechirurgie == null)
            {
                return NotFound();
            }

            return View(ordonnancechirurgie);
        }

        // GET: Ordonnancechirurgies/Create
        public IActionResult Create()
        {
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id");
            return View();
        }

        // POST: Ordonnancechirurgies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rang,NomChirurgie,IdOrdonnance,Id")] Ordonnancechirurgie ordonnancechirurgie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordonnancechirurgie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id", ordonnancechirurgie.IdOrdonnance);
            return View(ordonnancechirurgie);
        }

        // GET: Ordonnancechirurgies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnancechirurgie = await _context.Ordonnancechirurgies.FindAsync(id);
            if (ordonnancechirurgie == null)
            {
                return NotFound();
            }
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id", ordonnancechirurgie.IdOrdonnance);
            return View(ordonnancechirurgie);
        }

        // POST: Ordonnancechirurgies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rang,NomChirurgie,IdOrdonnance,Id")] Ordonnancechirurgie ordonnancechirurgie)
        {
            if (id != ordonnancechirurgie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordonnancechirurgie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdonnancechirurgieExists(ordonnancechirurgie.Id))
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
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id", ordonnancechirurgie.IdOrdonnance);
            return View(ordonnancechirurgie);
        }

        // GET: Ordonnancechirurgies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnancechirurgie = await _context.Ordonnancechirurgies
                .Include(o => o.Ordonnance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordonnancechirurgie == null)
            {
                return NotFound();
            }

            return View(ordonnancechirurgie);
        }

        // POST: Ordonnancechirurgies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordonnancechirurgie = await _context.Ordonnancechirurgies.FindAsync(id);
            _context.Ordonnancechirurgies.Remove(ordonnancechirurgie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdonnancechirurgieExists(int id)
        {
            return _context.Ordonnancechirurgies.Any(e => e.Id == id);
        }
    }
}
