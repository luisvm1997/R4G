using R4G.App.Models;

namespace R4G.App.Repositories.Interfaces
{
    public interface IProximasCarrerasRepository
    {
        Task<List<ProximaCarrera>> GetAragonAsync();
        Task<List<ProximaCarrera>> GetEspanaAsync();
    }
}
