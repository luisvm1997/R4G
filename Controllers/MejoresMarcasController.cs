using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R4G.App.Services.Interfaces;
using System.Security.Claims;
using R4G.App.ViewModels;

namespace R4G.App.Controllers
{
    [Authorize]
    public class MejoresMarcasController : Controller
    {
        private readonly IEntrenamientosService _entrenamientosService;
        private readonly ICarrerasService _carrerasService;
        private readonly IEstadisticasService _stats;

        public MejoresMarcasController(
            IEntrenamientosService entrenamientosService,
            ICarrerasService carrerasService,
            IEstadisticasService stats)
        {
            _entrenamientosService = entrenamientosService;
            _carrerasService = carrerasService;
            _stats = stats;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var entrenos = await _entrenamientosService.GetUserEntrenos(userId);
            var carreras = await _carrerasService.GetAllAsync(userId);

            var tiempos = carreras.Select(c => (c.DistanciaKm, c.Duracion))
                .Concat(entrenos.Select(e => (e.DistanciaKm, e.Duracion)));

            var vm = new MejorMarcaViewModel
            {
                Mejor1K = MejorTiempo(tiempos, 1),
                Mejor5K = MejorTiempo(tiempos, 5),
                Mejor10K = MejorTiempo(tiempos, 10),
                MejorMedia = MejorTiempo(tiempos, 21.097),
                MejorMaraton = MejorTiempo(tiempos, 42.195)
            };

            return View(vm);
        }

        private static string MejorTiempo(IEnumerable<(double Distancia, TimeSpan Duracion)> items, double objetivoKm)
        {
            // Permite cierto margen para distancias medidas con GPS o pistas no exactas.
            double margen = objetivoKm switch
            {
                1 => 0.15,       // 1K → ±150 m
                5 => 0.50,       // 5K → ±500 m
                10 => 0.70,      // 10K → ±700 m (cubre 9.6 km)
                21.097 => 1.5,   // Media → ±1.5 km
                42.195 => 2.5,   // Maratón → ±2.5 km
                _ => Math.Max(0.05 * objetivoKm, 0.3)
            };

            var exactos = items
                .Where(x => x.Distancia > 0 && x.Duracion > TimeSpan.Zero)
                .Where(x => Math.Abs(x.Distancia - objetivoKm) <= margen)
                .OrderBy(x => x.Duracion)
                .ToList();

            if (!exactos.Any())
                return "-"; // Sin intentos reales para esa distancia.

            return Formatear(exactos.First().Duracion);
        }

        // Formato consistente hh:mm:ss (mantiene 00:MM:SS si no hay horas).
        private static string Formatear(TimeSpan t) => t.ToString(@"hh\:mm\:ss");
    }
}
