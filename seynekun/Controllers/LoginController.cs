using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using seynekun.Config;
using seynekun.Models;
using seynekun.Servicio;

namespace seynekun.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private ServicioJwt _servicioJwt;
        private ServicioUsuario _servicioUsuario;

        private readonly SeynekunContext _context;
        public LoginController(SeynekunContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            var admin = _context.Usuarios.Find("admin");
            if (admin == null)
            {
                _context.Usuarios.Add(new Entity.Usuario() { NombreUsuario = "admin", Contrasena="admin", Estado ="Activo", Nombre="Adminitrador", Apellido="Administrador", NumeroTelefono="31800000000", Email = "admin@gmail.com"});
                var i = _context.SaveChanges();
            }
            _servicioJwt = new ServicioJwt(appSettings);
            _servicioUsuario = new ServicioUsuario(context);
        }

        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Login(LoginInputModel model)
        {
            var user = _servicioUsuario.ValidarUsuario(model.NombreUsuario, model.Contrasena);

            if (user == null)
            {
                ModelState.AddModelError("Acceso Denegado", "Username or password is incorrect");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var response = _servicioJwt.GenerarToken(user);

            return Ok(response);
        }
    }
}
