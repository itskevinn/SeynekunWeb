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
    public class MateriaPrimaController : ControllerBase
    {
        private readonly ServicioMateriaPrima materiaService;        
        public MateriaPrimaController(ContextoDB context)
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
                return BadRequest(response.Mensaje);
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
                UnidadMedida = materiaPrimaInputModel.UnidadMedida,
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
        public ActionResult<MateriaPrimaViewModel> Get(decimal codigo)
        {
            var materiaPrima = materiaService.BuscarxId(codigo).MateriaPrima;
            if (materiaPrima == null) return NotFound();
            var materiaPrimaViewModel = new MateriaPrimaViewModel(materiaPrima);
            return materiaPrimaViewModel;
        }
        [HttpPut("{codigo}")]
        public ActionResult<string> Put(MateriaPrima materiaPrima, decimal codigo)
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
        public ActionResult<string> Delete(decimal codigo)
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

