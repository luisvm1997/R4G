using R4G.App.Models;

namespace R4G.App.Services.Interfaces
{
    public interface IEntrenamientosService
    {
        Task<List<Entrenamiento>> GetUserEntrenos(string userId);
        Task<Entrenamiento?> GetEntreno(int id, string userId);
        Task AddEntreno(Entrenamiento entrenamiento, string userId);
        Task UpdateEntreno(Entrenamiento entrenamiento, string userId);
        Task DeleteEntreno(int id, string userId);
    }
}