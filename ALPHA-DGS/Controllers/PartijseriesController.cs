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
    public class PartijseriesController : Controller
    {
        private readonly AlphaDbContext _context;

        public PartijseriesController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: Partijseries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore2()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore3()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore4()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore5()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore6()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore7()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore8()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore9()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore10()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        public async Task<IActionResult> IndexMore11()
        {
            return View(await _context.Partijserie.ToListAsync());
        }

        // GET: Partijseries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partijserie = await _context.Partijserie
                .FirstOrDefaultAsync(m => m.PserId == id);
            if (partijserie == null)
            {
                return NotFound();
            }

            return View(partijserie);
        }

        // GET: Partijseries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partijseries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PserId,PsJaarletter,PsVan,PsTot,PsHerk")] Partijserie partijserie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partijserie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partijserie);
        }

        // GET: Partijseries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partijserie = await _context.Partijserie.FindAsync(id);
            if (partijserie == null)
            {
                return NotFound();
            }
            return View(partijserie);
        }

        // POST: Partijseries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PserId,PsJaarletter,PsVan,PsTot,PsHerk")] Partijserie partijserie)
        {
            if (id != partijserie.PserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partijserie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartijserieExists(partijserie.PserId))
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
            return View(partijserie);
        }

        // GET: Partijseries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partijserie = await _context.Partijserie
                .FirstOrDefaultAsync(m => m.PserId == id);
            if (partijserie == null)
            {
                return NotFound();
            }

            return View(partijserie);
        }

        // POST: Partijseries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partijserie = await _context.Partijserie.FindAsync(id);
            _context.Partijserie.Remove(partijserie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartijserieExists(int id)
        {
            return _context.Partijserie.Any(e => e.PserId == id);
        }
    }
}
