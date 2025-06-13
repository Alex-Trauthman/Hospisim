using Hospisim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospisim.Data;
using Hospisim.Domain.Entities;

namespace Hospisim.Controllers
{
    public class ExamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Exames
        public async Task<IActionResult> Index()
        {
            var exames = await _context.Exames
                .Include(e => e.Atendimento)
                    .ThenInclude(a => a.Paciente)
                .Include(e => e.Atendimento)
                    .ThenInclude(a => a.ProfissionalSaude)
                .ToListAsync();
            return View(exames);
        }

        // GET: Exames/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exames
                .Include(e => e.Atendimento)
                    .ThenInclude(a => a.Paciente)
                .Include(e => e.Atendimento)
                    .ThenInclude(a => a.ProfissionalSaude)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // GET: Exames/Create
        public IActionResult Create()
        {
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimentos
                .Include(a => a.Paciente)
                .Select(a => new { a.Id, Descricao = $"{a.DataHora:dd/MM/yyyy} - {a.Paciente.NomeCompleto}" }), 
                "Id", "Descricao");
            return View();
        }

        // POST: Exames/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AtendimentoId,Tipo,DataSolicitacao,DataRealizacao,Resultado")] Exame exame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimentos
                .Include(a => a.Paciente)
                .Select(a => new { a.Id, Descricao = $"{a.DataHora:dd/MM/yyyy} - {a.Paciente.NomeCompleto}" }), 
                "Id", "Descricao", exame.AtendimentoId);
            return View(exame);
        }

        // GET: Exames/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exames.FindAsync(id);
            if (exame == null)
            {
                return NotFound();
            }
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimentos
                .Include(a => a.Paciente)
                .Select(a => new { a.Id, Descricao = $"{a.DataHora:dd/MM/yyyy} - {a.Paciente.NomeCompleto}" }), 
                "Id", "Descricao", exame.AtendimentoId);
            return View(exame);
        }

        // POST: Exames/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AtendimentoId,Tipo,DataSolicitacao,DataRealizacao,Resultado")] Exame exame)
        {
            if (id != exame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExameExists(exame.Id))
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
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimentos
                .Include(a => a.Paciente)
                .Select(a => new { a.Id, Descricao = $"{a.DataHora:dd/MM/yyyy} - {a.Paciente.NomeCompleto}" }), 
                "Id", "Descricao", exame.AtendimentoId);
            return View(exame);
        }

        // GET: Exames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exame = await _context.Exames
                .Include(e => e.Atendimento)
                    .ThenInclude(a => a.Paciente)
                .Include(e => e.Atendimento)
                    .ThenInclude(a => a.ProfissionalSaude)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (exame == null)
            {
                return NotFound();
            }

            return View(exame);
        }

        // POST: Exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exame = await _context.Exames.FindAsync(id);
            if (exame != null)
            {
                _context.Exames.Remove(exame);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ExameExists(Guid id)
        {
            return _context.Exames.Any(e => e.Id == id);
        }
    }
}