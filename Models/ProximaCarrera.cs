using System;

namespace R4G.App.Models
{
    public class ProximaCarrera
    {
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public string Comunidad { get; set; } = string.Empty;
        public string Lugar { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public string Enlace { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double DistanciaKm { get; set; }
    }
}