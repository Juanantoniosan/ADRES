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
    public class AdquisicionesController : Controller
    {
        private readonly AdquisicionesContext _context;

        public AdquisicionesController(AdquisicionesContext context)
        {
            _context = context;
        }

        // GET: Adquisiciones
        public async Task<IActionResult> Index()
        {
            var adquisicionesContext = _context.Adquisiciones.Include(a => a.Proveedor).Include(a => a.TipoBienoServicio).Include(a => a.Unidad);
            return View(await adquisicionesContext.ToListAsync());
        }

        // GET: Adquisiciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adquisicione = await _context.Adquisiciones
                .Include(a => a.Proveedor)
                .Include(a => a.TipoBienoServicio)
                .Include(a => a.Unidad)
                .FirstOrDefaultAsync(m => m.AdquisicionId == id);
            if (adquisicione == null)
            {
                return NotFound();
            }

            return View(adquisicione);
        }

        // GET: Adquisiciones/Create
        public IActionResult Create()
        {
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "NombreEntidad");
            ViewData["TipoBienoServicioId"] = new SelectList(_context.TipoBienoServicios, "TipoBienoServicioId", "Descripcion");
            ViewData["UnidadId"] = new SelectList(_context.Unidads, "UnidadId", "NombreUnidad");
            return View();
        }

        // POST: Adquisiciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdquisicionId,Presupuesto,UnidadId,TipoBienoServicioId,Cantidad,ValorUnitario,ValorTotal,FechaAdquisicion,ProveedorId,Documentacion")] Adquisicione adquisicione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adquisicione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "NombreEntidad", adquisicione.ProveedorId);
            ViewData["TipoBienoServicioId"] = new SelectList(_context.TipoBienoServicios, "TipoBienoServicioId", "Descripcion", adquisicione.TipoBienoServicioId);
            ViewData["UnidadId"] = new SelectList(_context.Unidads, "UnidadId", "NombreUnidad", adquisicione.UnidadId);
            return View(adquisicione);
        }

        // GET: Adquisiciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adquisicione = await _context.Adquisiciones.FindAsync(id);
            if (adquisicione == null)
            {
                return NotFound();
            }
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "ProveedorId", adquisicione.ProveedorId);
            ViewData["TipoBienoServicioId"] = new SelectList(_context.TipoBienoServicios, "TipoBienoServicioId", "TipoBienoServicioId", adquisicione.TipoBienoServicioId);
            ViewData["UnidadId"] = new SelectList(_context.Unidads, "UnidadId", "UnidadId", adquisicione.UnidadId);
            return View(adquisicione);
        }

        // POST: Adquisiciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdquisicionId,Presupuesto,UnidadId,TipoBienoServicioId,Cantidad,ValorUnitario,ValorTotal,FechaAdquisicion,ProveedorId,Documentacion")] Adquisicione adquisicione)
        {
            if (id != adquisicione.AdquisicionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adquisicione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdquisicioneExists(adquisicione.AdquisicionId))
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
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "ProveedorId", adquisicione.ProveedorId);
            ViewData["TipoBienoServicioId"] = new SelectList(_context.TipoBienoServicios, "TipoBienoServicioId", "TipoBienoServicioId", adquisicione.TipoBienoServicioId);
            ViewData["UnidadId"] = new SelectList(_context.Unidads, "UnidadId", "UnidadId", adquisicione.UnidadId);
            return View(adquisicione);
        }

        // GET: Adquisiciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adquisicione = await _context.Adquisiciones
                .Include(a => a.Proveedor)
                .Include(a => a.TipoBienoServicio)
                .Include(a => a.Unidad)
                .FirstOrDefaultAsync(m => m.AdquisicionId == id);
            if (adquisicione == null)
            {
                return NotFound();
            }

            return View(adquisicione);
        }

        // POST: Adquisiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adquisicione = await _context.Adquisiciones.FindAsync(id);
            if (adquisicione != null)
            {
                _context.Adquisiciones.Remove(adquisicione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdquisicioneExists(int id)
        {
            return _context.Adquisiciones.Any(e => e.AdquisicionId == id);
        }
    }
}
