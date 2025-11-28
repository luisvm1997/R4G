using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R4G.App.Models;
using R4G.App.Services.Interfaces;
using R4G.App.ViewModels;

namespace R4G.App.Controllers
{
    [Authorize]
    public class CarrerasController : Controller
    {
        private readonly ICarrerasService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarrerasController(
            ICarrerasService service,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        private string GetUserId() => _userManager.GetUserId(User)!;

        public async Task<IActionResult> Index()
        {
            var carreras = await _service.GetAllAsync(GetUserId());
            var vm = carreras.Select(ToDto).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var carrera = await _service.GetByIdAsync(id, GetUserId());
            if (carrera == null) return NotFound();

            return View(ToDto(carrera));
        }

        public IActionResult Create() => View(new CarreraDto
        {
            Fecha = DateTime.Today
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarreraDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var ok = await _service.CreateAsync(ToEntity(model), GetUserId());
            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "No se pudo crear la carrera. Inténtalo de nuevo.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var carrera = await _service.GetByIdAsync(id, GetUserId());
            if (carrera == null) return NotFound();

            return View(ToDto(carrera));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarreraDto model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var ok = await _service.UpdateAsync(ToEntity(model), GetUserId());
            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "No se pudo actualizar la carrera. Inténtalo de nuevo.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var carrera = await _service.GetByIdAsync(id, GetUserId());
            if (carrera == null) return NotFound();

            return View(ToDto(carrera));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id, GetUserId());
            return RedirectToAction(nameof(Index));
        }

        private static CarreraDto ToDto(Carrera c) => new()
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Fecha = c.Fecha,
            DistanciaKm = c.DistanciaKm,
            TiempoHoras = c.TiempoHoras,
            TiempoMinutos = c.TiempoMinutos,
            TiempoSegundos = c.TiempoSegundos,
            Ciudad = c.Ciudad,
            PosicionGeneral = c.PosicionGeneral,
            PosicionCategoria = c.PosicionCategoria,
            Comentarios = c.Comentarios
        };

        private static Carrera ToEntity(CarreraDto dto) => new()
        {
            Id = dto.Id,
            Nombre = dto.Nombre,
            Fecha = dto.Fecha,
            DistanciaKm = dto.DistanciaKm,
            TiempoHoras = dto.TiempoHoras,
            TiempoMinutos = dto.TiempoMinutos,
            TiempoSegundos = dto.TiempoSegundos,
            Ciudad = dto.Ciudad,
            PosicionGeneral = dto.PosicionGeneral,
            PosicionCategoria = dto.PosicionCategoria,
            Comentarios = dto.Comentarios
        };
    }
}
