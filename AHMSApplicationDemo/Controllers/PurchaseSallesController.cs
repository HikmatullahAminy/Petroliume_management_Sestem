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
    public class PurchaseSallesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly object PurchaseDisalPrice;

        public PurchaseSallesController(ApplicationDbContext context)
        {
            _context = context;
          

      
        }

        // GET: PurchaseSalles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseSalles.Include(p => p.Purchase).Include(p => p.Salles);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseSalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseSalles = await _context.PurchaseSalles
                .Include(p => p.Purchase)
                .Include(p => p.Salles)
                .FirstOrDefaultAsync(m => m.PurchaseSallesId == id);
            if (purchaseSalles == null)
            {
                return NotFound();
            }

            return View(purchaseSalles);
        }

        // GET: PurchaseSalles/Create
        public IActionResult Create()
        {
            ViewData["PurchaseId"] = new SelectList(_context.purchases, "PurchaseId", "PurchaseId");
            ViewData["SallesId"] = new SelectList(_context.Salles, "SallesId", "SallesId");
            return View();
        }

        // POST: PurchaseSalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<object> CreateAsync([Bind("PurchaseSallesId,SallesId,PurchaseId")] PurchaseSalles purchaseSalles)
        {
            //  private readonly int PurchaseDisalPrice;
            if (ModelState.IsValid)
            {
                _context.Add(purchaseSalles);
                await _context.SaveChangesAsync();

                var purchaseColumn = _context.purchases.Find(purchaseSalles.PurchaseId);
                if(purchaseColumn.StoreId==1)
                {
                    var _PurchaseDisalPrice = purchaseColumn.PricePerLiter;
                  //  PurchaseDisalPrice = _PurchaseDisalPrice;
                }
                else
                {
                    var PetrolPrice = purchaseColumn.PricePerLiter;
                }
                var sallesColumn = _context.Salles.Find(purchaseSalles.SallesId);
                if(sallesColumn.StoreId==1)
                {
                  //  var ExactBenifit = sallesColumn.PricePerLiter - PurchaseDisalPrice;
                }
                else
                {

                }
                ViewBag.ExactBenifit = sallesColumn.PricePerLiter - purchaseColumn.PricePerLiter;
                ViewBag.TotalBenifit = ViewBag.ExactBenifit * sallesColumn.TotalLiter;
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseId"] = new SelectList(_context.purchases, "PurchaseId", "PurchaseId", purchaseSalles.PurchaseId);
            ViewData["SallesId"] = new SelectList(_context.Salles, "SallesId", "SallesId", purchaseSalles.SallesId);
            return View(purchaseSalles);
        }

        // GET: PurchaseSalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseSalles = await _context.PurchaseSalles.FindAsync(id);
            if (purchaseSalles == null)
            {
                return NotFound();
            }
            ViewData["PurchaseId"] = new SelectList(_context.purchases, "PurchaseId", "PurchaseId", purchaseSalles.PurchaseId);
            ViewData["SallesId"] = new SelectList(_context.Salles, "SallesId", "SallesId", purchaseSalles.SallesId);
            return View(purchaseSalles);
        }

        // POST: PurchaseSalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseSallesId,SallesId,PurchaseId")] PurchaseSalles purchaseSalles)
        {
            if (id != purchaseSalles.PurchaseSallesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseSalles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseSallesExists(purchaseSalles.PurchaseSallesId))
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
            ViewData["PurchaseId"] = new SelectList(_context.purchases, "PurchaseId", "PurchaseId", purchaseSalles.PurchaseId);
            ViewData["SallesId"] = new SelectList(_context.Salles, "SallesId", "SallesId", purchaseSalles.SallesId);
            return View(purchaseSalles);
        }

        // GET: PurchaseSalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseSalles = await _context.PurchaseSalles
                .Include(p => p.Purchase)
                .Include(p => p.Salles)
                .FirstOrDefaultAsync(m => m.PurchaseSallesId == id);
            if (purchaseSalles == null)
            {
                return NotFound();
            }

            return View(purchaseSalles);
        }

        // POST: PurchaseSalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseSalles = await _context.PurchaseSalles.FindAsync(id);
            _context.PurchaseSalles.Remove(purchaseSalles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseSallesExists(int id)
        {
            return _context.PurchaseSalles.Any(e => e.PurchaseSallesId == id);
        }
    }
}
