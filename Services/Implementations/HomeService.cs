using System.Threading.Tasks;
using R4G.App.Services.Interfaces;
using R4G.App.ViewModels;

namespace R4G.App.Services
{
    public class HomeService : IHomeService
    {
        private readonly IEntrenamientosService _entrenamientosService;
        private readonly IEstadisticasService _stats;
        private readonly IProximasCarrerasService _proximasCarrerasService;

        public HomeService(
            IEntrenamientosService entrenamientosService,
            IEstadisticasService stats,
            IProximasCarrerasService proximasCarrerasService)
        {
            _entrenamientosService = entrenamientosService;
            _stats = stats;
            _proximasCarrerasService = proximasCarrerasService;
        }

        public async Task<HomeViewModel> BuildHomeViewModel(string userId)
        {
            var entrenos = await _entrenamientosService.GetUserEntrenos(userId);

            return new HomeViewModel
            {
                CarrerasAragon = await _proximasCarrerasService.GetAragonAsync(),
                CarrerasEspana = await _proximasCarrerasService.GetEspanaAsync(),

                DistanciaTotal = _stats.DistanciaTotal(entrenos),
                TiempoTotal = _stats.TiempoTotal(entrenos),
                RitmoMedioGlobal = _stats.RitmoMedioGlobal(entrenos),
                VelocidadMediaGlobal = _stats.VelocidadMediaGlobal(entrenos),

                UltimoEntrenamiento = _stats.UltimoEntrenamiento(entrenos),

                Mejor1K = _stats.MejorMarca(entrenos, 1),
                Mejor5K = _stats.MejorMarca(entrenos, 5),
                Mejor10K = _stats.MejorMarca(entrenos, 10),
                MejorMedia = _stats.MejorMarca(entrenos, 21.097),
                MejorMaraton = _stats.MejorMarca(entrenos, 42.195),

                KmsPorMes = _stats.KmsPorMes(entrenos),
                KmsMesActual = _stats.KmsDelMesActual(entrenos),
                KmsSemanaActual = _stats.KmsDeLaSemanaActual(entrenos)
            };
        }
    }
}
