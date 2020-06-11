using System.Collections.Generic;
using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.MateriaPrimaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaDisponibleController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public MateriaPrimaDisponibleController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet]
        public IEnumerable<MateriaPrimaViewModel> GetDisponibles()
        {
            var response = materiaService.ConsultarDisponibles().ConvertAll(b => new MateriaPrimaViewModel(b));
            return response;
        }
    }
}