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
    public class InvoersController : Controller
    {
        private readonly AlphaDbContext _context;

        public InvoersController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: Invoers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Onions.ToListAsync());
        }

        // GET: Invoers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoer = await _context.Onions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoer == null)
            {
                return NotFound();
            }

            return View(invoer);
        }

        // GET: Invoers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Voornaam,Achternaam,Type,Land")] Invoer invoer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoer);
        }

        // GET: Invoers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoer = await _context.Onions.FindAsync(id);
            if (invoer == null)
            {
                return NotFound();
            }
            return View(invoer);
        }

        // POST: Invoers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voornaam,Achternaam,Type,Land")] Invoer invoer)
        {
            if (id != invoer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoerExists(invoer.Id))
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
            return View(invoer);
        }

        // GET: Invoers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoer = await _context.Onions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoer == null)
            {
                return NotFound();
            }

            return View(invoer);
        }

        // POST: Invoers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoer = await _context.Onions.FindAsync(id);
            _context.Onions.Remove(invoer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoerExists(int id)
        {
            return _context.Onions.Any(e => e.Id == id);
        }
    }
}
