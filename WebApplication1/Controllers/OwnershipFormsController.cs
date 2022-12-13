using Product.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OwnershipFormsController : Controller
    {
        private readonly ProductContext _context;

        public OwnershipFormsController(ProductContext context)
        {
            _context = context;
        }

        // GET: CountryProductions
        [ResponseCache(CacheProfileName = "AllCaching")]
        public async Task<IActionResult> Index()
        {
            return _context.ownershipForms != null ?
                        View(await _context.ownershipForms.ToListAsync()) :
                        Problem("Entity set 'CinemaContext.ownershipForms'  is null.");
        }

        // GET: CountryProductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ownershipForms == null)
            {
                return NotFound();
            }

            var ownershipForms = await _context.ownershipForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownershipForms == null)
            {
                return NotFound();
            }

            return View(ownershipForms);
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
        public async Task<IActionResult> Create([Bind("Id,Name")] OwnershipForms ownershipForms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownershipForms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownershipForms);
        }

        // GET: CountryProductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ownershipForms == null)
            {
                return NotFound();
            }

            var ownershipForms = await _context.ownershipForms.FindAsync(id);
            if (ownershipForms == null)
            {
                return NotFound();
            }
            return View(ownershipForms);
        }

        // POST: CountryProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] OwnershipForms ownershipForms)
        {
            if (id != ownershipForms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownershipForms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnershipFormsExists(ownershipForms.Id))
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
            return View(ownershipForms);
        }

        // GET: CountryProductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ownershipForms == null)
            {
                return NotFound();
            }

            var ownershipForms = await _context.ownershipForms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownershipForms == null)
            {
                return NotFound();
            }

            return View(ownershipForms);
        }

        // POST: CountryProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ownershipForms == null)
            {
                return Problem("Entity set 'CinemaContext.ownershipForms'  is null.");
            }
            var ownershipForms = await _context.ownershipForms.FindAsync(id);
            if (ownershipForms != null)
            {
                _context.ownershipForms.Remove(ownershipForms);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnershipFormsExists(int id)
        {
            return (_context.ownershipForms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
