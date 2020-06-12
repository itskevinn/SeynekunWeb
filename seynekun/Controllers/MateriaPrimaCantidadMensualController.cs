using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaCantidadMensualController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public MateriaPrimaCantidadMensualController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet]
        public decimal GetCantidadMensual()
        {
            return materiaService.SumarCantidadTotalMensual();
        }
        [HttpGet("{codigo}")]
        public decimal GetCantidadMensualProductor(string codigo)
        {
            return materiaService.SumarCantidadxProductorMensual(codigo);
        }
    }
}