using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;

namespace R4G.App.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarrerasController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private string? GetUserId() => _userManager.GetUserId(User);

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var carreras = await _context.Carreras
                .Where(c => c.UsuarioId == userId)
                .ToListAsync();

            return View(carreras);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();
            var carrera = await _context.Carreras
                .FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);

            if (carrera == null) return NotFound();

            return View(carrera);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Carrera carrera)
        {
            carrera.UsuarioId = GetUserId()!;

            if (ModelState.IsValid)
            {
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();
            var carrera = await _context.Carreras
                .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == userId);

            if (carrera == null) return NotFound();

            return View(carrera);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Carrera carrera)
        {
            if (id != carrera.Id) return NotFound();

            carrera.UsuarioId = GetUserId()!;

            if (ModelState.IsValid)
            {
                _context.Update(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();
            var carrera = await _context.Carreras
                .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == userId);

            if (carrera == null) return NotFound();

            return View(carrera);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetUserId();
            var carrera = await _context.Carreras
                .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == userId);

            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}