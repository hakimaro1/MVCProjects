using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCreditApp1.Data;
using MvcCreditApp1.Models;

namespace MvcCreditApp1.Controllers
{
    public class CreditsController : Controller
    {
        private readonly CreditContext _context;

        public CreditsController(CreditContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Credits.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var credit = await _context.Credits.FirstOrDefaultAsync(m => m.CreditId == id);
            if (credit == null)
                return NotFound();

            return View(credit);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditId,Head,Period,Sum,Procent")] Credit credit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(credit);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
                return NotFound();

            return View(credit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditId,Head,Period,Sum,Procent")] Credit credit)
        {
            if (id != credit.CreditId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.CreditId))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(credit);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var credit = await _context.Credits.FirstOrDefaultAsync(m => m.CreditId == id);
            if (credit == null)
                return NotFound();

            return View(credit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            if (credit != null)
                _context.Credits.Remove(credit);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditExists(int id)
        {
            return _context.Credits.Any(e => e.CreditId == id);
        }
    }
}