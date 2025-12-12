using R4G.App.Models;
using R4G.App.Repositories.Interfaces;
using R4G.App.Services.Interfaces;

namespace R4G.App.Services
{
    public class EntrenamientosService : IEntrenamientosService
    {
        private readonly IEntrenamientosRepository _repo;

        public EntrenamientosService(IEntrenamientosRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Entrenamiento>> GetUserEntrenos(string userId)
            => _repo.GetByUserAsync(userId);

        public Task<Entrenamiento?> GetEntreno(int id, string userId)
            => _repo.GetByIdAsync(id, userId);

        public async Task AddEntreno(Entrenamiento e, string userId)
        {
            e.UsuarioId = userId;
            NormalizarDuracion(e);
            await _repo.AddAsync(e);
            await _repo.SaveAsync();
        }

        public async Task UpdateEntreno(Entrenamiento e, string userId)
        {
            e.UsuarioId = userId;
            NormalizarDuracion(e);
            await _repo.UpdateAsync(e);
            await _repo.SaveAsync();
        }

        public async Task DeleteEntreno(int id, string userId)
        {
            var entreno = await _repo.GetByIdAsync(id, userId);
            if (entreno != null)
            {
                await _repo.DeleteAsync(entreno);
                await _repo.SaveAsync();
            }
        }

        private static void NormalizarDuracion(Entrenamiento e)
        {
            e.DuracionHoras = Math.Clamp(e.DuracionHoras, 0, 48);
            e.DuracionMinutos = Math.Clamp(e.DuracionMinutos, 0, 59);
            e.DuracionSegundos = Math.Clamp(e.DuracionSegundos, 0, 59);
        }
    }
}
