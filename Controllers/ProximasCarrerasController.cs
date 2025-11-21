using Microsoft.AspNetCore.Mvc;
using R4G.App.Data.Static;
using R4G.App.Models;

namespace R4G.App.Controllers
{
    public class ProximasCarrerasController : Controller
    {
        public IActionResult Index()
        {
            var vm = new ProximasCarrerasViewModel
            {
                CarrerasAragon = ProximasCarrerasData.CarrerasAragon,
                CarrerasEspana = ProximasCarrerasData.CarrerasEspaña
            };

            return View(vm);
        }
    }
}