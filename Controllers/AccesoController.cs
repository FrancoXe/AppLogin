using Microsoft.AspNetCore.Mvc;

using AppLogin.Data;
using AppLogin.Models;
using Microsoft.EntityFrameworkCore;
using AppLogin.ViewModels;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AppLogin.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _appDbContext;

        public AccesoController(AppDBContext context)
        {
            _appDbContext = context;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM model)
        {
            if (model.Clave != model.ConfirmarClave)
            {
                ViewData["Error"] = "Las contraseñas no coinciden.";
                return View();
            }

                Usuario usuario = new Usuario
                {
                    NombreCompleto = model.NombreCompleto,
                    Correo = model.Correo,
                    Clave = model.Clave,
                    IdRol = 1 // Rol predeterminado 
                };

            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();


            if(usuario.IdUsuario != 0)
            {
                return RedirectToAction("Login","Acceso");
            }

            ViewData["Error"] = "Error al registrar el usuario.";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            Usuario? usuario_encontrado = await _appDbContext.Usuarios
                .Include(u => u.Rol)
                .Where(u => u.Correo == model.Correo && u.Clave == model.Clave).FirstOrDefaultAsync();
            if (usuario_encontrado == null)
            {
                ViewData["Error"] = "No se encontraron coincidencias";
                return View(model);
            }


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreCompleto),
                new Claim(ClaimTypes.Role, usuario_encontrado.Rol.NombreRol)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");

        }

    }
}
