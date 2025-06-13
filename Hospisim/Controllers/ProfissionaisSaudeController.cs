using Hospisim.Data;
using Hospisim.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospisim.Controllers
{
    public class ProfissionaisSaudeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfissionaisSaudeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfissionaisSaude
        public async Task<IActionResult> Index()
        {
            var profissionais = await _context.ProfissionaisSaude
                .Include(p => p.Especialidade)
                .ToListAsync();
            return View(profissionais);
        }

        // GET: ProfissionaisSaude/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var profissionalSaude = await _context.ProfissionaisSaude
                .Include(p => p.Especialidade)
                .Include(p => p.Atendimentos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (profissionalSaude == null) return NotFound();

            return View(profissionalSaude);
        }

        // GET: ProfissionaisSaude/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome");
            return View();
        }

        // POST: ProfissionaisSaude/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeCompleto,CPF,Email,Telefone,RegistroConselho,TipoRegistro,EspecialidadeId,DataAdmissao,CargaHorariaSemanal,Turno,Ativo")] ProfissionalSaude profissionalSaude)
        {
            if (ModelState.IsValid)
            {
                profissionalSaude.Id = Guid.NewGuid();
                _context.Add(profissionalSaude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalSaude.EspecialidadeId);
            return View(profissionalSaude);
        }

        // GET: ProfissionaisSaude/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var profissionalSaude = await _context.ProfissionaisSaude.FindAsync(id);
            if (profissionalSaude == null) return NotFound();

            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalSaude.EspecialidadeId);
            return View(profissionalSaude);
        }

        // POST: ProfissionaisSaude/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NomeCompleto,CPF,Email,Telefone,RegistroConselho,TipoRegistro,EspecialidadeId,DataAdmissao,CargaHorariaSemanal,Turno,Ativo")] ProfissionalSaude profissionalSaude)
        {
            if (id != profissionalSaude.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionalSaude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionalSaudeExists(profissionalSaude.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadeId"] = new SelectList(_context.Especialidades, "Id", "Nome", profissionalSaude.EspecialidadeId);
            return View(profissionalSaude);
        }

        // GET: ProfissionaisSaude/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var profissionalSaude = await _context.ProfissionaisSaude
                .Include(p => p.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profissionalSaude == null) return NotFound();

            return View(profissionalSaude);
        }

        // POST: ProfissionaisSaude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profissionalSaude = await _context.ProfissionaisSaude.FindAsync(id);
            if (profissionalSaude != null)
            {
                _context.ProfissionaisSaude.Remove(profissionalSaude);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionalSaudeExists(Guid id)
        {
            return _context.ProfissionaisSaude.Any(e => e.Id == id);
        }
    }
}