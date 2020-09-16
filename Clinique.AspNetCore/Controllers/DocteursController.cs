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
    public class DocteursController : Controller
    {
        private readonly CliniqueDbContext _context;

        public DocteursController(CliniqueDbContext context)
        {
            _context = context;
        }

        // GET: Docteurs
        public async Task<IActionResult> Index()
        {
            var cliniqueDbContext = _context.Docteurs.Include(d => d.Specialite);
            return View(await cliniqueDbContext.ToListAsync());
        }

        // GET: Docteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docteur = await _context.Docteurs
                .Include(d => d.Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docteur == null)
            {
                return NotFound();
            }

            return View(docteur);
        }

        // GET: Docteurs/Create
        public IActionResult Create()
        {
            ViewData["IdSpecialite"] = new SelectList(_context.Specialites, "Id", "Id");
            return View();
        }

        // POST: Docteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricule,NomM,PrenomM,IdSpecialite,Ville,Adresse,Niveau,NbrPatients,Id")] Docteur docteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSpecialite"] = new SelectList(_context.Specialites, "Id", "Id", docteur.IdSpecialite);
            return View(docteur);
        }

        // GET: Docteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docteur = await _context.Docteurs.FindAsync(id);
            if (docteur == null)
            {
                return NotFound();
            }
            ViewData["IdSpecialite"] = new SelectList(_context.Specialites, "Id", "Id", docteur.IdSpecialite);
            return View(docteur);
        }

        // POST: Docteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricule,NomM,PrenomM,IdSpecialite,Ville,Adresse,Niveau,NbrPatients,Id")] Docteur docteur)
        {
            if (id != docteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocteurExists(docteur.Id))
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
            ViewData["IdSpecialite"] = new SelectList(_context.Specialites, "Id", "Id", docteur.IdSpecialite);
            return View(docteur);
        }

        // GET: Docteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docteur = await _context.Docteurs
                .Include(d => d.Specialite)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docteur == null)
            {
                return NotFound();
            }

            return View(docteur);
        }

        // POST: Docteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docteur = await _context.Docteurs.FindAsync(id);
            _context.Docteurs.Remove(docteur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocteurExists(int id)
        {
            return _context.Docteurs.Any(e => e.Id == id);
        }
    }
}
