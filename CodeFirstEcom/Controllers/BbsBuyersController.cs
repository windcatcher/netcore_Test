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
    public class BbsBuyersController : Controller
    {
        private readonly ecomContext _context;

        public BbsBuyersController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsBuyers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BbsBuyer.ToListAsync());
        }

        // GET: BbsBuyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsBuyer = await _context.BbsBuyer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsBuyer == null)
            {
                return NotFound();
            }

            return View(bbsBuyer);
        }

        // GET: BbsBuyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BbsBuyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Gender,Email,RealName,RegisterTime,Province,City,Town,Addr,IsDel")] BbsBuyer bbsBuyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsBuyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bbsBuyer);
        }

        // GET: BbsBuyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsBuyer = await _context.BbsBuyer.SingleOrDefaultAsync(m => m.Id == id);
            if (bbsBuyer == null)
            {
                return NotFound();
            }
            return View(bbsBuyer);
        }

        // POST: BbsBuyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Gender,Email,RealName,RegisterTime,Province,City,Town,Addr,IsDel")] BbsBuyer bbsBuyer)
        {
            if (id != bbsBuyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsBuyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsBuyerExists(bbsBuyer.Id))
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
            return View(bbsBuyer);
        }

        // GET: BbsBuyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsBuyer = await _context.BbsBuyer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bbsBuyer == null)
            {
                return NotFound();
            }

            return View(bbsBuyer);
        }

        // POST: BbsBuyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bbsBuyer = await _context.BbsBuyer.SingleOrDefaultAsync(m => m.Id == id);
            _context.BbsBuyer.Remove(bbsBuyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsBuyerExists(int id)
        {
            return _context.BbsBuyer.Any(e => e.Id == id);
        }
    }
}
