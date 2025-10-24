using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pdh_231230796_de01.Models;

namespace pdh_231230796_de01.Controllers
{
    public class PdhComputersController : Controller
    {
        private readonly pdhDbContext _context;

        public PdhComputersController(pdhDbContext context)
        {
            _context = context;
        }

        // GET: PdhComputers
        public async Task<IActionResult> PdhIndex()
        {
            return View(await _context.PdhComputers.ToListAsync());
        }

        // GET: PdhComputers/Details/5
        public async Task<IActionResult> PdhDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhComputer = await _context.PdhComputers
                .FirstOrDefaultAsync(m => m.PdhComId == id);
            if (pdhComputer == null)
            {
                return NotFound();
            }

            return View(pdhComputer);
        }

        // GET: PdhComputers/Create
        public IActionResult PdhCreate()
        {
            return View();
        }

        // POST: PdhComputers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdhCreate([Bind("PdhComId,PdhComName,PdhComPrice,PdhComImage,PdhComStatus")] PdhComputer pdhComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pdhComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(PdhIndex));
            }
            return View(pdhComputer);
        }

        // GET: PdhComputers/Edit/5
        public async Task<IActionResult> PdhEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhComputer = await _context.PdhComputers.FindAsync(id);
            if (pdhComputer == null)
            {
                return NotFound();
            }
            return View(pdhComputer);
        }

        // POST: PdhComputers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdhEdit(int id, [Bind("PdhComId,PdhComName,PdhComPrice,PdhComImage,PdhComStatus")] PdhComputer pdhComputer)
        {
            if (id != pdhComputer.PdhComId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pdhComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdhComputerExists(pdhComputer.PdhComId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(PdhIndex));
            }
            return View(pdhComputer);
        }

        // GET: PdhComputers/Delete/5
        public async Task<IActionResult> PdhDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdhComputer = await _context.PdhComputers
                .FirstOrDefaultAsync(m => m.PdhComId == id);
            if (pdhComputer == null)
            {
                return NotFound();
            }

            return View(pdhComputer);
        }

        // POST: PdhComputers/Delete/5
        [HttpPost, ActionName("PdhDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PdhDeleteConfirmed(int id)
        {
            var pdhComputer = await _context.PdhComputers.FindAsync(id);
            if (pdhComputer != null)
            {
                _context.PdhComputers.Remove(pdhComputer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PdhIndex));
        }

        private bool PdhComputerExists(int id)
        {
            return _context.PdhComputers.Any(e => e.PdhComId == id);
        }
    }
}
