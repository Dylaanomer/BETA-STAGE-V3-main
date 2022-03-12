using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ALPHA_DGS.Data;
using ALPHA_DGS.Models;
using Microsoft.AspNetCore.Authorization;

namespace ALPHA_DGS.Controllers
{
    public class RijSetsController : Controller
    {
        private readonly AlphaDbContext _context;

        public RijSetsController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: RijSets

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boxen.ToListAsync());
        }


        // GET: RijSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rijSet = await _context.Boxen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rijSet == null)
            {
                return NotFound();
            }

            return View(rijSet);
        }

        // GET: RijSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RijSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam")] RijSet rijSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rijSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rijSet);
        }

        // GET: RijSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rijSet = await _context.Boxen.FindAsync(id);
            if (rijSet == null)
            {
                return NotFound();
            }
            return View(rijSet);
        }

        // POST: RijSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] RijSet rijSet)
        {
            if (id != rijSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rijSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RijSetExists(rijSet.Id))
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
            return View(rijSet);
        }

        // GET: RijSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rijSet = await _context.Boxen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rijSet == null)
            {
                return NotFound();
            }

            return View(rijSet);
        }

        // POST: RijSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rijSet = await _context.Boxen.FindAsync(id);
            _context.Boxen.Remove(rijSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RijSetExists(int id)
        {
            return _context.Boxen.Any(e => e.Id == id);
        }
    }
}
