using System;
using System.Collections.Generic;
using R4G.App.Models;

namespace R4G.App.ViewModels
{
    public record ProximasCarrerasViewModel
    {
        public IReadOnlyList<ProximaCarrera> CarrerasAragon { get; init; } = Array.Empty<ProximaCarrera>();
        public IReadOnlyList<ProximaCarrera> CarrerasEspana { get; init; } = Array.Empty<ProximaCarrera>();
    }
}
