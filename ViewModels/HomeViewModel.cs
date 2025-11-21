using System;
using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.ViewModels
{
    public class HomeViewModel
    {
        public List<ProximaCarrera> CarrerasAragon { get; set; } = new();
        public List<ProximaCarrera> CarrerasEspana { get; set; } = new();

        public double DistanciaTotal { get; set; }
        public TimeSpan TiempoTotal { get; set; }
        public string RitmoMedioGlobal { get; set; } = "-";
        public double VelocidadMediaGlobal { get; set; }

        public Entrenamiento? UltimoEntrenamiento { get; set; }

        public string Mejor1K { get; set; } = "-";
        public string Mejor5K { get; set; } = "-";
        public string Mejor10K { get; set; } = "-";
        public string MejorMedia { get; set; } = "-";
        public string MejorMaraton { get; set; } = "-";

        public Dictionary<string, double> KmsPorMes { get; set; } = new();

        public double KmsMesActual { get; set; }
        public double KmsSemanaActual { get; set; }
    }
}