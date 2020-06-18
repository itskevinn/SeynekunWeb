using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CanaIngresadaDiario : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public CanaIngresadaDiario(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet]
        public decimal GetCantidadDiariaCana()
        {
            return materiaService.SumarCantidadDiariaCana();
        }
        [HttpGet("{id}")]
        public decimal GetCantidadDiariaCanaxProductor(string id)
        {
            return materiaService.SumarCantidadDiariaCanaxProductor(id);
        }
    }
}