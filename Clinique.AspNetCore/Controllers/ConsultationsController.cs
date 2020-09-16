﻿using System;
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
    public class ConsultationsController : Controller
    {
        private readonly CliniqueDbContextFactory _contextFactory;

        public ConsultationsController(CliniqueDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // GET: Consultations
        public async Task<IActionResult> Index()
        {
            return View(await _contextFactory.CreateDbContext().Consultations.ToListAsync());
        }

        // GET: Consultations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _contextFactory.CreateDbContext().Consultations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // GET: Consultations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDocteur,IdDossierpatient,DateC,Diagnostic,IdOrdonnance,Id")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                _contextFactory.CreateDbContext().Add(consultation);
                await _contextFactory.CreateDbContext().SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _contextFactory.CreateDbContext().Consultations.FindAsync(id);
            if (consultation == null)
            {
                return NotFound();
            }
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDocteur,IdDossierpatient,DateC,Diagnostic,IdOrdonnance,Id")] Consultation consultation)
        {
            if (id != consultation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contextFactory.CreateDbContext().Update(consultation);
                    await _contextFactory.CreateDbContext().SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationExists(consultation.Id))
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
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _contextFactory.CreateDbContext().Consultations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultation = await _contextFactory.CreateDbContext().Consultations.FindAsync(id);
            _contextFactory.CreateDbContext().Consultations.Remove(consultation);
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationExists(int id)
        {
            return _contextFactory.CreateDbContext().Consultations.Any(e => e.Id == id);
        }
    }
}
