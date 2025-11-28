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
        private bool IsGalleryAdmin() =>
            User.Identity?.IsAuthenticated == true &&
            string.Equals(User.Identity.Name, "luisvm1997@gmail.com", StringComparison.OrdinalIgnoreCase);

        [HttpGet]
        public IActionResult Index()
        {
            var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            ViewBag.CanManage = IsGalleryAdmin();
            var files = Directory.GetFiles(uploadPath)
                .Select(Path.GetFileName)
                .Where(f => f != null)
                .OrderByDescending(f => f)
                .ToList();

            return View(files);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subir(IFormFile archivo)
        {
            if (!IsGalleryAdmin()) return Forbid();

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

            var safeName = $"{Guid.NewGuid():N}{ext}";
            var filePath = Path.Combine(uploadsDir, safeName);

            using (var stream = System.IO.File.Create(filePath))
            {
                archivo.CopyTo(stream);
            }

            TempData["GaleriaMsg"] = "Imagen subida.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(string archivo)
        {
            if (!IsGalleryAdmin()) return Forbid();

            if (string.IsNullOrWhiteSpace(archivo))
            {
                TempData["GaleriaMsg"] = "Archivo no válido.";
                return RedirectToAction(nameof(Index));
            }

            var fileName = Path.GetFileName(archivo);

            var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsDir, fileName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                TempData["GaleriaMsg"] = "Archivo eliminado.";
            }
            else
            {
                TempData["GaleriaMsg"] = "El archivo no existe.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
