using Microsoft.AspNetCore.Mvc;
using AppLogin.Models;
using AppLogin.Data;
using AppLogin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IO;

namespace AppLogin.Controllers
{
    [Authorize]
    public class ReclamosController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ViewsPath = "~/Views/Reclamos/";

        public ReclamosController(AppDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Nuevo()
        {
            var model = new ReclamoVM
            {
                Categorias = await _context.Categorias.ToListAsync(),
                Subcategorias = await _context.Subcategorias.ToListAsync(),
                Barrios = await _context.Barrios.ToListAsync()
            };
            return View($"{ViewsPath}Nuevo.cshtml", model);
        }

        public async Task<IActionResult> MisReclamos()
        {
            var userEmail = User.FindFirst("Correo")?.Value;
            var reclamos = await _context.Reclamos
                .Include(r => r.Usuario)
                .Include(r => r.Categoria)
                .Include(r => r.Subcategoria)
                .Include(r => r.Barrio)
                .Where(r => r.Usuario.Correo == userEmail)
                .OrderByDescending(r => r.FechaCreacion)
                .ToListAsync();

            return View($"{ViewsPath}MisReclamos.cshtml", reclamos);
        }

        public async Task<IActionResult> Pendientes()
        {
            if (!User.IsInRole("Administrador"))
            {
                return RedirectToAction("MisReclamos");
            }

            var reclamos = await _context.Reclamos
                .Include(r => r.Usuario)
                .Include(r => r.Categoria)
                .Include(r => r.Subcategoria)
                .Include(r => r.Barrio)
                .Where(r => r.Estado == "Pendiente")
                .OrderByDescending(r => r.FechaCreacion)
                .ToListAsync();

            return View($"{ViewsPath}Pendientes.cshtml", reclamos);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Usuarios()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol)
                .Select(u => new UsuarioGestionVM
                {
                    IdUsuario = u.IdUsuario,
                    NombreCompleto = u.NombreCompleto,
                    Correo = u.Correo,
                    RolNombre = u.Rol.NombreRol,
                    UltimoAcceso = u.UltimoAcceso
                })
                .OrderBy(u => u.NombreCompleto)
                .ToListAsync();

            return View($"{ViewsPath}Usuarios.cshtml", usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ReclamoVM model)
        {
            if (ModelState.IsValid)
            {
                string? rutaArchivo = null;
                if (model.Archivo != null)
                {
                    // Validar tamaño del archivo (5MB)
                    if (model.Archivo.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Archivo", "El archivo no puede ser mayor a 5MB");
                        return View($"{ViewsPath}Nuevo.cshtml", model);
                    }

                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Archivo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Archivo.CopyToAsync(fileStream);
                    }

                    rutaArchivo = "/uploads/" + uniqueFileName;
                }

                var userEmail = User.FindFirst("Correo")?.Value;
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Correo == userEmail);

                var categoria = await _context.Categorias.FindAsync(model.IdCategoria);
                var subcategoria = await _context.Subcategorias.FindAsync(model.IdSubcategoria);
                var barrio = await _context.Barrios.FindAsync(model.IdBarrio);

                if (categoria == null || subcategoria == null || barrio == null)
                {
                    ModelState.AddModelError("", "Por favor seleccione una categoría, subcategoría y barrio válidos");
                    model.Categorias = await _context.Categorias.ToListAsync();
                    model.Subcategorias = await _context.Subcategorias.ToListAsync();
                    model.Barrios = await _context.Barrios.ToListAsync();
                    return View($"{ViewsPath}Nuevo.cshtml", model);
                }

                var reclamo = new Reclamo
                {
                    DNI = model.DNI,
                    IdCategoria = model.IdCategoria,
                    Categoria = categoria,
                    IdSubcategoria = model.IdSubcategoria,
                    Subcategoria = subcategoria,
                    IdBarrio = model.IdBarrio,
                    Barrio = barrio,
                    Direccion = model.Direccion,
                    Descripcion = model.Descripcion,
                    RutaArchivo = rutaArchivo,
                    FechaCreacion = DateTime.UtcNow,
                    Estado = "Pendiente",
                    IdUsuario = usuario?.IdUsuario ?? 0,
                    Usuario = usuario!
                };

                _context.Reclamos.Add(reclamo);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Reclamo creado exitosamente";
                return RedirectToAction("MisReclamos");
            }

            model.Categorias = await _context.Categorias.ToListAsync();
            model.Subcategorias = await _context.Subcategorias.ToListAsync();
            model.Barrios = await _context.Barrios.ToListAsync();
            return View($"{ViewsPath}Nuevo.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategorias(int idCategoria)
        {
            var subcategorias = await _context.Subcategorias
                .Where(s => s.IdCategoria == idCategoria)
                .Select(s => new { id = s.IdSubcategoria, nombre = s.Nombre })
                .ToListAsync();
            return Json(subcategorias);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ObtenerDetalles(int id)
        {
            var reclamo = await _context.Reclamos
                .Include(r => r.Usuario)
                .Include(r => r.Categoria)
                .Include(r => r.Subcategoria)
                .Include(r => r.Barrio)
                .FirstOrDefaultAsync(r => r.IdReclamo == id);

            if (reclamo == null)
            {
                return NotFound();
            }

            var detalles = new
            {
                reclamo.IdReclamo,
                usuario = new
                {
                    reclamo.Usuario.NombreCompleto,
                    reclamo.Usuario.Correo
                },
                reclamo.DNI,
                categoria = reclamo.Categoria.Nombre,
                subcategoria = reclamo.Subcategoria.Nombre,
                barrio = reclamo.Barrio.Nombre,
                reclamo.Direccion,
                reclamo.Descripcion,
                reclamo.RutaArchivo,
                fechaCreacion = reclamo.FechaCreacion.ToString("dd/MM/yyyy HH:mm"),
                fechaActualizacion = reclamo.FechaActualizacion?.ToString("dd/MM/yyyy HH:mm"),
                reclamo.Estado
            };

            return Json(detalles);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GestionarReclamo([FromBody] GestionReclamoVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reclamo = await _context.Reclamos
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.IdReclamo == model.IdReclamo);

            if (reclamo == null)
            {
                return NotFound();
            }

            reclamo.Estado = model.Estado;
            reclamo.FechaActualizacion = DateTime.UtcNow;

            // Crear notificación para el usuario
            var notificacion = new Notificacion
            {
                IdUsuario = reclamo.IdUsuario,
                Titulo = $"Reclamo {model.Estado.ToLower()}",
                Mensaje = $"Tu reclamo ha sido {model.Estado.ToLower()}.",
                FechaCreacion = DateTime.UtcNow,
                Leida = false
            };

            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
