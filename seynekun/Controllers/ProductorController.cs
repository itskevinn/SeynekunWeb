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
using Microsoft.AspNetCore.SignalR;
using seynekun.Hubs;

namespace seynekun.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductorController : ControllerBase
    {

        private readonly ServicioProductor servicioProductor;
        private readonly IHubContext<SignalHub> _hubContext;

        public ProductorController(SeynekunContext context , IHubContext<SignalHub> hubContext)
        {
            servicioProductor = new ServicioProductor(context);
            _hubContext = hubContext;
        }

        // POST: api/Productor
        [HttpPost]
        public async Task<ActionResult<ProductorViewModel>> Post(ProductorInputModel productorInputModel)
        {
            Productor productor = MapToProductor(productorInputModel);
            var response = servicioProductor.Guardar(productor);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar al productor", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            var productorView =  new ProductorViewModel(response.Productor);
            await _hubContext.Clients.All.SendAsync("productorRegistrado",productorView);
            return Ok(productorView);
        }

        private Productor MapToProductor(ProductorInputModel productorInputModel)
        {
            var productor = new Productor
            {
                TipoIdentificacion = productorInputModel.TipoIdentificacion,
                Identificacion = productorInputModel.Identificacion,
                Nombre = productorInputModel.Nombre,
                Apellido = productorInputModel.Apellido,
                NumeroTelefono = productorInputModel.NumeroTelefono,
                CedulaCafetera = productorInputModel.CedulaCafetera,
                NombrePredio = productorInputModel.NombrePredio,
                CodigoFinca = productorInputModel.CodigoFinca,
                CodigoSica = productorInputModel.CodigoSica,
                Municipio = productorInputModel.Municipio,
                Vereda = productorInputModel.Vereda,
                AfiliacionSalud = productorInputModel.AfiliacionSalud,
                NombreUsuario = productorInputModel.NombreUsuario,
                Contrasena = productorInputModel.Contrasena,
                Email = productorInputModel.Email,
                Estado = productorInputModel.Estado
            };
            return productor;
        }

        // GET: api/Productor
        [HttpGet]
        public IEnumerable<ProductorViewModel> Gets()
        {
            var response = servicioProductor.Consultar().Select(p => new ProductorViewModel(p));
            return response;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<ProductorViewModel> Get(string identificacion)
        {
            var producto = servicioProductor.BuscarxId(identificacion).Productor;
            if (producto == null) return NotFound();
            var productoViewModel = new ProductorViewModel(producto);
            return productoViewModel;
        }

        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Productor productor)
        {
            var id = servicioProductor.BuscarxId(identificacion).Productor;
            if (id == null) return NotFound();
            var mensaje = servicioProductor.Modificar(productor);
            return Ok(mensaje);
        }

        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = servicioProductor.Eliminar(identificacion);
            return Ok(mensaje);
        }
    }
}
