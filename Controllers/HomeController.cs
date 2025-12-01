using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R4G.App.Services.Interfaces;
using System.Security.Claims;

namespace R4G.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService ?? throw new ArgumentNullException(nameof(homeService));
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // Si no hay sesión, muestra la landing "Welcome".
            if (!(User?.Identity?.IsAuthenticated ?? false))
                return View("Welcome");

            // Si está logueado, construye y carga el home real.
            var vm = await _homeService.BuildHomeViewModel(GetUserId());
            return View(vm);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
