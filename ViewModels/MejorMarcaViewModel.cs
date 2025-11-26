using R4G.App.Models;

namespace R4G.App.ViewModels
{
    // ViewModel para mostrar y actualizar las mejores marcas del usuario.
    public record MejorMarcaViewModel
    {
        public string? Mejor1K { get; init; }
        public string? Mejor5K { get; init; }
        public string? Mejor10K { get; init; }
        public string? MejorMedia { get; init; }
        public string? MejorMaraton { get; init; }
    }
}
