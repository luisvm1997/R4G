using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;

namespace R4G.App.Controllers
{
    public class EntrenamientosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EntrenamientosController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private string? GetUserId() => _userManager.GetUserId(User);

        // GET: Entrenamientos
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var entrenos = await _context.Entrenamientos
                .Where(e => e.UsuarioId == userId)
                .OrderByDescending(e => e.Fecha)
                .ToListAsync();

            return View(entrenos);
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();
            var entreno = await _context.Entrenamientos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);

            if (entreno == null) return NotFound();

            return View(entreno);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Entrenamiento entrenamiento)
        {
            entrenamiento.UsuarioId = GetUserId()!;

            if (ModelState.IsValid)
            {
                _context.Add(entrenamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrenamiento);
        }

        // EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();
            var entreno = await _context.Entrenamientos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);

            if (entreno == null) return NotFound();

            return View(entreno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Entrenamiento entrenamiento)
        {
            if (id != entrenamiento.Id) return NotFound();

            entrenamiento.UsuarioId = GetUserId()!;

            if (ModelState.IsValid)
            {
                _context.Update(entrenamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrenamiento);
        }

        // DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();
            var entreno = await _context.Entrenamientos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);

            if (entreno == null) return NotFound();

            return View(entreno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetUserId();
            var entreno = await _context.Entrenamientos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);

            if (entreno != null)
            {
                _context.Entrenamientos.Remove(entreno);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}