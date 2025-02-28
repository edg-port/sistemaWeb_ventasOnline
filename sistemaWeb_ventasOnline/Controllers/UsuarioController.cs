using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sistemaWeb_ventasOnline.Entidades;
using sistemaWeb_ventasOnline.Models;

namespace sistemaWeb_ventasOnline.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AplicacionDBContext _context;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, AplicacionDBContext context)
        {
            _logger = logger;
            this._context = context;
        }
        [Route("Usuario/Login")] //Ruta a inicio de sesion
        public IActionResult Login()
    {
        return View();
    }

        [HttpPost]
        public IActionResult Login(string email, string contraseña)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                ModelState.AddModelError("", "El correo electrónico y la contraseña son obligatorios.");
                return View();
            }

            // Buscar el usuario en la base de datos
            var usuario = _context.Usuario
                .FirstOrDefault(u => u.email == email && u.contraseña == contraseña);

            if (usuario != null)
            {
                // Usuario autenticado correctamente
                // Aquí puedes guardar la información del usuario en una sesión o cookie
                HttpContext.Session.SetString("UsuarioId", usuario.idUsuario.ToString());
                HttpContext.Session.SetString("NombreUsuario", usuario.nombreUsuario);

                return RedirectToAction("Index", "Home"); // Redirige al dashboard o página principal
            }
            else
            {
                // Usuario no encontrado o contraseña incorrecta
                ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
                return View();
            }
        }

        
        [Route("Usuario/Registro")] //Ruta registrarse
        public IActionResult Registro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}