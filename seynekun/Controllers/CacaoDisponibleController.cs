using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacaoDisponibleController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public CacaoDisponibleController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet]
        public decimal GetCantidadCacao()
        {
            return materiaService.SumarCantidadCacao();
        }
    }
}