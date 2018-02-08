using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirst;

namespace DbFirst.Controllers
{
    public class BbsBrandsController : Controller
    {
        private readonly ecomContext _context;

        public BbsBrandsController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.BbsBrand.ToListAsync());
        }

        // GET: BbsBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsBrand = await _context.BbsBrand
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsBrand == null)
            {
                return NotFound();
            }

            return View(bbsBrand);
        }

        // GET: BbsBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BbsBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImgUrl,WebSite,Sort,IsDisplay")] BbsBrand bbsBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bbsBrand);
        }

        // GET: BbsBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsBrand = await _context.BbsBrand.SingleOrDefaultAsync(m => m.Id == id);
            if (bbsBrand == null)
            {
                return NotFound();
            }
            return View(bbsBrand);
        }

        // POST: BbsBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImgUrl,WebSite,Sort,IsDisplay")] BbsBrand bbsBrand)
        {
            if (id != bbsBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsBrandExists(bbsBrand.Id))
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
            return View(bbsBrand);
        }

        // GET: BbsBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsBrand = await _context.BbsBrand
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsBrand == null)
            {
                return NotFound();
            }

            return View(bbsBrand);
        }

        // POST: BbsBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bbsBrand = await _context.BbsBrand.SingleOrDefaultAsync(m => m.Id == id);
            _context.BbsBrand.Remove(bbsBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsBrandExists(int id)
        {
            return _context.BbsBrand.Any(e => e.Id == id);
        }
    }
}
