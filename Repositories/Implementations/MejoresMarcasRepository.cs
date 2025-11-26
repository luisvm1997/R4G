using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;
using R4G.App.Repositories.Interfaces;

namespace R4G.App.Repositories
{
    public class MejoresMarcasRepository : IMejoresMarcasRepository
    {
        private readonly ApplicationDbContext _context;

        public MejoresMarcasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MarcaPersonal?> GetByUserAsync(string userId)
        {
            return await _context.MarcasPersonales
                .FirstOrDefaultAsync(m => m.UsuarioId == userId);
        }

        public async Task SaveAsync(MarcaPersonal marca)
        {
            if (marca.Id == 0)
            {
                await _context.MarcasPersonales.AddAsync(marca);
            }
            else
            {
                _context.MarcasPersonales.Update(marca);
            }

            await _context.SaveChangesAsync();
        }
    }
}
