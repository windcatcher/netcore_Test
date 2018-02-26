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
    public class BbsProductsController : Controller
    {
        private readonly ecomContext _context;

        public BbsProductsController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsProducts
        public async Task<IActionResult> Index()
        {
            var ecomContext = _context.BbsProduct.Include(b => b.Brand).Include(b => b.Type);
            return View(await ecomContext.ToListAsync());
        }

        // GET: BbsProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsProduct = await _context.BbsProduct
                .Include(b => b.Brand)
                .Include(b => b.Type)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsProduct == null)
            {
                return NotFound();
            }

            return View(bbsProduct);
        }

        // GET: BbsProducts/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.BbsBrand, "Id", "Id");
            ViewData["TypeId"] = new SelectList(_context.BbsType, "Id", "Id");
            return View();
        }

        // POST: BbsProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,No,Name,Weight,IsNew,IsHot,IsCommend,CreateTime,CreateUserId,CheckTime,CheckUserId,IsShow,IsDel,TypeId,BrandId,Keywords,Sales,Description,PackageList,Feature,Color,Size")] BbsProduct bbsProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.BbsBrand, "Id", "Id", bbsProduct.BrandId);
            ViewData["TypeId"] = new SelectList(_context.BbsType, "Id", "Id", bbsProduct.TypeId);
            return View(bbsProduct);
        }

        // GET: BbsProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsProduct = await _context.BbsProduct.SingleOrDefaultAsync(m => m.Id == id);
            if (bbsProduct == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.BbsBrand, "Id", "Id", bbsProduct.BrandId);
            ViewData["TypeId"] = new SelectList(_context.BbsType, "Id", "Id", bbsProduct.TypeId);
            return View(bbsProduct);
        }

        // POST: BbsProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,No,Name,Weight,IsNew,IsHot,IsCommend,CreateTime,CreateUserId,CheckTime,CheckUserId,IsShow,IsDel,TypeId,BrandId,Keywords,Sales,Description,PackageList,Feature,Color,Size")] BbsProduct bbsProduct)
        {
            if (id != bbsProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsProductExists(bbsProduct.Id))
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
            ViewData["BrandId"] = new SelectList(_context.BbsBrand, "Id", "Id", bbsProduct.BrandId);
            ViewData["TypeId"] = new SelectList(_context.BbsType, "Id", "Id", bbsProduct.TypeId);
            return View(bbsProduct);
        }

        // GET: BbsProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsProduct = await _context.BbsProduct
                .Include(b => b.Brand)
                .Include(b => b.Type)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsProduct == null)
            {
                return NotFound();
            }

            return View(bbsProduct);
        }

        // POST: BbsProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bbsProduct = await _context.BbsProduct.SingleOrDefaultAsync(m => m.Id == id);
            _context.BbsProduct.Remove(bbsProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsProductExists(int id)
        {
            return _context.BbsProduct.Any(e => e.Id == id);
        }
    }
}
