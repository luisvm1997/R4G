using R4G.App.Models;

namespace R4G.App.Repositories.Interfaces
{
    public interface IMejoresMarcasRepository
    {
        Task<MarcaPersonal?> GetByUserAsync(string userId);
        Task SaveAsync(MarcaPersonal marca);
    }
}
