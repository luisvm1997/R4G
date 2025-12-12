using R4G.App.Data.Static;
using R4G.App.Models;
using R4G.App.Repositories.Interfaces;

namespace R4G.App.Repositories
{
    // El repositorio envuelve datos estáticos para que los controladores estén desacoplados de la fuente de datos.
    public class ProximasCarrerasRepository : IProximasCarrerasRepository
    {
        public Task<List<ProximaCarrera>> GetAragonAsync()
            => Task.FromResult(ProximasCarrerasData.CarrerasAragon.ToList());

        public Task<List<ProximaCarrera>> GetEspanaAsync()
            => Task.FromResult(ProximasCarrerasData.CarrerasEspana.ToList());
    }
}
