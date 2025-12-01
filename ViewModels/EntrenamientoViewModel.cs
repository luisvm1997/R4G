using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.ViewModels
{
    // Para pantallas que muestran un entrenamiento concreto y el historial del usuario.
    public record EntrenamientoViewModel
    {
        public Entrenamiento Entrenamiento { get; init; } = new();
        public IReadOnlyList<Entrenamiento> Historial { get; init; } = new List<Entrenamiento>();
    }
}
