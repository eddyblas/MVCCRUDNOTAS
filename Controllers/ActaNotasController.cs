using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCrud.Models;

namespace MvcCrud.Controllers
{
    public class ActaNotasController : Controller
    {
        private readonly MvcCrudContext _context;

        public ActaNotasController(MvcCrudContext context)
        {
            _context = context;
        }

        // GET: ActaNotas
        public async Task<IActionResult> Index()
        {
              return View(await _context.ActaNotas.ToListAsync());
        }

        // GET: ActaNotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActaNotas == null)
            {
                return NotFound();
            }

            var actaNota = await _context.ActaNotas
                .FirstOrDefaultAsync(m => m.IdNotasE == id);
            if (actaNota == null)
            {
                return NotFound();
            }

            return View(actaNota);
        }

        // GET: ActaNotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActaNotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNotasE,Carnet,Nombre,Apellido,Ipn,Iipn,Siste,Proyect,Nf")] ActaNota actaNota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actaNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actaNota);
        }

        // GET: ActaNotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActaNotas == null)
            {
                return NotFound();
            }

            var actaNota = await _context.ActaNotas.FindAsync(id);
            if (actaNota == null)
            {
                return NotFound();
            }
            return View(actaNota);
        }

        // POST: ActaNotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNotasE,Carnet,Nombre,Apellido,Ipn,Iipn,Siste,Proyect,Nf")] ActaNota actaNota)
        {
            if (id != actaNota.IdNotasE)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actaNota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActaNotaExists(actaNota.IdNotasE))
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
            return View(actaNota);
        }

        // GET: ActaNotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActaNotas == null)
            {
                return NotFound();
            }

            var actaNota = await _context.ActaNotas
                .FirstOrDefaultAsync(m => m.IdNotasE == id);
            if (actaNota == null)
            {
                return NotFound();
            }

            return View(actaNota);
        }

        // POST: ActaNotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActaNotas == null)
            {
                return Problem("Entity set 'MvcCrudContext.ActaNotas'  is null.");
            }
            var actaNota = await _context.ActaNotas.FindAsync(id);
            if (actaNota != null)
            {
                _context.ActaNotas.Remove(actaNota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActaNotaExists(int id)
        {
          return _context.ActaNotas.Any(e => e.IdNotasE == id);
        }
    }
}
