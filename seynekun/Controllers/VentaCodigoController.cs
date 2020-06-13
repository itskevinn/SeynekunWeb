using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Logica;
using static seynekun.Models.VentaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaCodigoController : ControllerBase
    {
        private readonly ServicioVenta servicioVenta;
        public VentaCodigoController(SeynekunContext context)
        {
            servicioVenta = new ServicioVenta(context);
        }

        // GET: api/VentaCodigo
        [HttpGet]
        public string GetCodigo()
        {
            return servicioVenta.GenerarCodigoVenta();
        }
    }
}
