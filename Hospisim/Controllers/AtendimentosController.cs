using Hospisim.Data;
using Hospisim.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Controllers
{
    public class AtendimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtendimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atendimentos
        public async Task<IActionResult> Index()
        {
            var atendimentos = await _context.Atendimentos
                .Include(a => a.Paciente)
                .Include(a => a.ProfissionalSaude)
                .Include(a => a.Prontuario)
                .OrderByDescending(a => a.DataHora)
                .ToListAsync();
            return View(atendimentos);
        }

        // GET: Atendimentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimentos
                .Include(a => a.Paciente)
                .Include(a => a.ProfissionalSaude)
                    .ThenInclude(p => p.Especialidade)
                .Include(a => a.Prontuario)
                .Include(a => a.Prescricoes)
                .Include(a => a.Exames)
                .Include(a => a.Internacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public IActionResult Create(Guid? prontuarioId)
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto");
            ViewData["ProfissionalSaudeId"] = new SelectList(_context.ProfissionaisSaude.Where(p => p.Ativo), "Id", "NomeCompleto");
            ViewData["ProntuarioId"] = new SelectList(_context.Prontuarios.Include(p => p.Paciente), "Id", "Numero");

            if (prontuarioId.HasValue)
            {
                var prontuario = _context.Prontuarios.Include(p => p.Paciente).FirstOrDefault(p => p.Id == prontuarioId);
                if (prontuario != null)
                {
                    ViewBag.ProntuarioSelecionado = prontuarioId;
                    ViewBag.PacienteSelecionado = prontuario.PacienteId;
                }
            }

            return View();
        }

        // POST: Atendimentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataHora,Tipo,PacienteId,ProfissionalSaudeId,ProntuarioId,Local,Status")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                atendimento.Id = Guid.NewGuid();
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = atendimento.Id });
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", atendimento.PacienteId);
            ViewData["ProfissionalSaudeId"] = new SelectList(_context.ProfissionaisSaude.Where(p => p.Ativo), "Id", "NomeCompleto", atendimento.ProfissionalSaudeId);
            ViewData["ProntuarioId"] = new SelectList(_context.Prontuarios.Include(p => p.Paciente), "Id", "Numero", atendimento.ProntuarioId);
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", atendimento.PacienteId);
            ViewData["ProfissionalSaudeId"] = new SelectList(_context.ProfissionaisSaude.Where(p => p.Ativo), "Id", "NomeCompleto", atendimento.ProfissionalSaudeId);
            ViewData["ProntuarioId"] = new SelectList(_context.Prontuarios.Include(p => p.Paciente), "Id", "Numero", atendimento.ProntuarioId);
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DataHora,Tipo,PacienteId,ProfissionalSaudeId,ProntuarioId,Local,Status")] Atendimento atendimento)
        {
            if (id != atendimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", atendimento.PacienteId);
            ViewData["ProfissionalSaudeId"] = new SelectList(_context.ProfissionaisSaude.Where(p => p.Ativo), "Id", "NomeCompleto", atendimento.ProfissionalSaudeId);
            ViewData["ProntuarioId"] = new SelectList(_context.Prontuarios.Include(p => p.Paciente), "Id", "Numero", atendimento.ProntuarioId);
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimentos
                .Include(a => a.Paciente)
                .Include(a => a.ProfissionalSaude)
                .Include(a => a.Prontuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(Guid id)
        {
            return _context.Atendimentos.Any(e => e.Id == id);
        }
    }
}