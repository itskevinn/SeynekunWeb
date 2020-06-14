using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static seynekun.Models.ProduccionModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduccionController : ControllerBase
    {
        private readonly ServicioProduccion servicioProduccion;
        public ProduccionController(SeynekunContext context)
        {
            servicioProduccion = new ServicioProduccion(context);
        }

        // POST: api/Produccion
        [HttpPost]
        public ActionResult<ProduccionViewModel> Post(ProduccionInputModel produccionInput)
        {
            Produccion produccion = MapToProduccion(produccionInput);
            var response = servicioProduccion.Guardar(produccion);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar produccion", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Produccion);
        }
        private Produccion MapToProduccion(ProduccionInputModel produccionInput)
        {
            Produccion produccion = new Produccion
            {
                CodigoProduccion = produccionInput.CodigoProduccion,
                Fecha = produccionInput.Fecha,
                Descripcion = produccionInput.Descripcion,
                Ajustes = produccionInput.Ajustes
            };
            return produccion;
        }

        // GET: api/Produccion
        [HttpGet]
        public IEnumerable<ProduccionViewModel> Gets()
        {
            var response = servicioProduccion.Consultar().Producciones.Select(p => new ProduccionViewModel(p));
            return response;
        }

        [HttpGet("{codigo}")]
        public ActionResult<ProduccionViewModel> Get(string codigo)
        {
            Produccion produccion = servicioProduccion.Buscar(codigo).Produccion;
            if (produccion == null) return NotFound();
            var produccionView = new ProduccionViewModel(produccion);
            return produccionView;
        }
    }
}
