using Microsoft.AspNetCore.Mvc;
using R4G.App.Data;
using R4G.App.Data.Static;
using R4G.App.Services;
using R4G.App.ViewModels;
using System.Linq;

namespace R4G.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EstadisticasService _stats;

        public HomeController(ApplicationDbContext context, EstadisticasService stats)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public IActionResult Index()
        {
            // ⭐ SI NO ESTÁ LOGUEADO → ENSEÑA LA LANDING "WELCOME"
            if (!(User?.Identity?.IsAuthenticated ?? false))
                return View("Welcome");

            // ⭐ SI ESTÁ LOGUEADO → CARGA EL HOME REAL
            var entrenos = _context.Entrenamientos.ToList();

            var vm = new HomeViewModel
            {
                CarrerasAragon = ProximasCarrerasData.CarrerasAragon,
                CarrerasEspana = ProximasCarrerasData.CarrerasEspaña,

                DistanciaTotal = _stats.DistanciaTotal(entrenos),
                TiempoTotal = _stats.TiempoTotal(entrenos),
                RitmoMedioGlobal = _stats.RitmoMedioGlobal(entrenos),
                VelocidadMediaGlobal = _stats.VelocidadMediaGlobal(entrenos),

                UltimoEntrenamiento = _stats.UltimoEntrenamiento(entrenos),

                // ⭐ MEJORES MARCAS COMPLETAS
                Mejor1K = _stats.MejorMarca(entrenos, 1),
                Mejor5K = _stats.MejorMarca(entrenos, 5),
                Mejor10K = _stats.MejorMarca(entrenos, 10),
                MejorMedia = _stats.MejorMarca(entrenos, 21.097),
                MejorMaraton = _stats.MejorMarca(entrenos, 42.195),

                // ⭐ GRÁFICOS
                KmsPorMes = _stats.KmsPorMes(entrenos),
                KmsMesActual = _stats.KmsDelMesActual(entrenos),
                KmsSemanaActual = _stats.KmsDeLaSemanaActual(entrenos)
            };

            return View(vm);
        }
    }
}