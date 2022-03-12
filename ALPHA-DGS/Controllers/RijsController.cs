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
    public class RijsController : Controller
    {
        private readonly AlphaDbContext _context;

        public RijsController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: Rijs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rijen.ToListAsync());
        }

        // GET: Rijs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rij = await _context.Rijen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rij == null)
            {
                return NotFound();
            }

            return View(rij);
        }

        // GET: Rijs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rijs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam")] Rij rij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rij);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rij);
        }

        // GET: Rijs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rij = await _context.Rijen.FindAsync(id);
            if (rij == null)
            {
                return NotFound();
            }
            return View(rij);
        }

        // POST: Rijs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] Rij rij)
        {
            if (id != rij.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rij);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RijExists(rij.Id))
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
            return View(rij);
        }

        // GET: Rijs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rij = await _context.Rijen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rij == null)
            {
                return NotFound();
            }

            return View(rij);
        }

        // POST: Rijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rij = await _context.Rijen.FindAsync(id);
            _context.Rijen.Remove(rij);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RijExists(int id)
        {
            return _context.Rijen.Any(e => e.Id == id);
        }
    }
}
