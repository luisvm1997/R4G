using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4G.App.Data;
using R4G.App.Models;

namespace R4G.App.Controllers
{
    public class MejoresMarcasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MejoresMarcasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MejoresMarcas
        public IActionResult Index()
        {
            var marca = _context.MarcasPersonales.FirstOrDefault();

            if (marca == null)
            {
                marca = new MarcaPersonal();
                _context.MarcasPersonales.Add(marca);
                _context.SaveChanges();
            }

            return View(marca);
        }

        // POST: Guardar mejores marcas (actualiza solo si mejora)
        [HttpPost]
        public IActionResult Guardar(MarcaPersonal model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var marca = _context.MarcasPersonales.FirstOrDefault();

            if (marca == null)
            {
                marca = new MarcaPersonal
                {
                    Mejor5K = model.Mejor5K,
                    Mejor10K = model.Mejor10K,
                    MejorMedia = model.MejorMedia,
                    MejorMaraton = model.MejorMaraton
                };

                _context.MarcasPersonales.Add(marca);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Actualizar solo si mejora
            if (EsMejor(model.Mejor5K, marca.Mejor5K))
                marca.Mejor5K = model.Mejor5K;

            if (EsMejor(model.Mejor10K, marca.Mejor10K))
                marca.Mejor10K = model.Mejor10K;

            if (EsMejor(model.MejorMedia, marca.MejorMedia))
                marca.MejorMedia = model.MejorMedia;

            if (EsMejor(model.MejorMaraton, marca.MejorMaraton))
                marca.MejorMaraton = model.MejorMaraton;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // MÉTODO PRIVADO PARA COMPARAR TIEMPOS
        private bool EsMejor(string? nuevo, string? actual)
        {
            if (string.IsNullOrWhiteSpace(nuevo))
                return false;

            if (string.IsNullOrWhiteSpace(actual))
                return true;

            if (!TimeSpan.TryParse(nuevo, out var tsNuevo))
                return false;

            if (!TimeSpan.TryParse(actual, out var tsActual))
                return true;

            return tsNuevo < tsActual;
        }
    }
}