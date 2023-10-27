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
    public class DevolucaoController : Controller
    {
        private readonly Contexto _context;

        public DevolucaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Devolucao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Devolução
                           .Include(d => d.Emprestimo)
                           .Include(d => d.Emprestimo.Pessoa)
                           .Include(d=> d.Emprestimo.Livro);

            foreach(var item in contexto)            
                item.Emprestimo.DescricaoEmprestimo = RetornaDescricaoEmprestimo(item.Emprestimo);
            
            return View(await contexto.ToListAsync());
        }

        // GET: Devolucao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devolução == null)
            {
                return NotFound();
            }

            var devolucao = await _context.Devolução
                .Include(d => d.Emprestimo)
                .FirstOrDefaultAsync(m => m.DevolucaoId == id);
            if (devolucao == null)
            {
                return NotFound();
            }

            return View(devolucao);
        }

        // GET: Devolucao/Create
        public IActionResult Create()
        {
            List<Emprestimo> emprestimo = RetornaEmprestimos();
            ViewData["EmprestimoId"] = new SelectList(emprestimo, "EmprestimoId", "DescricaoEmprestimo");
            return View();
        }

        // POST: Devolucao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevolucaoId,EmprestimoId,DataDevolucao")] Devolucao devolucao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devolucao);
                var emprestimo = await _context.Empréstimo.FindAsync(devolucao.EmprestimoId);
                emprestimo.Devolvido = true;
                _context.Update(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmprestimoId"] = new SelectList(_context.Empréstimo, "EmprestimoId", "DescricaoEmprestimo", devolucao.EmprestimoId);
            return View(devolucao);
        }

        // GET: Devolucao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devolução == null)
            {
                return NotFound();
            }

            var devolucao = await _context.Devolução.FindAsync(id);
            if (devolucao == null)
            {
                return NotFound();
            }
            ViewData["EmprestimoId"] = new SelectList(_context.Empréstimo, "EmprestimoId", "EmprestimoId", devolucao.EmprestimoId);
            return View(devolucao);
        }

        // POST: Devolucao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevolucaoId,EmprestimoId,DataDevolucao")] Devolucao devolucao)
        {
            if (id != devolucao.DevolucaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devolucao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevolucaoExists(devolucao.DevolucaoId))
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
            ViewData["EmprestimoId"] = new SelectList(_context.Empréstimo, "EmprestimoId", "EmprestimoId", devolucao.EmprestimoId);
            return View(devolucao);
        }

        // GET: Devolucao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devolução == null)
            {
                return NotFound();
            }

            var devolucao = await _context.Devolução
                .Include(d => d.Emprestimo)
                .FirstOrDefaultAsync(m => m.DevolucaoId == id);
            if (devolucao == null)
            {
                return NotFound();
            }

            return View(devolucao);
        }

        // POST: Devolucao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devolução == null)
            {
                return Problem("Entity set 'Contexto.Devolução'  is null.");
            }
            var devolucao = await _context.Devolução.FindAsync(id);
            if (devolucao != null)
            {
                _context.Devolução.Remove(devolucao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevolucaoExists(int id)
        {
          return (_context.Devolução?.Any(e => e.DevolucaoId == id)).GetValueOrDefault();
        }

        public List<Emprestimo> RetornaEmprestimos()
        {
            var emprestimo = _context.Empréstimo
                             .Include(x => x.Pessoa)
                             .Include(x => x.Livro)
                             .Where(x => x.Devolvido == false).ToList();

            foreach(var item in emprestimo)            
                item.DescricaoEmprestimo = item.Pessoa.PessoaNome + " - " + 
                                          item.Livro.LivroNome + " - " + 
                                          item.DataEmprestimo + " - " +
                                          item.DevolucaoPrevista;

            return (List<Emprestimo>)emprestimo;
        }

        public string RetornaDescricaoEmprestimo(Emprestimo emprestimo)
        {
            string descricao = emprestimo.Pessoa.PessoaNome + " - " +
                               emprestimo.Livro.LivroNome + " - " +
                               emprestimo.DataEmprestimo + " - " +
                               emprestimo.DevolucaoPrevista;
            return descricao;
        }
    }
}
