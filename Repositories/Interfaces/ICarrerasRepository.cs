using R4G.App.Models;

namespace R4G.App.Repositories.Interfaces
{
    public interface ICarrerasRepository
    {
        Task<List<Carrera>> GetAllByUserAsync(string userId);
        Task<Carrera?> GetByIdAsync(int id, string userId);
        Task AddAsync(Carrera carrera);
        Task UpdateAsync(Carrera carrera);
        Task DeleteAsync(Carrera carrera);
        Task SaveChangesAsync();
    }
}