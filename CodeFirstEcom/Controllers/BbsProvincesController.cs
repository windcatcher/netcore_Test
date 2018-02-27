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
    public class BbsProvincesController : Controller
    {
        private readonly ecomContext _context;

        public BbsProvincesController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsProvinces
        public async Task<IActionResult> Index()
        {
            return View(await _context.BbsProvince.ToListAsync());
        }

        // GET: BbsProvinces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsProvince = await _context.BbsProvince
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsProvince == null)
            {
                return NotFound();
            }

            return View(bbsProvince);
        }

        // GET: BbsProvinces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BbsProvinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name")] BbsProvince bbsProvince)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsProvince);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bbsProvince);
        }

        // GET: BbsProvinces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsProvince = await _context.BbsProvince.SingleOrDefaultAsync(m => m.Id == id);
            if (bbsProvince == null)
            {
                return NotFound();
            }
            return View(bbsProvince);
        }

        // POST: BbsProvinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name")] BbsProvince bbsProvince)
        {
            if (id != bbsProvince.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsProvince);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsProvinceExists(bbsProvince.Id))
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
            return View(bbsProvince);
        }

        // GET: BbsProvinces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsProvince = await _context.BbsProvince
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsProvince == null)
            {
                return NotFound();
            }

            return View(bbsProvince);
        }

        // POST: BbsProvinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bbsProvince = await _context.BbsProvince.SingleOrDefaultAsync(m => m.Id == id);
            _context.BbsProvince.Remove(bbsProvince);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsProvinceExists(int id)
        {
            return _context.BbsProvince.Any(e => e.Id == id);
        }
    }
}
