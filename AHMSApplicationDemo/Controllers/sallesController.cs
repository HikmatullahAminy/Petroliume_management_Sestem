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
    public class sallesController : Controller
    {
      
        private readonly ApplicationDbContext _context;

        public sallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: salles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Salles.Include(s => s.Store);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: salles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.SallesId == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }

        // GET: salles/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName");
            return View();
        }

        // POST: salles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SallesId,TotalLiter,PricePerLiter,Date,StoreId")] salles salles)
        {
          /*  var ExactBenifit = ViewBag.ExactBenifit;
            var TotalBenifit = ViewBag.TotalBenifit;



           var DesalColumn= _context.purchases.FirstOrDefault(a =>a.StoreId==1);
            var PetrolColumn = _context.purchases.FirstOrDefault(a => a.StoreId ==2);

            var DisalpricePerLiterInPurchase=DesalColumn.PricePerLiter;
            var PetrolPricePerLiterInPurchase=PetrolColumn.PricePerLiter;

            var DisalpricePerLiterInSalles = salles.PricePerLiter;
            var PetrolpricePerLiterInSalles = salles.PricePerLiter;

            var DisalExactBenifit = DisalpricePerLiterInSalles - DisalpricePerLiterInPurchase;
            var PetrolExactBenifit = PetrolpricePerLiterInSalles - PetrolPricePerLiterInPurchase;
            var DisalTotalBenifit = DisalExactBenifit * salles.TotalLiter;
            var PetrolTotalBenifit = PetrolExactBenifit * salles.TotalLiter;


           if(salles.StoreId==1)
            {
                salles.BenifitPerLiter = DisalExactBenifit;
                salles.TotalBinifit = DisalTotalBenifit;
            }
            else
            {
                salles.BenifitPerLiter = PetrolExactBenifit;
                salles.TotalBinifit = PetrolTotalBenifit;
            }*/


    

            if (ModelState.IsValid)
            {
                
             
               
                //له ذخیره نه باید تیل کم سی
               var intend= _context.Stores.Find(salles.StoreId);
                intend.TotalLiter -= salles.TotalLiter;
               
                //مجموعی پیسی باید معلومی شی
                var totalLiters=salles.TotalLiter;
                var PricePerLiters = salles.PricePerLiter;
                var TotalAmount = totalLiters * PricePerLiters;
                salles.TotalSalles += TotalAmount;

                //بانک ته باید پیسی اضافه شی
                var b = await _context.Bankes.FirstOrDefaultAsync(a => a.BankeId == 1);
                b.AmountExist += salles.TotalSalles;

                //اخیری کماند
                _context.Add(salles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName", salles.StoreId);
            return View(salles);
        }

        // GET: salles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles.FindAsync(id);
            if (salles == null)
            {
                return NotFound();
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "OilName", salles.StoreId);
            return View(salles);
        }

        // POST: salles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SallesId,TotalLiter,PricePerLiter,TotalSalles,Date,StoreId")] salles salles)
        {
            if (id != salles.SallesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sallesExists(salles.SallesId))
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
            ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreId", salles.StoreId);
            return View(salles);
        }

        // GET: salles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salles = await _context.Salles
                .Include(s => s.Store)
                .FirstOrDefaultAsync(m => m.SallesId == id);
            if (salles == null)
            {
                return NotFound();
            }

            return View(salles);
        }

        // POST: salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salles = await _context.Salles.FindAsync(id);
            _context.Salles.Remove(salles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sallesExists(int id)
        {
            return _context.Salles.Any(e => e.SallesId == id);
        }
    }
}
