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
    public class EmprestimoController : Controller
    {
        private readonly Contexto _context;

        public EmprestimoController(Contexto context)
        {
            _context = context;
        }

        // GET: Emprestimo
        public async Task<IActionResult> Index( string pesquisa)
        {
            if(pesquisa == null)
            {
                var contexto = _context.Empréstimo
                .Include(e => e.Livro)
                .Include(e => e.Pessoa);
                return View(await contexto.ToListAsync());
            }
            else
            {
                var contexto = _context.Empréstimo
               .Include(e => e.Livro)
               .Include(e => e.Pessoa)
               .Where(e=> e.Livro.LivroNome.Contains(pesquisa));
                return View(await contexto.ToListAsync());
            }
            
        }

        // GET: Emprestimo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empréstimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Empréstimo
                .Include(e => e.Livro)
                .Include(e => e.Pessoa)
                .FirstOrDefaultAsync(m => m.EmprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimo/Create
        public IActionResult Create()
        {
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroNome");
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome");
            return View();
        }

        // POST: Emprestimo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmprestimoId,PessoaId,LivroId,DataEmprestimo,DevolucaoPrevista,Devolvido")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroNome", emprestimo.LivroId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome", emprestimo.PessoaId);
            return View(emprestimo);
        }

        // GET: Emprestimo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empréstimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Empréstimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroNome", emprestimo.LivroId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome", emprestimo.PessoaId);
            return View(emprestimo);
        }

        // POST: Emprestimo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmprestimoId,PessoaId,LivroId,DataEmprestimo,DevolucaoPrevista,Devolvido")] Emprestimo emprestimo)
        {
            if (id != emprestimo.EmprestimoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.EmprestimoId))
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
            ViewData["LivroId"] = new SelectList(_context.Livro, "LivroId", "LivroNome", emprestimo.LivroId);
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome", emprestimo.PessoaId);
            return View(emprestimo);
        }

        // GET: Emprestimo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empréstimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Empréstimo
                .Include(e => e.Livro)
                .Include(e => e.Pessoa)
                .FirstOrDefaultAsync(m => m.EmprestimoId == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empréstimo == null)
            {
                return Problem("Entity set 'Contexto.Empréstimo'  is null.");
            }
            var emprestimo = await _context.Empréstimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Empréstimo.Remove(emprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
          return (_context.Empréstimo?.Any(e => e.EmprestimoId == id)).GetValueOrDefault();
        }
    }
}
