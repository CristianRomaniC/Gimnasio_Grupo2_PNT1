using Microsoft.AspNetCore.Mvc;
using GimnasioGrupo2.Data;
using GimnasioGrupo2.Models;
using Microsoft.EntityFrameworkCore;

namespace GimnasioGrupo2.Controllers
{
 public class ObjetosPerdidosController : Controller
 {
 private readonly GimnasioContext _context;
 private readonly ILogger<ObjetosPerdidosController> _logger;

 public ObjetosPerdidosController(GimnasioContext context, ILogger<ObjetosPerdidosController> logger)
 {
 _context = context;
 _logger = logger;
 }

 // GET: ObjetosPerdidos
 public async Task<IActionResult> Index()
 {
 var objetos = await _context.ObjetosPerdidos.Include(o => o.Cliente).OrderByDescending(o => o.FechaEncontrado).ToListAsync();
 return View(objetos);
 }

 // GET: ObjetosPerdidos/Create
 public async Task<IActionResult> Create()
 {
 var vm = new ObjetosPerdidosViewModel();
 await vm.LoadClientesAsync(_context);
 return View(vm);
 }

 // POST: ObjetosPerdidos/Create
 [HttpPost]
 [ValidateAntiForgeryToken]
 public async Task<IActionResult> Create(ObjetosPerdidosViewModel vm)
 {
 if (!ModelState.IsValid)
 {
 await vm.LoadClientesAsync(_context);
 return View(vm);
 }

 if (vm.Objeto.FechaEncontrado == default)
 vm.Objeto.FechaEncontrado = DateTime.Today;

 _context.ObjetosPerdidos.Add(vm.Objeto);
 await _context.SaveChangesAsync();
 TempData["StatusMessage"] = "Objeto guardado correctamente.";
 return RedirectToAction(nameof(Index));
 }

 // POST: ObjetosPerdidos/MarcarEntregado/5
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
 return RedirectToAction(nameof(Index));
 }
 }
}