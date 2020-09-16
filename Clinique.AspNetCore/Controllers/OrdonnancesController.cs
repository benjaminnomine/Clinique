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
    public class OrdonnancesController : Controller
    {
        private readonly CliniqueDbContext _context;

        public OrdonnancesController(CliniqueDbContext context)
        {
            _context = context;
        }

        // GET: Ordonnances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ordonnances.ToListAsync());
        }

        // GET: Ordonnances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnance = await _context.Ordonnances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordonnance == null)
            {
                return NotFound();
            }

            return View(ordonnance);
        }

        // GET: Ordonnances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ordonnances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Recommandations,TypeO,DateC,Id")] Ordonnance ordonnance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordonnance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordonnance);
        }

        // GET: Ordonnances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnance = await _context.Ordonnances.FindAsync(id);
            if (ordonnance == null)
            {
                return NotFound();
            }
            return View(ordonnance);
        }

        // POST: Ordonnances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Recommandations,TypeO,DateC,Id")] Ordonnance ordonnance)
        {
            if (id != ordonnance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordonnance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdonnanceExists(ordonnance.Id))
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
            return View(ordonnance);
        }

        // GET: Ordonnances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnance = await _context.Ordonnances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordonnance == null)
            {
                return NotFound();
            }

            return View(ordonnance);
        }

        // POST: Ordonnances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordonnance = await _context.Ordonnances.FindAsync(id);
            _context.Ordonnances.Remove(ordonnance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdonnanceExists(int id)
        {
            return _context.Ordonnances.Any(e => e.Id == id);
        }
    }
}
