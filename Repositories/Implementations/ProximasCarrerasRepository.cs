using R4G.App.Data.Static;
using R4G.App.Models;
using R4G.App.Repositories.Interfaces;

namespace R4G.App.Repositories
{
    // Repository wraps static data so controllers stay decoupled from data source.
    public class ProximasCarrerasRepository : IProximasCarrerasRepository
    {
        public Task<List<ProximaCarrera>> GetAragonAsync()
            => Task.FromResult(ProximasCarrerasData.CarrerasAragon.ToList());

        public Task<List<ProximaCarrera>> GetEspanaAsync()
            => Task.FromResult(ProximasCarrerasData.CarrerasEspana.ToList());
    }
}
