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
    public class TelephoneAppListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelephoneAppListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TelephoneAppLists
        public async Task<IActionResult> Index()
        {
              return _context.TelephoneAppList != null ? 
                          View(await _context.TelephoneAppList.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TelephoneAppList'  is null.");
        }

        // GET: TelephoneAppLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TelephoneAppList == null)
            {
                return NotFound();
            }

            var telephoneAppList = await _context.TelephoneAppList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneAppList == null)
            {
                return NotFound();
            }

            return View(telephoneAppList);
        }

        // GET: TelephoneAppLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelephoneAppLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TelephoneNumber,LastCall")] TelephoneAppList telephoneAppList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telephoneAppList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telephoneAppList);
        }

        // GET: TelephoneAppLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TelephoneAppList == null)
            {
                return NotFound();
            }

            var telephoneAppList = await _context.TelephoneAppList.FindAsync(id);
            if (telephoneAppList == null)
            {
                return NotFound();
            }
            return View(telephoneAppList);
        }

        // POST: TelephoneAppLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TelephoneNumber,LastCall")] TelephoneAppList telephoneAppList)
        {
            if (id != telephoneAppList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telephoneAppList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelephoneAppListExists(telephoneAppList.Id))
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
            return View(telephoneAppList);
        }

        // GET: TelephoneAppLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TelephoneAppList == null)
            {
                return NotFound();
            }

            var telephoneAppList = await _context.TelephoneAppList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneAppList == null)
            {
                return NotFound();
            }

            return View(telephoneAppList);
        }

        // POST: TelephoneAppLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TelephoneAppList == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TelephoneAppList'  is null.");
            }
            var telephoneAppList = await _context.TelephoneAppList.FindAsync(id);
            if (telephoneAppList != null)
            {
                _context.TelephoneAppList.Remove(telephoneAppList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelephoneAppListExists(int id)
        {
          return (_context.TelephoneAppList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
