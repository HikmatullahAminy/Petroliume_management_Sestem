using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHMSApplicationDemo.Data;
using AHMSApplicationDemo.Models;

namespace AHMSApplicationDemo.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.purchases.Include(p => p.Store);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.purchases
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseId,OilName,TotalLiter,PricePerLiter,Date,StoreId")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                var TotalLiters = purchase.TotalLiter;
                var PricePerLiters = purchase.PricePerLiter;
                var TotalAmount = TotalLiters * PricePerLiters;
                purchase.TotalPrice = TotalAmount;

                _context.Add(purchase);
                await _context.SaveChangesAsync();


                var b = await _context.Bankes.FirstOrDefaultAsync(a => a.BankeId == 1);
                b.AmountExist -= purchase.TotalPrice;

                await _context.SaveChangesAsync();

              var intend=  _context.Stores.Find(purchase.StoreId);
                intend.TotalLiter += purchase.TotalLiter;
                await _context.SaveChangesAsync();
              

                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName", purchase.StoreId);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName", purchase.StoreId);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseId,OilName,TotalLiter,PricePerLiter,TotalPrice,Date,StoreId")] Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.PurchaseId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName", purchase.StoreId);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.purchases
                .Include(p => p.Store)
                .FirstOrDefaultAsync(m => m.PurchaseId == id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase = await _context.purchases.FindAsync(id);
            _context.purchases.Remove(purchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseExists(int id)
        {
            return _context.purchases.Any(e => e.PurchaseId == id);
        }
    }
}
