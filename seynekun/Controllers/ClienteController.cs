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
    public class ClienteController : ControllerBase
    {
        private readonly ServicioCliente servicioCliente;
        public IConfiguration configuration { get; }

        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            string cadenaDeConexión = this.configuration["ConnectionStrings:DefaultConnection"];
            servicioCliente = new ServicioCliente(cadenaDeConexión);
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
                TipoIdentificacion = clienteInputModel.TipoIdentifiacion,
                Identificacion = clienteInputModel.Identificacion,
                Nombre = clienteInputModel.Nombre,
                Apellido = clienteInputModel.Apellido,
                NumeroTelefono = clienteInputModel.NumeroTelefono,
                NumeroTelefono2 = clienteInputModel.NumeroTelefono2,
                Email = clienteInputModel.Email,
                Departamento = clienteInputModel.Departamento,
                Municipio = clienteInputModel.Municipio,
                Direccion = clienteInputModel.Direccion,
                Barrio = clienteInputModel.Barrio,
                Estado = "Activo"
            };
            return cliente;
        }

        // GET: api/Cliente
        [HttpGet]
        public IEnumerable<ClienteViewModel> Gets()
        {
            var response = servicioCliente.Consultar().objetos.Select(p => new ClienteViewModel(p));
            return response;
        }


        [HttpGet("{identificacion}")]
        public ActionResult<ClienteViewModel> Get(string identificacion)
        {
            var cliente = servicioCliente.BuscarxId(identificacion).Cliente;
            if (cliente == null) return NotFound();
            var clienteViewModel = new ClienteViewModel(cliente);
            return clienteViewModel;
        }
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(Cliente cliente, string identificacion)
        {
            var id = servicioCliente.BuscarxId(identificacion);
            if (id == null)
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