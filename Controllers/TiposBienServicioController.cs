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
    public class TiposBienServicioController : Controller
    {
        private readonly AdquisicionesContext _context;

        public TiposBienServicioController(AdquisicionesContext context)
        {
            _context = context;
        }

        // GET: TiposBienServicio
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoBienoServicios.ToListAsync());
        }

        // GET: TiposBienServicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBienoServicio = await _context.TipoBienoServicios
                .FirstOrDefaultAsync(m => m.TipoBienoServicioId == id);
            if (tipoBienoServicio == null)
            {
                return NotFound();
            }

            return View(tipoBienoServicio);
        }

        // GET: TiposBienServicio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposBienServicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoBienoServicioId,Descripcion")] TipoBienoServicio tipoBienoServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoBienoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoBienoServicio);
        }

        // GET: TiposBienServicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBienoServicio = await _context.TipoBienoServicios.FindAsync(id);
            if (tipoBienoServicio == null)
            {
                return NotFound();
            }
            return View(tipoBienoServicio);
        }

        // POST: TiposBienServicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoBienoServicioId,Descripcion")] TipoBienoServicio tipoBienoServicio)
        {
            if (id != tipoBienoServicio.TipoBienoServicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoBienoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoBienoServicioExists(tipoBienoServicio.TipoBienoServicioId))
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
            return View(tipoBienoServicio);
        }

        // GET: TiposBienServicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBienoServicio = await _context.TipoBienoServicios
                .FirstOrDefaultAsync(m => m.TipoBienoServicioId == id);
            if (tipoBienoServicio == null)
            {
                return NotFound();
            }

            return View(tipoBienoServicio);
        }

        // POST: TiposBienServicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoBienoServicio = await _context.TipoBienoServicios.FindAsync(id);
            if (tipoBienoServicio != null)
            {
                _context.TipoBienoServicios.Remove(tipoBienoServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoBienoServicioExists(int id)
        {
            return _context.TipoBienoServicios.Any(e => e.TipoBienoServicioId == id);
        }
    }
}
