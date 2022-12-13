using Product.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MeasurementUnitsController : Controller
    {
        private readonly ProductContext _context;

        public MeasurementUnitsController(ProductContext context)
        {
            _context = context;
        }

        // GET: CountryProductions
        [ResponseCache(CacheProfileName = "AllCaching")]
        public async Task<IActionResult> Index()
        {
            return _context.measurementUnits != null ?
                        View(await _context.measurementUnits.ToListAsync()) :
                        Problem("Entity set 'CinemaContext.measurementUnits'  is null.");
        }

        // GET: CountryProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.measurementUnits == null)
            {
                return NotFound();
            }

            var measurementUnits = await _context.measurementUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurementUnits == null)
            {
                return NotFound();
            }

            return View(measurementUnits);
        }

        // GET: CountryProductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MeasurementUnits measurementUnits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurementUnits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurementUnits);
        }

        // GET: CountryProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.measurementUnits == null)
            {
                return NotFound();
            }

            var measurementUnits = await _context.measurementUnits.FindAsync(id);
            if (measurementUnits == null)
            {
                return NotFound();
            }
            return View(measurementUnits);
        }

        // POST: CountryProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MeasurementUnits measurementUnits)
        {
            if (id != measurementUnits.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurementUnits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementUnitsExists(measurementUnits.Id))
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
            return View(measurementUnits);
        }

        // GET: CountryProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.measurementUnits == null)
            {
                return NotFound();
            }

            var measurementUnits = await _context.measurementUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurementUnits == null)
            {
                return NotFound();
            }

            return View(measurementUnits);
        }

        // POST: CountryProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.measurementUnits == null)
            {
                return Problem("Entity set 'CinemaContext.measurementUnits'  is null.");
            }
            var measurementUnits = await _context.measurementUnits.FindAsync(id);
            if (measurementUnits != null)
            {
                _context.measurementUnits.Remove(measurementUnits);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurementUnitsExists(int id)
        {
            return (_context.measurementUnits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
