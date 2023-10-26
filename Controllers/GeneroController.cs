using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    public class GeneroController : Controller
    {
        private readonly Contexto _context;

        public GeneroController(Contexto context)
        {
            _context = context;
        }

        // GET: Genero
        public async Task<IActionResult> Index()
        {
              return _context.Genêro != null ? 
                          View(await _context
                                     .Genêro.OrderBy(x=> x.GeneroNome).ToListAsync()) :
                          Problem("Entity set 'Contexto.Genêro'  is null.");
        }

        // GET: Genero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Genêro == null)
            {
                return NotFound();
            }

            var genero = await _context.Genêro
                .FirstOrDefaultAsync(m => m.GeneroId == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // GET: Genero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneroId,GeneroNome")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: Genero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Genêro == null)
            {
                return NotFound();
            }

            var genero = await _context.Genêro.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: Genero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneroId,GeneroNome")] Genero genero)
        {
            if (id != genero.GeneroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroExists(genero.GeneroId))
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
            return View(genero);
        }

        // GET: Genero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Genêro == null)
            {
                return NotFound();
            }

            var genero = await _context.Genêro
                .FirstOrDefaultAsync(m => m.GeneroId == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: Genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Genêro == null)
            {
                return Problem("Entity set 'Contexto.Genêro'  is null.");
            }
            var genero = await _context.Genêro.FindAsync(id);
            if (genero != null)
            {
                _context.Genêro.Remove(genero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroExists(int id)
        {
          return (_context.Genêro?.Any(e => e.GeneroId == id)).GetValueOrDefault();
        }
    }
}
