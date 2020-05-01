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
    public class ProductorController : ControllerBase
    {

        private readonly ServicioProductor servicioProductor;
        public IConfiguration configuration { get; }

        public ProductorController(IConfiguration configuration)
        {
            this.configuration = configuration;
            string cadenaDeConexión = this.configuration["ConnectionStrings:DefaultConnection"];
            servicioProductor = new ServicioProductor(cadenaDeConexión);
        }

        // POST: api/Productor
        [HttpPost]
        public ActionResult<ProductorViewModel> Post(ProductorInputModel productorInputModel)
        {
            Productor productor = MapToProductor(productorInputModel);
            var response = servicioProductor.Guardar(productor);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.objeto);
        }

        private Productor MapToProductor(ProductorInputModel productorInputModel)
        {
            var productor = new Productor
            {
                Cedula = productorInputModel.Cedula,
                Nombre = productorInputModel.Nombre,
                Apellido = productorInputModel.Apellido,
                CedulaCafetera = productorInputModel.CedulaCafetera,
                NombrePredio = productorInputModel.NombrePredio,
                CodigoFinca = productorInputModel.CodigoFinca,
                CodigoSica = productorInputModel.CodigoSica,
                Municipio = productorInputModel.Municipio,
                Vereda = productorInputModel.Vereda,
                NumeroTelefono = productorInputModel.NumeroTelefono,
                AfiliacionSalud = productorInputModel.AfiliacionSalud,
                Estado = productorInputModel.Estado,
            };
            return productor;
        }

        // GET: api/Productor
        [HttpGet]
        public IEnumerable<ProductorViewModel> Gets()
        {
            var response = servicioProductor.Consultar().objetos.Select(p => new ProductorViewModel(p));
            return response;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<ProductorViewModel> Get(string identificacion)
        {
            var productor = servicioProductor.BuscarxId(identificacion).Productor;
            if (productor == null) return NotFound();
            var productorViewModel = new ProductorViewModel(productor);
            return productorViewModel;
        }
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(Productor productor, string identificacion)
        {
            var id = servicioProductor.BuscarxId(identificacion);
            if (id == null)
            {
                return BadRequest("Productor no econtrado");
            }
            else
            {
                var mensaje = servicioProductor.Modificar(productor);
                return Ok(mensaje);
            }
        }
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = servicioProductor.Eliminar(identificacion);
            return Ok(mensaje);
        }
    }
}