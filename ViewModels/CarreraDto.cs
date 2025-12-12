using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.ViewModels
{
    // DTO para no exponer la entidad de EF en las vistas.
    public record CarreraDto
    {
        public int Id { get; init; }

        [Display(Name = "Nombre de la carrera")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo {0} no puede superar los {1} caracteres.")]
        public string Nombre { get; init; } = string.Empty;

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; init; }

        [Display(Name = "Distancia (km)")]
        [Range(0.1, 1000, ErrorMessage = "La distancia debe estar entre {1} y {2} km.")]
        public double DistanciaKm { get; init; }

        [Display(Name = "Horas")]
        [Range(0, 48, ErrorMessage = "Las horas deben estar entre {1} y {2}.")]
        public int TiempoHoras { get; init; }

        [Display(Name = "Minutos")]
        [Range(0, 59, ErrorMessage = "Los minutos deben estar entre {1} y {2}.")]
        public int TiempoMinutos { get; init; }

        [Display(Name = "Segundos")]
        [Range(0, 59, ErrorMessage = "Los segundos deben estar entre {1} y {2}.")]
        public int TiempoSegundos { get; init; }

        [Display(Name = "Ciudad")]
        public string? Ciudad { get; init; }

        [Display(Name = "Posición general")]
        public int? PosicionGeneral { get; init; }

        [Display(Name = "Posición categoría")]
        public int? PosicionCategoria { get; init; }

        [Display(Name = "Comentarios")]
        public string? Comentarios { get; init; }

        // Mismo formato que entrenamientos (hh mm ss).
        public string DuracionFormateada =>
            $"{TiempoHoras:D2}h {TiempoMinutos:D2}m {TiempoSegundos:D2}s";

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
