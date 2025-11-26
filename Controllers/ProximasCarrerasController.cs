using Microsoft.AspNetCore.Mvc;
using R4G.App.Services.Interfaces;
using R4G.App.ViewModels;

namespace R4G.App.Controllers
{
    public class ProximasCarrerasController : Controller
    {
        private readonly IProximasCarrerasService _service;

        public ProximasCarrerasController(IProximasCarrerasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new ProximasCarrerasViewModel
            {
                CarrerasAragon = await _service.GetAragonAsync(),
                CarrerasEspana = await _service.GetEspanaAsync()
            };

            return View(vm);
        }
    }
}
