using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.ViewModels
{
    // ViewModel pensado para pantallas que necesiten un entrenamiento concreto
    // junto con el historial completo del usuario.
    public record EntrenamientoViewModel
    {
        public Entrenamiento Entrenamiento { get; init; } = new();
        public IReadOnlyList<Entrenamiento> Historial { get; init; } = new List<Entrenamiento>();
    }
}
