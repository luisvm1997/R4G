using System;
using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.ViewModels
{
    public record HomeViewModel
    {
        public IReadOnlyList<ProximaCarrera> CarrerasAragon { get; init; } = Array.Empty<ProximaCarrera>();
        public IReadOnlyList<ProximaCarrera> CarrerasEspana { get; init; } = Array.Empty<ProximaCarrera>();

        public double DistanciaTotal { get; init; }
        public TimeSpan TiempoTotal { get; init; }
        public string RitmoMedioGlobal { get; init; } = "-";
        public double VelocidadMediaGlobal { get; init; }

        public Entrenamiento? UltimoEntrenamiento { get; init; }

        public string Mejor1K { get; init; } = "-";
        public string Mejor5K { get; init; } = "-";
        public string Mejor10K { get; init; } = "-";
        public string MejorMedia { get; init; } = "-";
        public string MejorMaraton { get; init; } = "-";

        public IReadOnlyDictionary<string, double> KmsPorMes { get; init; } = new Dictionary<string, double>();

        public double KmsMesActual { get; init; }
        public double KmsSemanaActual { get; init; }
    }
}
