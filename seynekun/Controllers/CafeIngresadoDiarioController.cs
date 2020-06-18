using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CafeIngresadoDiarioController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public CafeIngresadoDiarioController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet]
        public decimal GetCantidadDiariaCafe()
        {
            return materiaService.SumarCantidadDiariaCafe();
        }
    }
}