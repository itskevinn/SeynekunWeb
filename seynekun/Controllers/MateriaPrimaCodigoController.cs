using Datos;
using Microsoft.AspNetCore.Mvc;
using Logica;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaCodigoController : ControllerBase
    {
        private readonly ServicioMateriaPrima servicioMateria;
        public MateriaPrimaCodigoController(SeynekunContext context)
        {
            servicioMateria = new ServicioMateriaPrima(context);
        }

        // GET: api/ProductoCodigo
        [HttpGet]
        public string GetCodigo()
        {
            return servicioMateria.GenerarCodigoMateria();
        }
    }
}
