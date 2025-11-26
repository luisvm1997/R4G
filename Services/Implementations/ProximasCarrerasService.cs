using R4G.App.Models;
using R4G.App.Repositories.Interfaces;
using R4G.App.Services.Interfaces;

namespace R4G.App.Services
{
    public class ProximasCarrerasService : IProximasCarrerasService
    {
        private readonly IProximasCarrerasRepository _repo;

        public ProximasCarrerasService(IProximasCarrerasRepository repo)
        {
            _repo = repo;
        }

        public Task<List<ProximaCarrera>> GetAragonAsync() => _repo.GetAragonAsync();

        public Task<List<ProximaCarrera>> GetEspanaAsync() => _repo.GetEspanaAsync();
    }
}
