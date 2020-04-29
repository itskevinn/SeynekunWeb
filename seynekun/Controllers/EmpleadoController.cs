using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using seynekun.Models;
using Logica;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ServicioEmpleado servicioEmpleado;
        public IConfiguration configuration { get; }

        public EmpleadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            string cadenaDeConexión = this.configuration["ConnectionStrings:DefaultConnection"];
            servicioEmpleado = new ServicioEmpleado(cadenaDeConexión);
        }

        // POST: api/Empleado
        [HttpPost]
        public ActionResult<EmpleadoViewModel> Post(EmpleadoInputModel empleadoInputModel)
        {
            Empleado empleado = MapToEmpleado(empleadoInputModel);
            var response = servicioEmpleado.Guardar(empleado);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private Empleado MapToEmpleado(EmpleadoInputModel empleadoInputModel)
        {
            var empleado = new Empleado{
                Cedula = empleadoInputModel.Cedula,
                Nombre = empleadoInputModel.Nombre,
                Apellido = empleadoInputModel.Apellido,
                NumeroTelefono = empleadoInputModel.NumeroTelefono,
                Email = empleadoInputModel.Email,
                Cargo = empleadoInputModel.Cargo,
                Estado = "Activo"
            };
            return empleado;
        }

        // GET: api/Empleado
        [HttpGet]
        public IEnumerable<EmpleadoViewModel> Gets()
        {
            var response = servicioEmpleado.Consultar().objetos.Select(p=> new EmpleadoViewModel(p));
            return response;
        }
    }
}