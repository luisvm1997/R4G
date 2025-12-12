using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.ViewModels
{
    // DTO para no exponer la entidad de EF en las vistas.
    public record EntrenamientoDto
    {
        public int Id { get; init; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; init; }

        [Display(Name = "Distancia (km)")]
        [Range(0.1, 1000, ErrorMessage = "La distancia debe estar entre {1} y {2} km.")]
        public double DistanciaKm { get; init; }

        [Display(Name = "Horas")]
        [Range(0, 48, ErrorMessage = "Las horas deben estar entre {1} y {2}.")]
        public int? DuracionHoras { get; init; }

        [Display(Name = "Minutos")]
        [Range(0, 59, ErrorMessage = "Los minutos deben estar entre {1} y {2}.")]
        public int? DuracionMinutos { get; init; }

        [Display(Name = "Segundos")]
        [Range(0, 59, ErrorMessage = "Los segundos deben estar entre {1} y {2}.")]
        public int? DuracionSegundos { get; init; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres.")]
        public string Tipo { get; init; } = string.Empty;

        [Display(Name = "Comentarios")]
        public string? Comentarios { get; init; }

        // Formato legible con sufijos (hh mm ss).
        public string DuracionFormateada =>
            $"{DuracionHoras.GetValueOrDefault():D2}h {DuracionMinutos.GetValueOrDefault():D2}m {DuracionSegundos.GetValueOrDefault():D2}s";

        public string RitmoMedio
        {
            get
            {
                var minutosTotales = DuracionHoras.GetValueOrDefault() * 60
                                   + DuracionMinutos.GetValueOrDefault()
                                   + DuracionSegundos.GetValueOrDefault() / 60.0;
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
                var minutosTotales = DuracionHoras.GetValueOrDefault() * 60
                                   + DuracionMinutos.GetValueOrDefault()
                                   + DuracionSegundos.GetValueOrDefault() / 60.0;
                if (minutosTotales <= 0) return 0;
                return DistanciaKm / (minutosTotales / 60.0);
            }
        }
    }
}
