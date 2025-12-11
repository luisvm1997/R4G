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
            // Only update races owned by the current user.
            var existing = await _repo.GetByIdAsync(carrera.Id, userId);
            if (existing == null) return false;

            existing.Nombre = carrera.Nombre;
            existing.Fecha = carrera.Fecha;
            existing.DistanciaKm = carrera.DistanciaKm;
            existing.TiempoHoras = carrera.TiempoHoras;
            existing.TiempoMinutos = carrera.TiempoMinutos;
            existing.TiempoSegundos = carrera.TiempoSegundos;
            existing.Ciudad = carrera.Ciudad;
            existing.PosicionGeneral = carrera.PosicionGeneral;
            existing.PosicionCategoria = carrera.PosicionCategoria;
            existing.Comentarios = carrera.Comentarios;

            await _repo.UpdateAsync(existing);
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

        public async Task<bool> DeleteByNameAndDateAsync(string userId, string nombre, DateTime fecha)
        {
            var carrera = await _repo.GetByNameAndDateAsync(userId, nombre, fecha);
            if (carrera == null) return false;

            await _repo.DeleteAsync(carrera);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
