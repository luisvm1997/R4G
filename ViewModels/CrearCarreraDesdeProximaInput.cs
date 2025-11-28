using System;
using System.ComponentModel.DataAnnotations;

namespace R4G.App.ViewModels;

public class CrearCarreraDesdeProximaInput
{
    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public DateTime Fecha { get; set; }

    [Required]
    public string Ciudad { get; set; } = string.Empty;

    public string? Comunidad { get; set; }

    [Range(0.1, 1000)]
    public double DistanciaKm { get; set; }
}
