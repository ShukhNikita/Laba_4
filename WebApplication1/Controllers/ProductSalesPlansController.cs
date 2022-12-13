using Product.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class ProductSalesPlansController : Controller
    {
        private readonly ProductContext _context;

        public ProductSalesPlansController(ProductContext context)
        {
            _context = context;
        }

        [ResponseCache(CacheProfileName = "AllCaching")]
        public async Task<IActionResult> Index()
        {
            var productContext = _context.productSalesPlans;
            return View(await productContext.ToListAsync());
        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.productSalesPlans == null)
            {
                return NotFound();
            }

            var places = await _context.productSalesPlans
                .Include(p => p.CompaniesId)
                .Include(p => p.CompaniesId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            ViewData["ProductionTypesId"] = new SelectList(_context.ProductionTypes, "Id", "Id");
            ViewData["CompaniesId"] = new SelectList(_context.companies, "Id", "Id");
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompaniesId,ProductionTypesId,PlannedImplementationVolume,ActualImplementationVolume,QuarterInfo,YearInfo")] ProductSalesPlans places)
        {
            if (ModelState.IsValid)
            {
                _context.Add(places);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductionTypesId"] = new SelectList(_context.ProductionTypes, "Id", "Id", places.ProductionTypeId);
            ViewData["CompaniesId"] = new SelectList(_context.companies, "Id", "Id", places.CompaniesId);
            return View(places);
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.productSalesPlans == null)
            {
                return NotFound();
            }

            var places = await _context.productSalesPlans.FindAsync(id);
            if (places == null)
            {
                return NotFound();
            }
            ViewData["ProductionTypelId"] = new SelectList(_context.ProductionTypes, "Id", "Id", places.ProductionTypeId);
            ViewData["CompaniesId"] = new SelectList(_context.companies, "Id", "Id", places.CompaniesId);
            return View(places);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompaniesId,ProductionTypesId,PlannedImplementationVolume,ActualImplementationVolume,QuarterInfo,YearInfo")] ProductSalesPlans places)
        {
            if (id != places.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(places);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacesExists(places.Id))
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
            ViewData["ProductionTypesId"] = new SelectList(_context.ProductionTypes, "Id", "Id", places.ProductionTypeId);
            ViewData["Companies"] = new SelectList(_context.companies, "Id", "Id", places.CompaniesId);
            return View(places);
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.productSalesPlans == null)
            {
                return NotFound();
            }

            var places = await _context.productSalesPlans
                .Include(p => p.ProductionTypeId)
                .Include(p => p.CompanyId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.productSalesPlans == null)
            {
                return Problem("Entity set 'CinemaContext.Places'  is null.");
            }
            var places = await _context.productSalesPlans.FindAsync(id);
            if (places != null)
            {
                _context.productSalesPlans.Remove(places);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacesExists(int id)
        {
            return (_context.productSalesPlans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
