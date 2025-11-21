using System.Collections.Generic;

namespace R4G.App.Models
{
    public class ProximasCarrerasViewModel
    {
        public List<ProximaCarrera> CarrerasAragon { get; set; } = new();
        public List<ProximaCarrera> CarrerasEspana { get; set; } = new();
    }
}