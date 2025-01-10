using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppLogin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using AppLogin.ViewModels;
using Microsoft.EntityFrameworkCore;
using AppLogin.Data;

namespace AppLogin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _context;

        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IActionResult> Index()
        {
            var userEmail = User.FindFirst("Correo")?.Value;
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == userEmail);

            if (usuario == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            var viewModel = new DashboardVM
            {
                TotalReclamos = await _context.Reclamos.CountAsync(r => r.IdUsuario == usuario.IdUsuario),
                ReclamosPendientes = await _context.Reclamos.CountAsync(r => r.IdUsuario == usuario.IdUsuario && r.Estado == "Pendiente"),
                ReclamosAceptados = await _context.Reclamos.CountAsync(r => r.IdUsuario == usuario.IdUsuario && r.Estado == "Aceptado"),
                ReclamosRechazados = await _context.Reclamos.CountAsync(r => r.IdUsuario == usuario.IdUsuario && r.Estado == "Rechazado"),
                UltimosReclamos = await _context.Reclamos
                    .Where(r => r.IdUsuario == usuario.IdUsuario)
                    .OrderByDescending(r => r.FechaCreacion)
                    .Take(5)
                    .Include(r => r.Categoria)
                    .Include(r => r.Subcategoria)
                    .ToListAsync(),
                    
            };

            // Si es administrador, cargar datos adicionales
            if (usuario.IdRol == 1) // Asumiendo que 1 es el ID del rol Administrador
            {
                viewModel.TotalReclamosGlobal = await _context.Reclamos.CountAsync();
                viewModel.ReclamosPendientesGlobal = await _context.Reclamos.CountAsync(r => r.Estado == "Pendiente");
                viewModel.ReclamosAceptadosGlobal = await _context.Reclamos.CountAsync(r => r.Estado == "Aceptado");
                viewModel.ReclamosRechazadosGlobal = await _context.Reclamos.CountAsync(r => r.Estado == "Rechazado");
                viewModel.TotalUsuarios = await _context.Usuarios.CountAsync();
                viewModel.UltimosReclamosGlobal = await _context.Reclamos
                    .OrderByDescending(r => r.FechaCreacion)
                    .Take(10)
                    .Include(r => r.Usuario)
                    .Include(r => r.Categoria)
                    .Include(r => r.Subcategoria)
                    .ToListAsync();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerNotificaciones()
        {
            var userEmail = User.FindFirst("Correo")?.Value;
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == userEmail);

            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado" });
            }

            var notificaciones = await _context.Notificaciones
                .Where(n => n.IdUsuario == usuario.IdUsuario && !n.Leida)
                .OrderByDescending(n => n.FechaCreacion)
                .Select(n => new
                {
                    n.IdNotificacion,
                    n.Titulo,
                    n.Mensaje,
                    FechaCreacion = n.FechaCreacion.ToString("dd/MM/yyyy HH:mm")
                })
                .ToListAsync();

            return Json(new { success = true, notificaciones });
        }

        [HttpPost]
        public async Task<IActionResult> MarcarNotificacionLeida(int idNotificacion)
        {
            var userEmail = User.FindFirst("Correo")?.Value;
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == userEmail);

            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado" });
            }

            var notificacion = await _context.Notificaciones
                .FirstOrDefaultAsync(n => n.IdNotificacion == idNotificacion && n.IdUsuario == usuario.IdUsuario);

            if (notificacion == null)
            {
                return Json(new { success = false, message = "Notificación no encontrada" });
            }

            notificacion.Leida = true;
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }
    }
}
