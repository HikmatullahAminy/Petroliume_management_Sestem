using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHMSApplicationDemo.Data;
using AHMSApplicationDemo.Models;
using Microsoft.AspNetCore.Authorization;

namespace AHMSApplicationDemo.Controllers
{
    [Authorize]
    public class HalfDebtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HalfDebtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HalfDebts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HalfDebts.Include(d => d.Dept).Include(d=>d.Dept);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HalfDebts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halfDebts = await _context.HalfDebts
                .FirstOrDefaultAsync(m => m.HalfDebtId == id);
            if (halfDebts == null)
            {
                return NotFound();
            }

            return View(halfDebts);
        }

        // GET: HalfDebts/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "CustomerName");

            return View();
        }

        // POST: HalfDebts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( HalfDebts halfDebts)
        {
            if (ModelState.IsValid)
            {
               var intend= _context.Depts.Find(halfDebts.DeptsId);
             var totalAmount=   intend.TotalPrice;
                var RemainAmount = totalAmount - halfDebts.Amount;

                halfDebts.RemainingDebts = RemainAmount;
                intend.RemainsAmount = RemainAmount;

                var b = _context.Bankes.FirstOrDefault(a => a.BankeId == 1);
                b.AmountExist += halfDebts.Amount;

                _context.Add(halfDebts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(halfDebts);
        }

        // GET: HalfDebts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halfDebts = await _context.HalfDebts.FindAsync(id);
            if (halfDebts == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Depts, "DeptId", "CustomerName");

            return View(halfDebts);
        }

        // POST: HalfDebts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HalfDebtId,Amount,Date,RemainingDebts,DeptsId")] HalfDebts halfDebts)
        {
            if (id != halfDebts.HalfDebtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(halfDebts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HalfDebtsExists(halfDebts.HalfDebtId))
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
            return View(halfDebts);
        }

        // GET: HalfDebts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halfDebts = await _context.HalfDebts
                .FirstOrDefaultAsync(m => m.HalfDebtId == id);
            if (halfDebts == null)
            {
                return NotFound();
            }

            return View(halfDebts);
        }

        // POST: HalfDebts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var halfDebts = await _context.HalfDebts.FindAsync(id);
            _context.HalfDebts.Remove(halfDebts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HalfDebtsExists(int id)
        {
            return _context.HalfDebts.Any(e => e.HalfDebtId == id);
        }
    }
}
