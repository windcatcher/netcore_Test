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
    public class BbsAddrsController : Controller
    {
        private readonly ecomContext _context;

        public BbsAddrsController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsAddrs
        public async Task<IActionResult> Index()
        {
            var ecomContext = _context.BbsAddr.Include(b => b.Buyer);
            return View(await ecomContext.ToListAsync());
        }

        // GET: BbsAddrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsAddr = await _context.BbsAddr
                .Include(b => b.Buyer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsAddr == null)
            {
                return NotFound();
            }

            return View(bbsAddr);
        }

        // GET: BbsAddrs/Create
        public IActionResult Create()
        {
            ViewData["BuyerId"] = new SelectList(_context.BbsBuyer, "Username", "Username");
            return View();
        }

        // POST: BbsAddrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuyerId,Name,City,Addr,Phone,IsDef")] BbsAddr bbsAddr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsAddr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuyerId"] = new SelectList(_context.BbsBuyer, "Username", "Username", bbsAddr.BuyerId);
            return View(bbsAddr);
        }

        // GET: BbsAddrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsAddr = await _context.BbsAddr.SingleOrDefaultAsync(m => m.Id == id);
            if (bbsAddr == null)
            {
                return NotFound();
            }
            ViewData["BuyerId"] = new SelectList(_context.BbsBuyer, "Username", "Username", bbsAddr.BuyerId);
            return View(bbsAddr);
        }

        // POST: BbsAddrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuyerId,Name,City,Addr,Phone,IsDef")] BbsAddr bbsAddr)
        {
            if (id != bbsAddr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsAddr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsAddrExists(bbsAddr.Id))
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
            ViewData["BuyerId"] = new SelectList(_context.BbsBuyer, "Username", "Username", bbsAddr.BuyerId);
            return View(bbsAddr);
        }

        // GET: BbsAddrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsAddr = await _context.BbsAddr
                .Include(b => b.Buyer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsAddr == null)
            {
                return NotFound();
            }

            return View(bbsAddr);
        }

        // POST: BbsAddrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bbsAddr = await _context.BbsAddr.SingleOrDefaultAsync(m => m.Id == id);
            _context.BbsAddr.Remove(bbsAddr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsAddrExists(int id)
        {
            return _context.BbsAddr.Any(e => e.Id == id);
        }
    }
}
