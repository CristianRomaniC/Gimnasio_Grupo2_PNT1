using System.Diagnostics;
using GimnasioGrupo2.Models;
using Microsoft.AspNetCore.Mvc;
using GimnasioGrupo2.Data;
using Microsoft.EntityFrameworkCore;

namespace GimnasioGrupo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GimnasioContext _context;

        public HomeController(ILogger<HomeController> logger, GimnasioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Privacy (ahora contiene formulario y lista de objetos perdidos)
        public async Task<IActionResult> Privacy()
        {
            var model = new ObjetosPerdidosViewModel();

            List<ObjetoPerdido> objetos = new();
            try
            {
                // Cargar clientes y objetos dentro del mismo try para capturar errores de BD
                await model.LoadClientesAsync(_context);

                objetos = await _context.ObjetosPerdidos
                    .Include(o => o.Cliente)
                    .OrderByDescending(o => o.FechaEncontrado)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log and show the exception message to help debugging
                _logger.LogError(ex, "Error cargando ObjetosPerdidos o Clientes");
                ViewBag.ObjetosPerdidosError = ex.ToString();
                objetos = new List<ObjetoPerdido>();

                // asegurarse que la lista de clientes no sea nula en la vista
                if (model.ClientesLista == null)
                    model.ClientesLista = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            }

            ViewBag.ObjetosPerdidos = objetos;
            return View(model);
        }

        // POST: crear objeto perdido desde Privacy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Privacy(ObjetosPerdidosViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await model.LoadClientesAsync(_context);
                try
                {
                    ViewBag.ObjetosPerdidos = await _context.ObjetosPerdidos.Include(o => o.Cliente).OrderByDescending(o => o.FechaEncontrado).ToListAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error cargando ObjetosPerdidos (POST)");
                    ViewBag.ObjetosPerdidosError = ex.ToString();
                    ViewBag.ObjetosPerdidos = new List<ObjetoPerdido>();
                }
                return View(model);
            }

            if (model.Objeto.FechaEncontrado == default)
            {
                model.Objeto.FechaEncontrado = DateTime.Today;
            }

            _context.ObjetosPerdidos.Add(model.Objeto);
            await _context.SaveChangesAsync();

            TempData["StatusMessage"] = "Objeto guardado correctamente.";
            return RedirectToAction(nameof(Privacy));
        }

        // POST: marcar entregado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarEntregado(int id)
        {
            var obj = await _context.ObjetosPerdidos.FindAsync(id);
            if (obj == null) return NotFound();
            obj.Entregado = true;
            obj.FechaEntregado = DateTime.Now;
            _context.Update(obj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Privacy));
        }

        [ResponseCache(Duration =0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
