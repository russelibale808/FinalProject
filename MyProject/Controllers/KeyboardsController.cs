using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class KeyboardsController : Controller
    {
        private readonly RusselContext _context;

        public KeyboardsController(RusselContext context)
        {
            _context = context;
        }

        // GET: Keyboards
        public async Task<IActionResult> Index()
        {
            return _context.Keyboards != null ?
                        View(await _context.Keyboards.ToListAsync()) :
                        Problem("Entity set 'RusselContext.Keyboards'  is null.");
        }

        // GET: Keyboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Keyboards == null)
            {
                return NotFound();
            }

            var keyboard = await _context.Keyboards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (keyboard == null)
            {
                return NotFound();
            }

            return View(keyboard);
        }

        // GET: Keyboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Keyboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Url,Brand,Size,Description")] Keyboard keyboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyboard);
        }

        // GET: Keyboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Keyboards == null)
            {
                return NotFound();
            }

            var keyboard = await _context.Keyboards.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound();
            }
            return View(keyboard);
        }

        // POST: Keyboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Url,Brand,Size,Description")] Keyboard keyboard)
        {
            if (id != keyboard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeyboardExists(keyboard.ID))
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
            return View(keyboard);
        }

        // GET: Keyboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Keyboards == null)
            {
                return NotFound();
            }

            var keyboard = await _context.Keyboards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (keyboard == null)
            {
                return NotFound();
            }

            return View(keyboard);
        }

        // POST: Keyboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Keyboards == null)
            {
                return Problem("Entity set 'RusselContext.Keyboards'  is null.");
            }
            var keyboard = await _context.Keyboards.FindAsync(id);
            if (keyboard != null)
            {
                _context.Keyboards.Remove(keyboard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeyboardExists(int id)
        {
            return (_context.Keyboards?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
