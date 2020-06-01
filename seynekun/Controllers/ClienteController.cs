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

namespace seynekun.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {

        private readonly ServicioCliente servicioCliente;

        public ClienteController(SeynekunContext context)
        {
            servicioCliente = new ServicioCliente(context);
        }

        // POST: api/Cliente
        [HttpPost]
        public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInputModel)
        {
            Cliente cliente = MapToCliente(clienteInputModel);
            var response = servicioCliente.Guardar(cliente);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Cliente);
        }

        private Cliente MapToCliente(ClienteInputModel clienteInputModel)
        {
            var cliente = new Cliente
            {
                TipoIdentificacion = clienteInputModel.TipoIdentificacion,
                Identificacion = clienteInputModel.Identificacion,
                Nombre = clienteInputModel.Nombre,
                Apellido = clienteInputModel.Apellido,
                NumeroTelefono = clienteInputModel.NumeroTelefono,
                NumeroTelefono2 = clienteInputModel.NumeroTelefono2,
                Email = clienteInputModel.Email,
                Direccion = clienteInputModel.Direccion,
                Departamento = clienteInputModel.Departamento,
                Municipio = clienteInputModel.Municipio,
                Barrio = clienteInputModel.Barrio
            };
            return cliente;
        }

        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<ClienteViewModel> Gets()
        {
            var response = servicioCliente.Consultar().Select(p => new ClienteViewModel(p));
            return response;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<ClienteViewModel> Get(string identificacion)
        {
            var response = servicioCliente.BuscarxId(identificacion);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            var cliente = new ClienteViewModel(response.Cliente);
            return cliente;
        }

        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(Cliente cliente, string identificacion)
        {
            var response = servicioCliente.BuscarxId(identificacion);
            if (response.Cliente == null)
            {
                return BadRequest("Cliente no econtrado");
            }
            else
            {
                var mensaje = servicioCliente.Modificar(cliente);
                return Ok(mensaje);
            }
        }

        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = servicioCliente.Eliminar(identificacion);
            return Ok(mensaje);
        }
    }
}
