using System.Collections.Generic;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.MateriaPrimaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;
        public MateriaPrimaController(SeynekunContext context)
        {
            materiaService = new ServicioMateriaPrima(context);
        }
        // POST: api/MateriaPrima
        [HttpPost]
        public ActionResult<MateriaPrimaViewModel> Post(MateriaPrimaInputModel materiaPrimaInputModel)
        {
            MateriaPrima materiaPrima = MapToMateriaPrima(materiaPrimaInputModel);
            var response = materiaService.Guardar(materiaPrima);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar la materia prima", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.MateriaPrima);
        }

        private MateriaPrima MapToMateriaPrima(MateriaPrimaInputModel materiaPrimaInputModel)
        {
            var materiaPrima = new MateriaPrima
            {
                Codigo = materiaPrimaInputModel.Codigo,
                Fecha = materiaPrimaInputModel.Fecha,
                Cantidad = materiaPrimaInputModel.Cantidad,
                CodigoProductor = materiaPrimaInputModel.CodigoProductor,
                EstadoMateria = "Pendiente",
                NombreProductor = materiaPrimaInputModel.NombreProductor
            };
            return materiaPrima;
        }

        // GET: api/MateriaPrima
        [HttpGet]
        public IEnumerable<MateriaPrimaViewModel> Gets()
        {
            var response = materiaService.Consultar().ConvertAll(b => new MateriaPrimaViewModel(b));
            return response;
        }
        [HttpGet("{codigo}")]
        public IEnumerable<MateriaPrimaViewModel> Get(string codigo)
        {
            var response = materiaService.ConsultarxProductor(codigo).ConvertAll(b => new MateriaPrimaViewModel(b));
            return response;
        }
        
        [HttpPut("{codigo}")]
        public ActionResult<string> Put(MateriaPrima materiaPrima, string codigo)
        {
            var id = materiaService.BuscarxId(codigo);
            if (id == null)
            {
                return BadRequest("Materia Prima no econtrada");
            }
            else
            {
                var mensaje = materiaService.Modificar(materiaPrima);
                return Ok(mensaje);
            }
        }
        [HttpDelete("{codigo}")]
        public ActionResult<string> Delete(string codigo)
        {
            var id = materiaService.BuscarxId(codigo);
            if (id == null)
            {
                return BadRequest("materiaPrima de Inventario no econtrado");
            }
            else
            {
                string mensaje = materiaService.Eliminar(codigo);
                return Ok(mensaje);
            }
        }
    }
}


