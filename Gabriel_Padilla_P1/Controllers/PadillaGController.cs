using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gabriel_Padilla_P1.Data;
using Gabriel_Padilla_P1.Models;

namespace Gabriel_Padilla_P1.Controllers
{
    public class PadillaGController : Controller
    {
        private readonly Gabriel_Padilla_P1Context _context;

        public PadillaGController(Gabriel_Padilla_P1Context context)
        {
            _context = context;
        }

        // GET: PadillaG
        public async Task<IActionResult> Index()
        {
            var gabriel_Padilla_P1Context = _context.PadillaG.Include(p => p.Carrera);
            return View(await gabriel_Padilla_P1Context.ToListAsync());
        }

        // GET: PadillaG/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padillaG = await _context.PadillaG
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padillaG == null)
            {
                return NotFound();
            }

            return View(padillaG);
        }

        // GET: PadillaG/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Campus");
            return View();
        }

        // POST: PadillaG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Estatura,EsActivo,FechaNacimiento,CarreraId")] PadillaG padillaG)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padillaG);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Campus", padillaG.CarreraId);
            return View(padillaG);
        }

        // GET: PadillaG/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padillaG = await _context.PadillaG.FindAsync(id);
            if (padillaG == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Campus", padillaG.CarreraId);
            return View(padillaG);
        }

        // POST: PadillaG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Estatura,EsActivo,FechaNacimiento,CarreraId")] PadillaG padillaG)
        {
            if (id != padillaG.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padillaG);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadillaGExists(padillaG.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Campus", padillaG.CarreraId);
            return View(padillaG);
        }

        // GET: PadillaG/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padillaG = await _context.PadillaG
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (padillaG == null)
            {
                return NotFound();
            }

            return View(padillaG);
        }

        // POST: PadillaG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padillaG = await _context.PadillaG.FindAsync(id);
            if (padillaG != null)
            {
                _context.PadillaG.Remove(padillaG);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadillaGExists(int id)
        {
            return _context.PadillaG.Any(e => e.Id == id);
        }
    }
}
