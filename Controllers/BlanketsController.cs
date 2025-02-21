﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CozyCloudBlanket.Data;
using CozyCloudBlanket.Models;

namespace CozyCloudBlanket.Controllers
{
    public class BlanketsController : Controller
    {
        private readonly CozyCloudBlanketContext _context;
        //private readonly DbContextOptions<CozyCloudBlanket> dbContextOptions;

        public BlanketsController(CozyCloudBlanketContext context)
        {
            _context = context;
        }

        //public BlanketsController(DbContextOptions<CozyCloudBlanket> dbContextOptions)
        //{
        //    this.dbContextOptions = dbContextOptions;
        //}

        // GET: Blankets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blanket.ToListAsync());
        }

        // GET: Blankets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blanket = await _context.Blanket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blanket == null)
            {
                return NotFound();
            }

            return View(blanket);
        }

        // GET: Blankets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blankets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Size,Price,Material,Color")] Blanket blanket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blanket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blanket);
        }

        // GET: Blankets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blanket = await _context.Blanket.FindAsync(id);
            if (blanket == null)
            {
                return NotFound();
            }
            return View(blanket);
        }

        // POST: Blankets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Size,Price,Material,Color")] Blanket blanket)
        {
            if (id != blanket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blanket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlanketExists(blanket.Id))
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
            return View(blanket);
        }

        // GET: Blankets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blanket = await _context.Blanket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blanket == null)
            {
                return NotFound();
            }

            return View(blanket);
        }

        // POST: Blankets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blanket = await _context.Blanket.FindAsync(id);
            if (blanket != null)
            {
                _context.Blanket.Remove(blanket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlanketExists(int id)
        {
            return _context.Blanket.Any(e => e.Id == id);
        }
    }
}
