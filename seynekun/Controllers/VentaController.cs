using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static seynekun.Models.VentaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ServicioVenta servicioVenta;

        public VentaController(SeynekunContext context)
        {
            servicioVenta = new ServicioVenta(context);
        }

        // POST: api/Venta
        [HttpPost]
        public ActionResult<VentaViewModel> Post(VentaInputModel ventaInputModel)
        {
            Venta venta = MapToVenta(ventaInputModel);
            var response = servicioVenta.Guardar(venta);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar venta", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Venta);
        }
        private Venta MapToVenta(VentaInputModel ventaInputModel)
        {
            Venta venta = new Venta
            {
                CodigoVenta = ventaInputModel.CodigoVenta,
                ClienteId = ventaInputModel.ClienteId,
                DetallesVentas = ventaInputModel.DetallesVentas,
                Fecha = ventaInputModel.Fecha,
                Observacion = ventaInputModel.Observacion,
                TotalVenta = ventaInputModel.TotalVenta
            };
            return venta;
        }

        // GET: api/Venta
        [HttpGet]
        public IEnumerable<VentaViewModel> Gets()
        {
            var response = servicioVenta.Consultar().Ventas.Select(v => new VentaViewModel(v));
            return response;
        }

        [HttpGet("{codigo}")]
        public ActionResult<VentaViewModel> Get(string codigo)
        {
            var venta = servicioVenta.Buscar(codigo).Venta;
            if (venta == null) return NotFound();
            var ventaViewModel = new VentaViewModel(venta);
            return ventaViewModel;
        }
    }
}
