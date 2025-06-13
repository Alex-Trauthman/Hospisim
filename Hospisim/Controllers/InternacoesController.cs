using Hospisim.Domain.Entities;
using Hospisim.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Controllers
{
    public class InternacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InternacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Internacoes
        public async Task<IActionResult> Index()
        {
            var internacoes = await _context.Internacoes
                .Include(i => i.Paciente)
                .Include(i => i.Atendimento)
                .ToListAsync();
            return View(internacoes);
        }

        // GET: Internacoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var internacao = await _context.Internacoes
                .Include(i => i.Paciente)
                .Include(i => i.Atendimento)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (internacao == null)
                return NotFound();

            return View(internacao);
        }

        // GET: Internacoes/Create
        public IActionResult Create()
        {
            CarregarViewBags();
            return View();
        }

        // POST: Internacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
            "PacienteId,AtendimentoId,DataEntrada,PrevisaoAlta,MotivoInternacao,Quarto,Leito,Setor,PlanoSaudeUtilizado,ObservacoesClinicas,StatusInternacao")] Internacao internacao)
        {
            if (ModelState.IsValid)
            {
                internacao.Id = Guid.NewGuid(); // garante Id novo
                _context.Add(internacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CarregarViewBags(internacao.PacienteId, internacao.AtendimentoId);
            return View(internacao);
        }

        // GET: Internacoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var internacao = await _context.Internacoes.FindAsync(id);
            if (internacao == null)
                return NotFound();

            CarregarViewBags(internacao.PacienteId, internacao.AtendimentoId);
            return View(internacao);
        }

        // POST: Internacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind(
            "Id,PacienteId,AtendimentoId,DataEntrada,PrevisaoAlta,MotivoInternacao,Quarto,Leito,Setor,PlanoSaudeUtilizado,ObservacoesClinicas,StatusInternacao")] Internacao internacao)
        {
            if (id != internacao.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(internacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternacaoExists(internacao.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            CarregarViewBags(internacao.PacienteId, internacao.AtendimentoId);
            return View(internacao);
        }

        // GET: Internacoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var internacao = await _context.Internacoes
                .Include(i => i.Paciente)
                .Include(i => i.Atendimento)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (internacao == null)
                return NotFound();

            return View(internacao);
        }

        // POST: Internacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var internacao = await _context.Internacoes.FindAsync(id);
            if (internacao != null)
            {
                _context.Internacoes.Remove(internacao);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool InternacaoExists(Guid id)
        {
            return _context.Internacoes.Any(e => e.Id == id);
        }

        private void CarregarViewBags(Guid? pacienteId = null, Guid? atendimentoId = null)
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes.OrderBy(p => p.NomeCompleto), "Id", "NomeCompleto", pacienteId);
            ViewData["AtendimentoId"] = new SelectList(_context.Atendimentos.OrderBy(a => a.Id), "Id", "Id", atendimentoId);
        }
    }
}
