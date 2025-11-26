using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;
using R4G.App.Repositories.Interfaces;

namespace R4G.App.Repositories
{
    public class EntrenamientosRepository : IEntrenamientosRepository
    {
        private readonly ApplicationDbContext _context;

        public EntrenamientosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entrenamiento>> GetByUserAsync(string userId)
        {
            return await _context.Entrenamientos
                .Where(e => e.UsuarioId == userId)
                .OrderByDescending(e => e.Fecha)
                .ToListAsync();
        }

        public async Task<Entrenamiento?> GetByIdAsync(int id, string userId)
        {
            return await _context.Entrenamientos
                .FirstOrDefaultAsync(e => e.Id == id && e.UsuarioId == userId);
        }

        public async Task AddAsync(Entrenamiento entrenamiento)
        {
            await _context.Entrenamientos.AddAsync(entrenamiento);
        }

        public Task UpdateAsync(Entrenamiento entrenamiento)
        {
            _context.Entrenamientos.Update(entrenamiento);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Entrenamiento entrenamiento)
        {
            _context.Entrenamientos.Remove(entrenamiento);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
