using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProduccionCodigoController : ControllerBase
    {
        private readonly ServicioProduccion servicioProduccion;
        public ProduccionCodigoController(SeynekunContext context)
        {
            servicioProduccion = new ServicioProduccion(context);
        }

        // GET: api/ProduccionCodigo
        [HttpGet]
        public string GetCodigoProduccion()
        {
            return servicioProduccion.GenerarCodigoProduccion();
        }
    }
}
