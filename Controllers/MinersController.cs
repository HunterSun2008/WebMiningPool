using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using WebMiningPool.Models;

namespace WebMiningPool.Controllers
{
    public class MinersController : Controller
    {
        private readonly MvcMovieContext _context;

        public MinersController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Miners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miners.ToListAsync());
        }

        // GET: Miners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miner = await _context.Miners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miner == null)
            {
                return NotFound();
            }

            return View(miner);
        }

        // GET: Miners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CalculationPow,RegisterDate")] Miner miner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miner);
        }

        // GET: Miners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miner = await _context.Miners.FindAsync(id);
            if (miner == null)
            {
                return NotFound();
            }
            return View(miner);
        }

        // POST: Miners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CalculationPow,RegisterDate")] Miner miner)
        {
            if (id != miner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinerExists(miner.Id))
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
            return View(miner);
        }

        // GET: Miners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miner = await _context.Miners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miner == null)
            {
                return NotFound();
            }

            return View(miner);
        }

        // POST: Miners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miner = await _context.Miners.FindAsync(id);
            _context.Miners.Remove(miner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinerExists(int id)
        {
            return _context.Miners.Any(e => e.Id == id);
        }
    }
}
