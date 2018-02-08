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
    public class BbsEmployeesController : Controller
    {
        private readonly ecomContext _context;

        public BbsEmployeesController(ecomContext context)
        {
            _context = context;
        }

        // GET: BbsEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.BbsEmployee.ToListAsync());
        }

        // GET: BbsEmployees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsEmployee = await _context.BbsEmployee
                .SingleOrDefaultAsync(m => m.Username == id);
            if (bbsEmployee == null)
            {
                return NotFound();
            }

            return View(bbsEmployee);
        }

        // GET: BbsEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BbsEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,Degree,Email,Gender,ImgUrl,Phone,RealName,School,IsDel")] BbsEmployee bbsEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bbsEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bbsEmployee);
        }

        // GET: BbsEmployees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsEmployee = await _context.BbsEmployee.SingleOrDefaultAsync(m => m.Username == id);
            if (bbsEmployee == null)
            {
                return NotFound();
            }
            return View(bbsEmployee);
        }

        // POST: BbsEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,Degree,Email,Gender,ImgUrl,Phone,RealName,School,IsDel")] BbsEmployee bbsEmployee)
        {
            if (id != bbsEmployee.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bbsEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BbsEmployeeExists(bbsEmployee.Username))
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
            return View(bbsEmployee);
        }

        // GET: BbsEmployees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bbsEmployee = await _context.BbsEmployee
                .SingleOrDefaultAsync(m => m.Username == id);
            if (bbsEmployee == null)
            {
                return NotFound();
            }

            return View(bbsEmployee);
        }

        // POST: BbsEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bbsEmployee = await _context.BbsEmployee.SingleOrDefaultAsync(m => m.Username == id);
            _context.BbsEmployee.Remove(bbsEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BbsEmployeeExists(string id)
        {
            return _context.BbsEmployee.Any(e => e.Username == id);
        }
    }
}
