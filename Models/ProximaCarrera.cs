using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.Models
{
    public class ProximaCarrera
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        [Required]
        public string Ciudad { get; set; } = string.Empty;

        [Required]
        public string Comunidad { get; set; } = string.Empty;

        public string Lugar { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public string Enlace { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        [Range(0.1, 1000)]
        public double DistanciaKm { get; set; }
    }
}
