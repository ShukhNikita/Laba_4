using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Diagnostics;
using Product.Context;

namespace WebApplication1.Controllers
{
    public class ActivityTypesController : Controller
    {
        private readonly ProductContext _context;

        public ActivityTypesController(ProductContext context)
        {
            _context = context;
        }

        // GET: CountryProductions
        [ResponseCache(CacheProfileName = "AllCaching")]
        public async Task<IActionResult> Index()
        {
            return _context.activityTypes != null ?
                        View(await _context.activityTypes.ToListAsync()) :
                        Problem("Entity set 'CinemaContext.activityTypes'  is null.");
        }

        // GET: CountryProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.activityTypes == null)
            {
                return NotFound();
            }

            var activityTypes = await _context.activityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityTypes == null)
            {
                return NotFound();
            }

            return View(activityTypes);
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
        public async Task<IActionResult> Create([Bind("Id,Name")] ActivityTypes activityTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityTypes);
        }

        // GET: CountryProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.activityTypes == null)
            {
                return NotFound();
            }

            var activityTypes = await _context.activityTypes.FindAsync(id);
            if (activityTypes == null)
            {
                return NotFound();
            }
            return View(activityTypes);
        }

        // POST: CountryProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ActivityTypes activityTypes)
        {
            if (id != activityTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityTypesExists(activityTypes.Id))
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
            return View(activityTypes);
        }

        // GET: CountryProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.activityTypes == null)
            {
                return NotFound();
            }

            var activityTypes = await _context.activityTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityTypes == null)
            {
                return NotFound();
            }

            return View(activityTypes);
        }

        // POST: CountryProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.activityTypes == null)
            {
                return Problem("Entity set 'CinemaContext.activityTypes'  is null.");
            }
            var activityTypes = await _context.activityTypes.FindAsync(id);
            if (activityTypes != null)
            {
                _context.activityTypes.Remove(activityTypes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityTypesExists(int id)
        {
            return (_context.activityTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}