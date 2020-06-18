using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet("{id}")]
        public decimal GetCantidadDiariaCafexProductor(string id)
        {
            return materiaService.SumarCantidadDiariaCafexProductor(id);
        }
    }
}