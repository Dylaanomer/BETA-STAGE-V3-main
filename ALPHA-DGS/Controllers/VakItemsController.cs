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
    public class VakItemsController : Controller
    {
        private readonly AlphaDbContext _context;

        public VakItemsController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: VakItems
        public async Task<IActionResult> Index()
        {
            var alphaDbContext = _context.Hallen.Include(v => v.Afdeling).Include(v => v.Invoer).Include(v => v.Rij).Include(v => v.RijSet);
            return View(await alphaDbContext.ToListAsync());
        }

        // GET: VakItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vakItem = await _context.Hallen
                .Include(v => v.Afdeling)
                .Include(v => v.Invoer)
                .Include(v => v.Rij)
                .Include(v => v.RijSet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vakItem == null)
            {
                return NotFound();
            }

            return View(vakItem);
        }

        // GET: VakItems/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "Id", "Id");
            ViewData["InvoerId"] = new SelectList(_context.Onions, "Id", "Id");
            ViewData["RijId"] = new SelectList(_context.Rijen, "Id", "Id");
            ViewData["RijSetId"] = new SelectList(_context.Boxen, "Id", "Id");
            return View();
        }

        // POST: VakItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Type,Land,InvoerId,RijId,RijSetId,AfdelingId")] VakItem vakItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vakItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "Id", "Id", vakItem.AfdelingId);
            ViewData["InvoerId"] = new SelectList(_context.Onions, "Id", "Id", vakItem.InvoerId);
            ViewData["RijId"] = new SelectList(_context.Rijen, "Id", "Id", vakItem.RijId);
            ViewData["RijSetId"] = new SelectList(_context.Boxen, "Id", "Id", vakItem.RijSetId);
            return View(vakItem);
        }

        // GET: VakItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vakItem = await _context.Hallen.FindAsync(id);
            if (vakItem == null)
            {
                return NotFound();
            }
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "Id", "Id", vakItem.AfdelingId);
            ViewData["InvoerId"] = new SelectList(_context.Onions, "Id", "Id", vakItem.InvoerId);
            ViewData["RijId"] = new SelectList(_context.Rijen, "Id", "Id", vakItem.RijId);
            ViewData["RijSetId"] = new SelectList(_context.Boxen, "Id", "Id", vakItem.RijSetId);
            return View(vakItem);
        }

        // POST: VakItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Type,Land,InvoerId,RijId,RijSetId,AfdelingId")] VakItem vakItem)
        {
            if (id != vakItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vakItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakItemExists(vakItem.Id))
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
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "Id", "Id", vakItem.AfdelingId);
            ViewData["InvoerId"] = new SelectList(_context.Onions, "Id", "Id", vakItem.InvoerId);
            ViewData["RijId"] = new SelectList(_context.Rijen, "Id", "Id", vakItem.RijId);
            ViewData["RijSetId"] = new SelectList(_context.Boxen, "Id", "Id", vakItem.RijSetId);
            return View(vakItem);
        }

        // GET: VakItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vakItem = await _context.Hallen
                .Include(v => v.Afdeling)
                .Include(v => v.Invoer)
                .Include(v => v.Rij)
                .Include(v => v.RijSet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vakItem == null)
            {
                return NotFound();
            }

            return View(vakItem);
        }

        // POST: VakItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vakItem = await _context.Hallen.FindAsync(id);
            _context.Hallen.Remove(vakItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakItemExists(int id)
        {
            return _context.Hallen.Any(e => e.Id == id);
        }

        public IActionResult CreateMore()
        {

            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "Id", "Id");
            ViewData["InvoerId"] = new SelectList(_context.Onions, "Id", "Id");
            ViewData["RijId"] = new SelectList(_context.Rijen, "Id", "Id");
            ViewData["RijSetId"] = new SelectList(_context.Boxen, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMore([Bind("Id,Naam,Type,Land,InvoerId,RijId,RijSetId,AfdelingId")] VakItem vakItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vakItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "Id", "Id", vakItem.AfdelingId);
            ViewData["InvoerId"] = new SelectList(_context.Onions, "Id", "Id", vakItem.InvoerId);
            ViewData["RijId"] = new SelectList(_context.Rijen, "Id", "Id", vakItem.RijId);
            ViewData["RijSetId"] = new SelectList(_context.Boxen, "Id", "Id", vakItem.RijSetId);
            return View(vakItem);
        }


    }
}
