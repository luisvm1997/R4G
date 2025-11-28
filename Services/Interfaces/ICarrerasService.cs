using R4G.App.Models;

namespace R4G.App.Services.Interfaces
{
    public interface ICarrerasService
    {
        Task<List<Carrera>> GetAllAsync(string userId);
        Task<Carrera?> GetByIdAsync(int id, string userId);
        Task<bool> CreateAsync(Carrera carrera, string userId);
        Task<bool> UpdateAsync(Carrera carrera, string userId);
        Task<bool> DeleteAsync(int id, string userId);
        Task<bool> DeleteByNameAndDateAsync(string userId, string nombre, DateTime fecha);
    }
}
