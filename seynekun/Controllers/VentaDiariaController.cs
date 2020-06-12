using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaDiariaController : ControllerBase
    {
        private readonly ServicioVenta ventaService;
        public VentaDiariaController(SeynekunContext context)
        {
            ventaService = new ServicioVenta(context);
        }
        [HttpGet]
        public decimal GetCantidadDiaria()
        {
            return ventaService.SumarCantidadTotalDiaria();
        }
    }
}