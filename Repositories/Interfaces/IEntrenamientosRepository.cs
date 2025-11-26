using R4G.App.Models;

namespace R4G.App.Repositories.Interfaces
{
    public interface IEntrenamientosRepository
    {
        Task<List<Entrenamiento>> GetByUserAsync(string userId);
        Task<Entrenamiento?> GetByIdAsync(int id, string userId);
        Task AddAsync(Entrenamiento entrenamiento);
        Task UpdateAsync(Entrenamiento entrenamiento);
        Task DeleteAsync(Entrenamiento entrenamiento);
        Task SaveAsync();
    }
}
