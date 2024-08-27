using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaAdres.Modelo;

namespace PruebaAdres.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly AdquisicionesContext _context;

        public UnidadesController(AdquisicionesContext context)
        {
            _context = context;
        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidads.ToListAsync());
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads
                .FirstOrDefaultAsync(m => m.UnidadId == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnidadId,NombreUnidad")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            return View(unidad);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnidadId,NombreUnidad")] Unidad unidad)
        {
            if (id != unidad.UnidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.UnidadId))
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
            return View(unidad);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads
                .FirstOrDefaultAsync(m => m.UnidadId == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad = await _context.Unidads.FindAsync(id);
            if (unidad != null)
            {
                _context.Unidads.Remove(unidad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
            return _context.Unidads.Any(e => e.UnidadId == id);
        }
    }
}
