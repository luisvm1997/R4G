using System;
using System.Collections.Generic;
using System.Linq;
using R4G.App.Models;
using R4G.App.Services.Interfaces;

namespace R4G.App.Services
{
    public class EstadisticasService : IEstadisticasService
    {
        public double DistanciaTotal(List<Entrenamiento> entrenos)
            => entrenos.Sum(e => e.DistanciaKm);

        public TimeSpan TiempoTotal(List<Entrenamiento> entrenos)
            => TimeSpan.FromMinutes(entrenos.Sum(e => e.MinutosTotales));

        public string RitmoMedioGlobal(List<Entrenamiento> entrenos)
        {
            double dist = entrenos.Sum(e => e.DistanciaKm);
            double minutosTotales = entrenos.Sum(e => e.MinutosTotales);

            if (dist == 0 || minutosTotales == 0)
                return "-";

            double minPorKm = minutosTotales / dist;
            int min = (int)minPorKm;
            int sec = (int)((minPorKm - min) * 60);

            return $"{min}:{sec:D2} /km";
        }

        public double VelocidadMediaGlobal(List<Entrenamiento> entrenos)
        {
            double minutosTotales = entrenos.Sum(e => e.MinutosTotales);
            if (minutosTotales == 0) return 0;

            return entrenos.Sum(e => e.DistanciaKm) / (minutosTotales / 60.0);
        }

        public Entrenamiento? UltimoEntrenamiento(List<Entrenamiento> entrenos)
            => entrenos.OrderByDescending(e => e.Fecha).FirstOrDefault();

        public string MejorMarca(List<Entrenamiento> entrenos, double distanciaObjetivo)
        {
            double margen = distanciaObjetivo switch
            {
                1 => 0.10,
                5 => 0.25,
                10 => 0.30,
                21.097 => 0.40,
                42.195 => 0.70,
                _ => 0.30
            };

            var candidatos = entrenos
                .Where(e => Math.Abs(e.DistanciaKm - distanciaObjetivo) <= margen)
                .OrderBy(e => e.MinutosTotales)
                .ToList();

            if (!candidatos.Any())
                return "-";

            var mejor = candidatos.First();

            return FormatearDuracion(mejor.Duracion);
        }

        public Dictionary<string, double> KmsPorMes(List<Entrenamiento> entrenos)
        {
            return entrenos
                .GroupBy(e => new { e.Fecha.Year, e.Fecha.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .ToDictionary(
                    g => $"{g.Key.Month:D2}/{g.Key.Year}",
                    g => g.Sum(e => e.DistanciaKm)
                );
        }

        public double KmsDelMesActual(List<Entrenamiento> entrenos)
        {
            var hoy = DateTime.Now;
            return entrenos
                .Where(e => e.Fecha.Year == hoy.Year && e.Fecha.Month == hoy.Month)
                .Sum(e => e.DistanciaKm);
        }

        public double KmsDeLaSemanaActual(List<Entrenamiento> entrenos)
        {
            var hoy = DateTime.Now;
            var inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek + (int)DayOfWeek.Monday);
            var finSemana = inicioSemana.AddDays(7);

            return entrenos
                .Where(e => e.Fecha >= inicioSemana && e.Fecha < finSemana)
                .Sum(e => e.DistanciaKm);
        }

        private static string FormatearDuracion(TimeSpan duracion)
        {
            // Con horas: h:mm:ss; sin horas: mm:ss.
            if (duracion.TotalHours >= 1)
                return duracion.ToString(@"h\:mm\:ss");

            return duracion.ToString(@"m\:ss");
        }
    }
}
