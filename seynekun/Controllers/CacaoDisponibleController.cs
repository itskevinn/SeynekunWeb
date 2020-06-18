using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{id}")]
        public decimal GetCantidadCacaoxProductor(string id)
        {
            return materiaService.SumarCantidadCacaoxProductor(id);
        }
    }
}