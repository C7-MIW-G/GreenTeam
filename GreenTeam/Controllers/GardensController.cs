#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenTeam.Data;
using GreenTeam.Models;

namespace GreenTeam.Controllers
{
    public class GardensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GardensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gardens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Garden.ToListAsync());
        }

        // GET: Gardens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Garden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garden == null)
            {
                return NotFound();
            }

            return View(garden);
        }

        // GET: Gardens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gardens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,SizeInSqm")] Garden garden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garden);
        }

        // GET: Gardens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Garden.FindAsync(id);
            if (garden == null)
            {
                return NotFound();
            }
            return View(garden);
        }

        // POST: Gardens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,SizeInSqm")] Garden garden)
        {
            if (id != garden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenExists(garden.Id))
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
            return View(garden);
        }

        // GET: Gardens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garden = await _context.Garden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garden == null)
            {
                return NotFound();
            }

            return View(garden);
        }

        // POST: Gardens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garden = await _context.Garden.FindAsync(id);
            _context.Garden.Remove(garden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenExists(int id)
        {
            return _context.Garden.Any(e => e.Id == id);
        }
    }
}
