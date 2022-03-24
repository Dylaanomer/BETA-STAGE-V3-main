using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ALPHA_DGS.Data;
using ALPHA_DGS.Models;
using System.Dynamic;

namespace ALPHA_DGS.Controllers
{
    public class MagazijnsController : Controller
    {
        private readonly AlphaDbContext _context;

        public MagazijnsController(AlphaDbContext context)
        {
            _context = context;
        }

        // GET: Magazijns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magazijn.ToListAsync());
        }

        public List<Magazijn> GetData()
        {
            List<Magazijn> datas = new List<Magazijn>();
            datas.Add(new Magazijn { LokatieType = 1, Naam = "Magazijn1" });
            datas.Add(new Magazijn { LokatieType = 2, Naam = "Magazijn2" });
            datas.Add(new Magazijn { LokatieType = 3, Naam=  "Magazijn3" });
            return datas;
        }

        public List<Partijserie> GetStudents()
        {
            List<Partijserie> series = new List<Partijserie>();
            series.Add(new Partijserie { PserId = 1, PsHerk = "GER" });
            series.Add(new Partijserie { PserId = 2, PsHerk = "FRA" });
            series.Add(new Partijserie { PserId = 3, PsHerk = "ITA" });
            return series;
        }

        public ActionResult IndexMeer()
        {
            ViewBag.Message = "Hello World";
            dynamic mymodel = new ExpandoObject();
            mymodel.Teachers = GetData();
            mymodel.Teachers = GetStudents();
            return View(mymodel);
        }


        // GET: Magazijns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazijn = await _context.Magazijn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazijn == null)
            {
                return NotFound();
            }

            return View(magazijn);
        }

        // GET: Magazijns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazijns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentMloId,LokatieType,Naam,Sequence,Bezet,MaxAanFust")] Magazijn magazijn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazijn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazijn);
        }

        // GET: Magazijns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazijn = await _context.Magazijn.FindAsync(id);
            if (magazijn == null)
            {
                return NotFound();
            }
            return View(magazijn);
        }

        // POST: Magazijns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentMloId,LokatieType,Naam,Sequence,Bezet,MaxAanFust")] Magazijn magazijn)
        {
            if (id != magazijn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazijn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazijnExists(magazijn.Id))
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
            return View(magazijn);
        }

        // GET: Magazijns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazijn = await _context.Magazijn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazijn == null)
            {
                return NotFound();
            }

            return View(magazijn);
        }

        // POST: Magazijns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazijn = await _context.Magazijn.FindAsync(id);
            _context.Magazijn.Remove(magazijn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagazijnExists(int id)
        {
            return _context.Magazijn.Any(e => e.Id == id);
        }
    }
}
