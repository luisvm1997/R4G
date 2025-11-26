using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace R4G.App.Controllers
{
    [Authorize]
    public class GaleriaController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".gif", ".webp", ".mp4", ".mov", ".webm"];

        public GaleriaController(IWebHostEnvironment env)
        {
            _env = env;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        [HttpGet]
        public IActionResult Index()
        {
            var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var files = Directory.GetFiles(uploadPath)
                .Select(Path.GetFileName)
                .OrderByDescending(f => f)
                .ToList();

            return View(files);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subir(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                TempData["GaleriaMsg"] = "Selecciona un archivo.";
                return RedirectToAction(nameof(Index));
            }

            var ext = Path.GetExtension(archivo.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
            {
                TempData["GaleriaMsg"] = "Formato no permitido. Usa jpg, png, gif o webp.";
                return RedirectToAction(nameof(Index));
            }

            var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            var safeName = $"{GetUserId()}_{Guid.NewGuid():N}{ext}";
            var filePath = Path.Combine(uploadsDir, safeName);

            using (var stream = System.IO.File.Create(filePath))
            {
                archivo.CopyTo(stream);
            }

            TempData["GaleriaMsg"] = "Imagen subida.";
            return RedirectToAction(nameof(Index));
        }
    }
}
