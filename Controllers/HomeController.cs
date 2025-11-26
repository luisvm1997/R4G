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
            // ⭐ SI NO ESTÁ LOGUEADO → ENSEÑA LA LANDING "WELCOME"
            if (!(User?.Identity?.IsAuthenticated ?? false))
                return View("Welcome");

            // ⭐ SI ESTÁ LOGUEADO → CARGA EL HOME REAL
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
