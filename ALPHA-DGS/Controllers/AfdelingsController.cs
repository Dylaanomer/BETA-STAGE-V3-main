using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ALPHA_DGS.Data;
using ALPHA_DGS.Models;

namespace ALPHA_DGS.Controllers
{
    public class AfdelingsController : Controller
    {
        private readonly AlphaDbContext _context;

        public AfdelingsController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: Afdelings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afdeling.ToListAsync());
        }

        // GET: Afdelings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdeling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afdeling == null)
            {
                return NotFound();
            }

            return View(afdeling);
        }

        // GET: Afdelings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afdelings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam")] Afdeling afdeling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afdeling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afdeling);
        }

        // GET: Afdelings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdeling.FindAsync(id);
            if (afdeling == null)
            {
                return NotFound();
            }
            return View(afdeling);
        }

        // POST: Afdelings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] Afdeling afdeling)
        {
            if (id != afdeling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afdeling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfdelingExists(afdeling.Id))
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
            return View(afdeling);
        }

        // GET: Afdelings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdeling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afdeling == null)
            {
                return NotFound();
            }

            return View(afdeling);
        }

        // POST: Afdelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afdeling = await _context.Afdeling.FindAsync(id);
            _context.Afdeling.Remove(afdeling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfdelingExists(int id)
        {
            return _context.Afdeling.Any(e => e.Id == id);
        }
    }
}
