using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaCantidadDiariaController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public MateriaPrimaCantidadDiariaController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet]
        public decimal GetCantidadDiaria()
        {
            return materiaService.SumarCantidadTotalDiaria();
        }
        [HttpGet("{codigo}")]
        public decimal GetCantidadDiariaProductor(string codigo)
        {
            return materiaService.SumarCantidadxProductorDiaria(codigo);
        }
    }
}