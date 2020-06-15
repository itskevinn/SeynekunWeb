using System.Collections.Generic;
using Datos;
using Entity;
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
           [HttpPut("{codigo}")]
           public ActionResult<string> PutEstado(decimal cantidad, string codigo)
           {
               var id = materiaService.BuscarxId(codigo);
               if (id == null)
               {
                   return BadRequest("Materia Prima no econtrada");
               }
               else
               {
                   var mensaje = materiaService.ModificarCantidad(codigo, cantidad);
                   if (mensaje.Modificada)
                   {
                       return Ok(mensaje.Mensaje);
                   }
                   else
                   {
                       return BadRequest(mensaje.Mensaje);
                   }
               }
           }
        [HttpGet("{codigo}")]
        public ActionResult<MateriaPrimaViewModel> GetMateria(string codigo)
        {
            var materia = materiaService.BuscarxId(codigo).MateriaPrima;
            if (materia == null) return NotFound();
            var materiaViewModel = new MateriaPrimaViewModel(materia);
            return materiaViewModel;
        }
    }
}