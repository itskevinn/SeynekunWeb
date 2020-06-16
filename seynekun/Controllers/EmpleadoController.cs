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
using Datos;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ServicioEmpleado servicioEmpleado;
        public EmpleadoController(SeynekunContext context)
        {
            servicioEmpleado = new ServicioEmpleado(context);
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
            return Ok(response.Empleado);
        }
        private Empleado MapToEmpleado(EmpleadoInputModel empleadoInputModel)
        {
            var empleado = new Empleado{
                TipoIdentificacion = empleadoInputModel.TipoIdentificacion,
                Identificacion = empleadoInputModel.Identificacion,
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
            var response = servicioEmpleado.Consultar().Empleados.ConvertAll(e => new EmpleadoViewModel(e));
            return response;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<EmpleadoViewModel> Get(string identificacion)
        {
            var empleado = servicioEmpleado.BuscarxId(identificacion).Empleado;
            if (empleado == null) return NotFound();
            var empleadoViewModel = new EmpleadoViewModel(empleado);
            return empleadoViewModel;
        }

        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(Empleado empleado, string identificacion)
        {
            var id = servicioEmpleado.BuscarxId(identificacion);
            if (id == null)
            {
                return BadRequest("Empleado no econtrado");
            }
            else
            {
                var mensaje = servicioEmpleado.Modificar(empleado);
                return Ok(mensaje);
            }
        }
        
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = servicioEmpleado.Eliminar(identificacion);
            return Ok(mensaje);
        }
    }
}
