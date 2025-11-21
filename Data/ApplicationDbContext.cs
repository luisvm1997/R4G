using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using R4G.App.Models;

namespace R4G.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entrenamiento> Entrenamientos { get; set; } = default!;
        public DbSet<Carrera> Carreras { get; set; } = default!;
        public DbSet<MarcaPersonal> MarcasPersonales { get; set; } = default!;
    }
}