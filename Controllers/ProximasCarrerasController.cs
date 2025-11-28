using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using R4G.App.Models;
using R4G.App.Services.Interfaces;
using R4G.App.ViewModels;

namespace R4G.App.Controllers
{
    public class ProximasCarrerasController : Controller
    {
        private readonly IProximasCarrerasService _service;
        private readonly ICarrerasService _carrerasService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProximasCarrerasController(
            IProximasCarrerasService service,
            ICarrerasService carrerasService,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _carrerasService = carrerasService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new ProximasCarrerasViewModel
            {
                CarrerasAragon = await _service.GetAragonAsync(),
                CarrerasEspana = await _service.GetEspanaAsync()
            };

            if (User.Identity?.IsAuthenticated ?? false)
            {
                var userId = _userManager.GetUserId(User)!;
                var carrerasUsuario = await _carrerasService.GetAllAsync(userId);
                var apuntadas = carrerasUsuario
                    .Select(c => $"{c.Nombre}|{c.Fecha:yyyy-MM-dd}")
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                ViewBag.CarrerasApuntadas = apuntadas;
            }

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearDesdeProxima(CrearCarreraDesdeProximaInput input)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            var carrera = new Carrera
            {
                Nombre = input.Nombre,
                Fecha = input.Fecha,
                Ciudad = input.Ciudad,
                DistanciaKm = input.DistanciaKm,
                Comentarios = "Borrador creado desde Próximas Carreras",
                UsuarioId = _userManager.GetUserId(User)!,
                TiempoHoras = 0,
                TiempoMinutos = 0,
                TiempoSegundos = 0
            };

            await _carrerasService.CreateAsync(carrera, carrera.UsuarioId);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desapuntarme(string nombre, DateTime fecha)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return RedirectToAction(nameof(Index));

            var userId = _userManager.GetUserId(User)!;
            await _carrerasService.DeleteByNameAndDateAsync(userId, nombre, fecha);

            return RedirectToAction(nameof(Index));
        }
    }
}
