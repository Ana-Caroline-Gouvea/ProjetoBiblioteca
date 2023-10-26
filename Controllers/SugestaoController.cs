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
    public class SugestaoController : Controller
    {
        private readonly Contexto _context;

        public SugestaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Sugestao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Sugestão.Include(s => s.Pessoa);
            return View(await contexto.ToListAsync());
        }

        // GET: Sugestao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sugestão == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestão
                .Include(s => s.Pessoa)
                .FirstOrDefaultAsync(m => m.SugestaoId == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // GET: Sugestao/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaId");
            return View();
        }

        // POST: Sugestao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SugestaoId,PessoaId,DescSugestao")] Sugestao sugestao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sugestao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaId", sugestao.PessoaId);
            return View(sugestao);
        }

        // GET: Sugestao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sugestão == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestão.FindAsync(id);
            if (sugestao == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaId", sugestao.PessoaId);
            return View(sugestao);
        }

        // POST: Sugestao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SugestaoId,PessoaId,DescSugestao")] Sugestao sugestao)
        {
            if (id != sugestao.SugestaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugestao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugestaoExists(sugestao.SugestaoId))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaId", sugestao.PessoaId);
            return View(sugestao);
        }

        // GET: Sugestao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sugestão == null)
            {
                return NotFound();
            }

            var sugestao = await _context.Sugestão
                .Include(s => s.Pessoa)
                .FirstOrDefaultAsync(m => m.SugestaoId == id);
            if (sugestao == null)
            {
                return NotFound();
            }

            return View(sugestao);
        }

        // POST: Sugestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sugestão == null)
            {
                return Problem("Entity set 'Contexto.Sugestão'  is null.");
            }
            var sugestao = await _context.Sugestão.FindAsync(id);
            if (sugestao != null)
            {
                _context.Sugestão.Remove(sugestao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugestaoExists(int id)
        {
          return (_context.Sugestão?.Any(e => e.SugestaoId == id)).GetValueOrDefault();
        }
    }
}
