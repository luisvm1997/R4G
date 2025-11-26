using R4G.App.Models;
using R4G.App.Repositories.Interfaces;
using R4G.App.Services.Interfaces;

namespace R4G.App.Services
{
    public class CarrerasService : ICarrerasService
    {
        private readonly ICarrerasRepository _repo;

        public CarrerasService(ICarrerasRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Carrera>> GetAllAsync(string userId)
        {
            return await _repo.GetAllByUserAsync(userId);
        }

        public async Task<Carrera?> GetByIdAsync(int id, string userId)
        {
            return await _repo.GetByIdAsync(id, userId);
        }

        public async Task<bool> CreateAsync(Carrera carrera, string userId)
        {
            carrera.UsuarioId = userId;

            await _repo.AddAsync(carrera);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Carrera carrera, string userId)
        {
            if (carrera.UsuarioId != userId)
                return false;

            await _repo.UpdateAsync(carrera);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var carrera = await _repo.GetByIdAsync(id, userId);

            if (carrera == null)
                return false;

            await _repo.DeleteAsync(carrera);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}