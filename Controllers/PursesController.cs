using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurseMvc.Data;
using PurseMvc.Models;

namespace PurseMvc.Controllers
{
    public class PursesController : Controller
    {
        private readonly PurseMvcContext _context;

        public PursesController(PurseMvcContext context)
        {
            _context = context;
        }

        // GET: Purses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purse.ToListAsync());
        }

        // GET: Purses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purse = await _context.Purse
                .FirstOrDefaultAsync(m => m.id == id);
            if (purse == null)
            {
                return NotFound();
            }

            return View(purse);
        }

        // GET: Purses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Product,Style,Price,Color,Material,ReleaseDate,CustomerReview")] Purse purse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purse);
        }

        // GET: Purses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purse = await _context.Purse.FindAsync(id);
            if (purse == null)
            {
                return NotFound();
            }
            return View(purse);
        }

        // POST: Purses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Product,Style,Price,Color,Material,ReleaseDate,CustomerReview")] Purse purse)
        {
            if (id != purse.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurseExists(purse.id))
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
            return View(purse);
        }

        // GET: Purses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purse = await _context.Purse
                .FirstOrDefaultAsync(m => m.id == id);
            if (purse == null)
            {
                return NotFound();
            }

            return View(purse);
        }

        // POST: Purses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purse = await _context.Purse.FindAsync(id);
            _context.Purse.Remove(purse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurseExists(int id)
        {
            return _context.Purse.Any(e => e.id == id);
        }
    }
}
