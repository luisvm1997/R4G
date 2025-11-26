using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;
using R4G.App.Repositories.Interfaces;

namespace R4G.App.Repositories
{
    public class CarrerasRepository : ICarrerasRepository
    {
        private readonly ApplicationDbContext _context;

        public CarrerasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Carrera>> GetAllByUserAsync(string userId)
        {
            return await _context.Carreras
                .Where(c => c.UsuarioId == userId)
                .ToListAsync();
        }

        public async Task<Carrera?> GetByIdAsync(int id, string userId)
        {
            return await _context.Carreras
                .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == userId);
        }

        public Task AddAsync(Carrera carrera)
        {
            _context.Carreras.Add(carrera);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Carrera carrera)
        {
            _context.Carreras.Update(carrera);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Carrera carrera)
        {
            _context.Carreras.Remove(carrera);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
