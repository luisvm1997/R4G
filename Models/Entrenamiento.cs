using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.Models
{
    public class Entrenamiento
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        [Range(0.1, 1000)]
        public double DistanciaKm { get; set; }

        [Range(0, 48)]
        public int DuracionHoras { get; set; }

        [Range(0, 59)]
        public int DuracionMinutos { get; set; }

        [Range(0, 59)]
        public int DuracionSegundos { get; set; }

        [Required]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

        public string? Comentarios { get; set; }

        // ⭐ Duración total
        public TimeSpan Duracion =>
            new TimeSpan(DuracionHoras, DuracionMinutos, DuracionSegundos);

        // ⭐ Minutos totales
        public double MinutosTotales =>
            Duracion.TotalMinutes;

        // ⭐ Ritmo medio
        public string RitmoMedio
        {
            get
            {
                if (DistanciaKm <= 0 || MinutosTotales <= 0)
                    return "-";

                double minPorKm = MinutosTotales / DistanciaKm;
                int min = (int)minPorKm;
                int seg = (int)((minPorKm - min) * 60);

                return $"{min}:{seg:D2} /km";
            }
        }

        // ⭐ Velocidad media
        public double VelocidadMedia
        {
            get
            {
                if (MinutosTotales <= 0) return 0;
                return DistanciaKm / (MinutosTotales / 60.0);
            }
        }
    }
}