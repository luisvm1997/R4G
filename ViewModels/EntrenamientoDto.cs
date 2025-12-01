using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.ViewModels
{
    // DTO para no exponer la entidad de EF en las vistas.
    public record EntrenamientoDto
    {
        public int Id { get; init; }

        [Required]
        public DateTime Fecha { get; init; }

        [Range(0.1, 1000)]
        public double DistanciaKm { get; init; }

        [Range(0, 48)]
        public int DuracionHoras { get; init; }

        [Range(0, 59)]
        public int DuracionMinutos { get; init; }

        [Range(0, 59)]
        public int DuracionSegundos { get; init; }

        [Required]
        [StringLength(100)]
        public string Tipo { get; init; } = string.Empty;

        public string? Comentarios { get; init; }

        public string DuracionFormateada =>
            $"{DuracionHoras:D2}h {DuracionMinutos:D2}m {DuracionSegundos:D2}s";

        public string RitmoMedio
        {
            get
            {
                var minutosTotales = DuracionHoras * 60 + DuracionMinutos + DuracionSegundos / 60.0;
                if (DistanciaKm <= 0 || minutosTotales <= 0) return "-";

                double minPorKm = minutosTotales / DistanciaKm;
                int min = (int)minPorKm;
                int seg = (int)((minPorKm - min) * 60);

                return $"{min}:{seg:D2} /km";
            }
        }

        public double VelocidadMedia
        {
            get
            {
                var minutosTotales = DuracionHoras * 60 + DuracionMinutos + DuracionSegundos / 60.0;
                if (minutosTotales <= 0) return 0;
                return DistanciaKm / (minutosTotales / 60.0);
            }
        }
    }
}
