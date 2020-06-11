using System.Collections.Generic;
using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.MateriaPrimaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaProductorController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public MateriaPrimaProductorController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        [HttpGet("{codigo}")]
        public ActionResult<MateriaPrimaViewModel> GetInfo(string codigo)
        {
            var materia = materiaService.BuscarxId(codigo).MateriaPrima;
            if (materia == null) return NotFound();
            var materiaViewModel = new MateriaPrimaViewModel(materia);
            return materiaViewModel;
        }
    }
}