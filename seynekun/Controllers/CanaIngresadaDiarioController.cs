using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}