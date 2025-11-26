using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.Models
{
    public class Carrera
    {
        public int Id { get; set; }

        [Required]
        public string UsuarioId { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public DateTime Fecha { get; set; }

        [Range(0.1, 1000)]
        public double DistanciaKm { get; set; }

        [Range(0, 48)]
        public int TiempoHoras { get; set; }

        [Range(0, 59)]
        public int TiempoMinutos { get; set; }

        [Range(0, 59)]
        public int TiempoSegundos { get; set; }

        public string? Ciudad { get; set; }

        public int? PosicionGeneral { get; set; }
        public int? PosicionCategoria { get; set; }

        public string? Comentarios { get; set; }

        // ============================
        // 🟦 DURACIÓN TOTAL como TimeSpan
        // ============================
        public TimeSpan Duracion =>
            new TimeSpan(TiempoHoras, TiempoMinutos, TiempoSegundos);

        // ============================
        // 🟦 Minutos totales (para cálculos)
        // ============================
        public double MinutosTotales => Duracion.TotalMinutes;

        // ============================
        // 🟦 Ritmo medio (min/km)
        // ============================
        public string RitmoMedio
        {
            get
            {
                if (DistanciaKm <= 0 || MinutosTotales <= 0)
                    return "-";

                double mpk = MinutosTotales / DistanciaKm;

                int min = (int)mpk;
                int sec = (int)((mpk - min) * 60);

                return $"{min}:{sec:D2} /km";
            }
        }

        // ============================
        // 🟦 Velocidad media (km/h)
        // ============================
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
