using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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