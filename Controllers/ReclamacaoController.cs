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
    public class ReclamacaoController : Controller
    {
        private readonly Contexto _context;

        public ReclamacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Reclamacao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Reclamação.Include(r => r.Pessoa);

            if(contexto != null)
            {
                foreach (var item in contexto)
                {
                    string imageBase64Data = Convert.ToBase64String(inArray: item.LivroImagem);
                    item.ImgExibicao = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                }
                return View(await contexto.ToListAsync());
            }
            else
            {
                return View();
            }           
        }

        // GET: Reclamacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reclamação == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamação
                .Include(r => r.Pessoa)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacao == null)
            {
                return NotFound();
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(inArray: reclamacao.LivroImagem);
                reclamacao.ImgExibicao = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewData["ImgExibicao"] = reclamacao.ImgExibicao;
            }

            return View(reclamacao);
        }

        // GET: Reclamacao/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome");
            return View();
        }

        // POST: Reclamacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReclamacaoId,PessoaId,DescReclamacao,LivroImagem")] Reclamacao reclamacao)
        {            
            if (ModelState.IsValid)
            {
                foreach (var file in Request.Form.Files)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    reclamacao.LivroImagem = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                }
                _context.Add(reclamacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome", reclamacao.PessoaId);
            return View(reclamacao);
        }

        // GET: Reclamacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reclamação == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamação.FindAsync(id);
            if (reclamacao == null)
            {
                return NotFound();
            }
            else
            {                
                string imageBase64Data = Convert.ToBase64String(inArray: reclamacao.LivroImagem);
                reclamacao.ImgExibicao = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewData["ImgExibicao"] = reclamacao.ImgExibicao;
            }
            reclamacao.LivroImagem2 = reclamacao.LivroImagem;
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome", reclamacao.PessoaId);
            return View(reclamacao);
        }

        // POST: Reclamacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReclamacaoId,PessoaId,DescReclamacao,LivroImagem,LivroImagem2")] Reclamacao reclamacao)
        {
            if (id != reclamacao.ReclamacaoId)
            {
                return NotFound();
            }

            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                reclamacao.LivroImagem = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            if (reclamacao.LivroImagem == null)            
                reclamacao.LivroImagem = reclamacao.LivroImagem2;
            
               
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacaoExists(reclamacao.ReclamacaoId))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "PessoaNome", reclamacao.PessoaId);
            return View(reclamacao);
        }

        // GET: Reclamacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reclamação == null)
            {
                return NotFound();
            }

            var reclamacao = await _context.Reclamação
                .Include(r => r.Pessoa)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacao == null)
            {
                return NotFound();
            }
            else
            {
                string imageBase64Data = Convert.ToBase64String(inArray: reclamacao.LivroImagem);
                reclamacao.ImgExibicao = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewData["ImgExibicao"] = reclamacao.ImgExibicao;
            }

            return View(reclamacao);
        }

        // POST: Reclamacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reclamação == null)
            {
                return Problem("Entity set 'Contexto.Reclamação'  is null.");
            }
            var reclamacao = await _context.Reclamação.FindAsync(id);
            if (reclamacao != null)
            {
                _context.Reclamação.Remove(reclamacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamacaoExists(int id)
        {
          return (_context.Reclamação?.Any(e => e.ReclamacaoId == id)).GetValueOrDefault();
        }
    }
}
