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
    public class PatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Patch.Include(p => p.Garden);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Patches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patch = await _context.Patch
                .Include(p => p.Garden)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patch == null)
            {
                return NotFound();
            }

            return View(patch);
        }

        // GET: Patches/Create
        public IActionResult Create()
        {
            ViewData["GardenId"] = new SelectList(_context.Garden, "Id", "Id");
            return View();
        }

        // POST: Patches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatchName,Crop,GardenId")] Patch patch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GardenId"] = new SelectList(_context.Garden, "Id", "Id", patch.GardenId);
            return View(patch);
        }

        // GET: Patches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patch = await _context.Patch.FindAsync(id);
            if (patch == null)
            {
                return NotFound();
            }
            ViewData["GardenId"] = new SelectList(_context.Garden, "Id", "Id", patch.GardenId);
            return View(patch);
        }

        // POST: Patches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatchName,Crop,GardenId")] Patch patch)
        {
            if (id != patch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatchExists(patch.Id))
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
            ViewData["GardenId"] = new SelectList(_context.Garden, "Id", "Id", patch.GardenId);
            return View(patch);
        }

        // GET: Patches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patch = await _context.Patch
                .Include(p => p.Garden)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patch == null)
            {
                return NotFound();
            }

            return View(patch);
        }

        // POST: Patches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patch = await _context.Patch.FindAsync(id);
            _context.Patch.Remove(patch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatchExists(int id)
        {
            return _context.Patch.Any(e => e.Id == id);
        }
    }
}
