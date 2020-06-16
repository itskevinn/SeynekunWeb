using Datos;
using Microsoft.AspNetCore.Mvc;
using Logica;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoCodigoController : ControllerBase
    {
        private readonly ServicioProducto servicioProducto;
        public ProductoCodigoController(SeynekunContext context)
        {
            servicioProducto = new ServicioProducto(context);
        }

        // GET: api/ProductoCodigo
        [HttpGet]
        public string GetCodigo()
        {
            return servicioProducto.GenerarCodigoProducto();
        }
    }
}
