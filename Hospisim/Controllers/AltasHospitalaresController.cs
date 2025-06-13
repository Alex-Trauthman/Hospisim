using Hospisim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospisim.Data;
using Hospisim.Domain.Entities;

namespace Hospisim.Controllers
{
    public class AltasHospitalaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AltasHospitalaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AltasHospitalares
        public async Task<IActionResult> Index()
        {
            var altasHospitalares = await _context.AltasHospitalares
                .Include(a => a.Internacao)
                    .ThenInclude(i => i.Paciente)
                .ToListAsync();
            return View(altasHospitalares);
        }

        // GET: AltasHospitalares/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altaHospitalar = await _context.AltasHospitalares
                .Include(a => a.Internacao)
                    .ThenInclude(i => i.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (altaHospitalar == null)
            {
                return NotFound();
            }

            return View(altaHospitalar);
        }

        // GET: AltasHospitalares/Create
        public IActionResult Create()
        {
            ViewData["InternacaoId"] = new SelectList(_context.Internacoes
                .Include(i => i.Paciente)
                .Where(i => !_context.AltasHospitalares.Any(a => a.InternacaoId == i.Id))
                .Select(i => new { i.Id, Descricao = $"{i.Paciente.NomeCompleto} - Quarto {i.Quarto}, Leito {i.Leito}" }), 
                "Id", "Descricao");
            return View();
        }

        // POST: AltasHospitalares/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InternacaoId,Data,CondicaoPaciente,InstrucoesPosAlta")] AltaHospitalar altaHospitalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(altaHospitalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InternacaoId"] = new SelectList(_context.Internacoes
                .Include(i => i.Paciente)
                .Where(i => !_context.AltasHospitalares.Any(a => a.InternacaoId == i.Id))
                .Select(i => new { i.Id, Descricao = $"{i.Paciente.NomeCompleto} - Quarto {i.Quarto}, Leito {i.Leito}" }), 
                "Id", "Descricao", altaHospitalar.InternacaoId);
            return View(altaHospitalar);
        }

        // GET: AltasHospitalares/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altaHospitalar = await _context.AltasHospitalares.FindAsync(id);
            if (altaHospitalar == null)
            {
                return NotFound();
            }
            ViewData["InternacaoId"] = new SelectList(_context.Internacoes
                .Include(i => i.Paciente)
                .Where(i => !_context.AltasHospitalares.Any(a => a.InternacaoId == i.Id && a.Id != id))
                .Select(i => new { i.Id, Descricao = $"{i.Paciente.NomeCompleto} - Quarto {i.Quarto}, Leito {i.Leito}" }), 
                "Id", "Descricao", altaHospitalar.InternacaoId);
            return View(altaHospitalar);
        }

        // POST: AltasHospitalares/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,InternacaoId,Data,CondicaoPaciente,InstrucoesPosAlta")] AltaHospitalar altaHospitalar)
        {
            if (id != altaHospitalar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(altaHospitalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AltaHospitalarExists(altaHospitalar.Id))
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
            ViewData["InternacaoId"] = new SelectList(_context.Internacoes
                .Include(i => i.Paciente)
                .Where(i => !_context.AltasHospitalares.Any(a => a.InternacaoId == i.Id && a.Id != id))
                .Select(i => new { i.Id, Descricao = $"{i.Paciente.NomeCompleto} - Quarto {i.Quarto}, Leito {i.Leito}" }), 
                "Id", "Descricao", altaHospitalar.InternacaoId);
            return View(altaHospitalar);
        }

        // GET: AltasHospitalares/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var altaHospitalar = await _context.AltasHospitalares
                .Include(a => a.Internacao)
                    .ThenInclude(i => i.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (altaHospitalar == null)
            {
                return NotFound();
            }

            return View(altaHospitalar);
        }

        // POST: AltasHospitalares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var altaHospitalar = await _context.AltasHospitalares.FindAsync(id);
            if (altaHospitalar != null)
            {
                _context.AltasHospitalares.Remove(altaHospitalar);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AltaHospitalarExists(Guid id)
        {
            return _context.AltasHospitalares.Any(e => e.Id == id);
        }
    }
}