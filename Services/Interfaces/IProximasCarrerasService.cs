using R4G.App.Models;

namespace R4G.App.Services.Interfaces
{
    public interface IProximasCarrerasService
    {
        Task<List<ProximaCarrera>> GetAragonAsync();
        Task<List<ProximaCarrera>> GetEspanaAsync();
    }
}