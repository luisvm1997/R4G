using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.ViewModels
{
    // DTO para desacoplar las vistas de la entidad de EF.
    public record CarreraDto
    {
        public int Id { get; init; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; init; } = string.Empty;

        [Required]
        public DateTime Fecha { get; init; }

        [Range(0.1, 1000)]
        public double DistanciaKm { get; init; }

        [Range(0, 48)]
        public int TiempoHoras { get; init; }

        [Range(0, 59)]
        public int TiempoMinutos { get; init; }

        [Range(0, 59)]
        public int TiempoSegundos { get; init; }

        public string? Ciudad { get; init; }

        public int? PosicionGeneral { get; init; }
        public int? PosicionCategoria { get; init; }

        public string? Comentarios { get; init; }

        public string DuracionFormateada =>
            $"{TiempoHoras:D2}:{TiempoMinutos:D2}:{TiempoSegundos:D2}";

        public string RitmoMedio
        {
            get
            {
                var minutosTotales = TiempoHoras * 60 + TiempoMinutos + TiempoSegundos / 60.0;
                if (DistanciaKm <= 0 || minutosTotales <= 0) return "-";

                double mpk = minutosTotales / DistanciaKm;
                int min = (int)mpk;
                int sec = (int)((mpk - min) * 60);

                return $"{min}:{sec:D2} /km";
            }
        }

        public double VelocidadMedia
        {
            get
            {
                var minutosTotales = TiempoHoras * 60 + TiempoMinutos + TiempoSegundos / 60.0;
                if (minutosTotales <= 0) return 0;
                return DistanciaKm / (minutosTotales / 60.0);
            }
        }
    }
}
