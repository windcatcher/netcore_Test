using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirstEcom;

namespace CodeFirstEcom.Controllers
{
    public class BbsTownsController : Controller
    {
        private readonly ecomContext _context;

        public BbsTownsController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsTowns
        public async Task<IActionResult> Index()
        {
            return View(await _context.BbsTown.ToListAsync());
        }

        // GET: BbsTowns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsTown = await _context.BbsTown
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsTown == null)
            {
                return NotFound();
            }

            return View(bbsTown);
        }

        // GET: BbsTowns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BbsTowns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,City")] BbsTown bbsTown)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsTown);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bbsTown);
        }

        // GET: BbsTowns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsTown = await _context.BbsTown.SingleOrDefaultAsync(m => m.Id == id);
            if (bbsTown == null)
            {
                return NotFound();
            }
            return View(bbsTown);
        }

        // POST: BbsTowns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,City")] BbsTown bbsTown)
        {
            if (id != bbsTown.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsTown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsTownExists(bbsTown.Id))
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
            return View(bbsTown);
        }

        // GET: BbsTowns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsTown = await _context.BbsTown
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsTown == null)
            {
                return NotFound();
            }

            return View(bbsTown);
        }

        // POST: BbsTowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bbsTown = await _context.BbsTown.SingleOrDefaultAsync(m => m.Id == id);
            _context.BbsTown.Remove(bbsTown);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsTownExists(int id)
        {
            return _context.BbsTown.Any(e => e.Id == id);
        }
    }
}
