using Hospisim.Data;
using Hospisim.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Controllers
{
    public class ProntuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProntuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prontuarios
        public async Task<IActionResult> Index()
        {
            var prontuarios = await _context.Prontuarios
                .Include(p => p.Paciente)
                .ToListAsync();
            return View(prontuarios);
        }

        // GET: Prontuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios
                .Include(p => p.Paciente)
                .Include(p => p.Atendimentos)
                    .ThenInclude(a => a.ProfissionalSaude)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // GET: Prontuarios/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto");

            // Gerar número do prontuário automaticamente
            var ultimoProntuario = _context.Prontuarios
                .OrderByDescending(p => p.Numero)
                .FirstOrDefault();

            string novoNumero = "RONT-2024-0001";
            if (ultimoProntuario != null)
            {
                var partes = ultimoProntuario.Numero.Split('-');
                if (partes.Length == 3 && int.TryParse(partes[2], out int numeroAtual))
                {
                    novoNumero = $"RONT-2024-{(numeroAtual + 1).ToString("D4")}";
                }
            }

            ViewBag.NovoNumero = novoNumero;
            return View();
        }


        // POST: Prontuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Numero,PacienteId,DataAbertura,ObservacoesGerais")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                prontuario.Id = Guid.NewGuid();
                _context.Add(prontuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", prontuario.PacienteId);
            return View(prontuario);
        }

        // GET: Prontuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", prontuario.PacienteId);
            return View(prontuario);
        }

        // POST: Prontuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Numero,PacienteId,DataAbertura,ObservacoesGerais")] Prontuario prontuario)
        {
            if (id != prontuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioExists(prontuario.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "NomeCompleto", prontuario.PacienteId);
            return View(prontuario);
        }

        // GET: Prontuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios
                .Include(p => p.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // POST: Prontuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prontuario = await _context.Prontuarios.FindAsync(id);
            if (prontuario != null)
            {
                _context.Prontuarios.Remove(prontuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioExists(Guid id)
        {
            return _context.Prontuarios.Any(e => e.Id == id);
        }
    }
}