using System.ComponentModel.DataAnnotations;

namespace R4G.App.Models
{
    public class MarcaPersonal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UsuarioId { get; set; } = string.Empty;

        public string? Mejor1K { get; set; }
        public string? Mejor5K { get; set; }
        public string? Mejor10K { get; set; }
        public string? MejorMedia { get; set; }
        public string? MejorMaraton { get; set; }
    }
}
