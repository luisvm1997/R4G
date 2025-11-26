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
            double margen = objetivoKm switch
            {
                1 => 0.10,
                5 => 0.25,
                10 => 0.30,
                21.097 => 0.40,
                42.195 => 0.70,
                _ => 0.30
            };

            var mejor = items
                .Where(x => Math.Abs(x.Distancia - objetivoKm) <= margen)
                .OrderBy(x => x.Duracion)
                .FirstOrDefault();

            if (mejor.Duracion == TimeSpan.Zero)
                return "-";

            return mejor.Duracion.ToString(@"hh\:mm\:ss");
        }
    }
}
