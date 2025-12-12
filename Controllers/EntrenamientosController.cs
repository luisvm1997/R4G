using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R4G.App.Models;
using R4G.App.Services.Interfaces;
using R4G.App.ViewModels;

namespace R4G.App.Controllers
{
    [Authorize]
    public class EntrenamientosController : Controller
    {
        private readonly IEntrenamientosService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public EntrenamientosController(
            IEntrenamientosService service,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        private string GetUserId() => _userManager.GetUserId(User)!;

        public async Task<IActionResult> Index()
        {
            var entrenos = await _service.GetUserEntrenos(GetUserId());
            var vm = entrenos.Select(ToDto).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var entreno = await _service.GetEntreno(id, GetUserId());
            if (entreno == null) return NotFound();
            return View(ToDto(entreno));
        }

        public IActionResult Create() => View(new EntrenamientoDto
        {
            Fecha = DateTime.Today
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntrenamientoDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.AddEntreno(ToEntity(model), GetUserId());
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entreno = await _service.GetEntreno(id, GetUserId());
            if (entreno == null) return NotFound();
            return View(ToDto(entreno));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntrenamientoDto model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            await _service.UpdateEntreno(ToEntity(model), GetUserId());
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entreno = await _service.GetEntreno(id, GetUserId());
            if (entreno == null) return NotFound();
            return View(ToDto(entreno));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteEntreno(id, GetUserId());
            return RedirectToAction(nameof(Index));
        }

        private static EntrenamientoDto ToDto(Entrenamiento e) => new()
        {
            Id = e.Id,
            Fecha = e.Fecha,
            DistanciaKm = e.DistanciaKm,
            DuracionHoras = e.DuracionHoras,
            DuracionMinutos = e.DuracionMinutos,
            DuracionSegundos = e.DuracionSegundos,
            Tipo = e.Tipo,
            Comentarios = e.Comentarios
        };

        private static Entrenamiento ToEntity(EntrenamientoDto dto) => new()
        {
            Id = dto.Id,
            Fecha = dto.Fecha,
            DistanciaKm = dto.DistanciaKm,
            DuracionHoras = dto.DuracionHoras ?? 0,
            DuracionMinutos = dto.DuracionMinutos ?? 0,
            DuracionSegundos = dto.DuracionSegundos ?? 0,
            Tipo = dto.Tipo,
            Comentarios = dto.Comentarios
        };
    }
}
