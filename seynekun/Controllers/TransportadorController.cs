using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Logica;
using static seynekun.Models.TransportadorModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportadorController : ControllerBase
    {
        private readonly ServicioTransportador servicioTransportador;
        public TransportadorController(SeynekunContext context)
        {
            servicioTransportador = new ServicioTransportador(context);
        }

        // POST: api/Transportador
        [HttpPost]
        public ActionResult<TransportadorViewModel> Post(TransportadorInputModel transportadorInput)
        {
            Transportador transportador = MapToTransportador(transportadorInput);
            var response = servicioTransportador.Guardar(transportador);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar transportador", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Transportador);
        }
        private Transportador MapToTransportador(TransportadorInputModel transportadorInput)
        {
            Transportador transportador = new Transportador
            {
                Identificacion = transportadorInput.Identificacion,
                Nombre = transportadorInput.Nombre,
                Apellido = transportadorInput.Apellido,
                NumeroTelefono = transportadorInput.NumeroTelefono,
                NumeroLicencia = transportadorInput.NumeroLicencia,
                Email = transportadorInput.Email
            };
            return transportador;
        }

        // GET: api/Transportador
        [HttpGet]
        public IEnumerable<TransportadorViewModel> Gets()
        {
            var response = servicioTransportador.Consultar().Transportadores.Select(t => new TransportadorViewModel(t));
            return response;
        }

        [HttpGet("{codigo}")]
        public ActionResult<TransportadorViewModel> Get(string codigo)
        {
            var transportador = servicioTransportador.Buscar(codigo).Transportador;
            if (transportador == null) return NotFound();
            var transportadorViewModel = new TransportadorViewModel(transportador);
            return transportadorViewModel;
        }
    }
}
