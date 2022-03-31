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
    public class MagazijnPartijsController : Controller
    {
        private readonly AlphaDbContext _context;

        public MagazijnPartijsController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: MagazijnPartijs
        public async Task<IActionResult> Index()
        {
            var alphaDbContext = _context.MagazijnPartij.Include(m => m.Magazijn).Include(m => m.Stadium);
            return View(await alphaDbContext.ToListAsync());
        }

        // GET: MagazijnPartijs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazijnPartij = await _context.MagazijnPartij
                .Include(m => m.Magazijn)
                .Include(m => m.Stadium)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazijnPartij == null)
            {
                return NotFound();
            }

            return View(magazijnPartij);
        }

        // GET: MagazijnPartijs/Insert
        public async Task<IActionResult> Insert(int? id)
        {
            Magazijn magazijn = await _context.Magazijn.Where(r => r.Id == id).FirstAsync();
            if (id is not null && magazijn.Id == id)
            {
                MagazijnPartij magazijnpartij = new MagazijnPartij();
                magazijnpartij.MagazijnId = (int)id;

                return View(magazijnpartij);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(
            [Bind("Pvan, Ptot, PHerk, VpNaam, StadiumId, Uitserie, AantFust, Naam, MagazijnId")] MagazijnPartij magazijnPartij)
            
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazijnPartij);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Magazijn", new { id = magazijnPartij.MagazijnId });
            }

            return View(magazijnPartij);

        }






        // GET: MagazijnPartijs/Create
        public IActionResult Create()
        {
            ViewData["MagazijnId"] = new SelectList(_context.Magazijn, "Id", "Id");
            ViewData["StadiumId"] = new SelectList(_context.Stadium, "Id", "Id");
            return View();
        }

        // POST: MagazijnPartijs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pvan,Ptot,PHerk,VpNaam,StadiumId,Uitserie,AantFust,Naam,MagazijnId")] MagazijnPartij magazijnPartij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazijnPartij);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MagazijnId"] = new SelectList(_context.Magazijn, "Id", "Id", magazijnPartij.MagazijnId);
            ViewData["StadiumId"] = new SelectList(_context.Stadium, "Id", "Id", magazijnPartij.StadiumId);
            return View(magazijnPartij);
        }

        // GET: MagazijnPartijs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazijnPartij = await _context.MagazijnPartij.FindAsync(id);
            if (magazijnPartij == null)
            {
                return NotFound();
            }
            ViewData["MagazijnId"] = new SelectList(_context.Magazijn, "Id", "Id", magazijnPartij.MagazijnId);
            ViewData["StadiumId"] = new SelectList(_context.Stadium, "Id", "Id", magazijnPartij.StadiumId);
            return View(magazijnPartij);
        }

        // POST: MagazijnPartijs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pvan,Ptot,PHerk,VpNaam,StadiumId,Uitserie,AantFust,Naam,MagazijnId")] MagazijnPartij magazijnPartij)
        {
            if (id != magazijnPartij.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazijnPartij);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazijnPartijExists(magazijnPartij.Id))
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
            ViewData["MagazijnId"] = new SelectList(_context.Magazijn, "Id", "Id", magazijnPartij.MagazijnId);
            ViewData["StadiumId"] = new SelectList(_context.Stadium, "Id", "Id", magazijnPartij.StadiumId);
            return View(magazijnPartij);
        }

        // GET: MagazijnPartijs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazijnPartij = await _context.MagazijnPartij
                .Include(m => m.Magazijn)
                .Include(m => m.Stadium)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazijnPartij == null)
            {
                return NotFound();
            }

            return View(magazijnPartij);
        }

        // POST: MagazijnPartijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazijnPartij = await _context.MagazijnPartij.FindAsync(id);
            _context.MagazijnPartij.Remove(magazijnPartij);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazijnPartijExists(int id)
        {
            return _context.MagazijnPartij.Any(e => e.Id == id);
        }
    }
}
