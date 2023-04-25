using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelephoneApp.Data;

namespace TelephoneApp.Controllers
{
    public class TelephoneApp1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelephoneApp1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TelephoneApp1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TelephoneApp.Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TelephoneApp1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TelephoneApp == null)
            {
                return NotFound();
            }

            var telephoneApp1 = await _context.TelephoneApp
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneApp1 == null)
            {
                return NotFound();
            }

            return View(telephoneApp1);
        }

        // GET: TelephoneApp1/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TelephoneApp1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name")] TelephoneApp1 telephoneApp1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telephoneApp1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", telephoneApp1.UserId);
            return View(telephoneApp1);
        }

        // GET: TelephoneApp1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TelephoneApp == null)
            {
                return NotFound();
            }

            var telephoneApp1 = await _context.TelephoneApp.FindAsync(id);
            if (telephoneApp1 == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", telephoneApp1.UserId);
            return View(telephoneApp1);
        }

        // POST: TelephoneApp1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name")] TelephoneApp1 telephoneApp1)
        {
            if (id != telephoneApp1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telephoneApp1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelephoneApp1Exists(telephoneApp1.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", telephoneApp1.UserId);
            return View(telephoneApp1);
        }

        // GET: TelephoneApp1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TelephoneApp == null)
            {
                return NotFound();
            }

            var telephoneApp1 = await _context.TelephoneApp
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneApp1 == null)
            {
                return NotFound();
            }

            return View(telephoneApp1);
        }

        // POST: TelephoneApp1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TelephoneApp == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TelephoneApp'  is null.");
            }
            var telephoneApp1 = await _context.TelephoneApp.FindAsync(id);
            if (telephoneApp1 != null)
            {
                _context.TelephoneApp.Remove(telephoneApp1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelephoneApp1Exists(int id)
        {
          return (_context.TelephoneApp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
