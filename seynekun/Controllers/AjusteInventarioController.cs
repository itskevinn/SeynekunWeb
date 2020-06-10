using System.Collections.Generic;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using static seynekun.Models.AjusteInventarioModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjusteInventarioController : ControllerBase
    {
        private readonly ServicioAjusteInventario _ajusteService;
        public AjusteInventarioController(SeynekunContext context)
        {
            _ajusteService = new ServicioAjusteInventario(context);
        }

        // POST: api/AjusteInventario
        [HttpPost]
        public ActionResult<AjusteInventarioViewModel> Post(AjusteInventarioInputModel ajusteInventarioInputModel)
        {
            AjusteInventario ajusteInventario = MapToAjusteInventario(ajusteInventarioInputModel);
            var response = _ajusteService.Guardar(ajusteInventario);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar ajuste", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.AjusteInventario);
        }

        private AjusteInventario MapToAjusteInventario(AjusteInventarioInputModel ajusteInventarioInputModel)
        {
            var ajusteInventario = new AjusteInventario
            {
                CodigoAjuste = ajusteInventarioInputModel.CodigoAjuste,
                TipoElemento = ajusteInventarioInputModel.TipoElemento,
                NombreElemento = ajusteInventarioInputModel.NombreElemento,
                CodigoElemento = ajusteInventarioInputModel.CodigoElemento,
                Fecha = ajusteInventarioInputModel.Fecha,
                TipoAjuste = ajusteInventarioInputModel.TipoAjuste,
                Descripcion = ajusteInventarioInputModel.Descripcion,
                Cantidad = ajusteInventarioInputModel.Cantidad,
                NombreBodega = ajusteInventarioInputModel.NombreBodega,
            };
            return ajusteInventario;
        }

        // GET: api/AjusteInventario
        [HttpGet]
        public IEnumerable<AjusteInventarioViewModel> Gets()
        {
            var response = _ajusteService.Consultar().ConvertAll(b => new AjusteInventarioViewModel(b));
            return response;
        }
        [HttpGet("{codigo}")]
        public ActionResult<AjusteInventarioViewModel> Get(string codigo)
        {
            var ajusteInventario = _ajusteService.BuscarxId(codigo).AjusteInventario;
            if (ajusteInventario == null) return NotFound();
            var ajusteInventarioViewModel = new AjusteInventarioViewModel(ajusteInventario);
            return ajusteInventarioViewModel;
        }
        [HttpPut("{codigo}")]
        public ActionResult<string> Put(AjusteInventario ajusteInventario, string codigo)
        {
            var id = _ajusteService.BuscarxId(codigo);
            if (id == null)
            {
                return BadRequest("Ajuste de Inventario no econtrado");
            }
            else
            {
                var mensaje = _ajusteService.Modificar(ajusteInventario);
                return Ok(mensaje);
            }
        }
        [HttpDelete("{codigo}")]
        public ActionResult<string> Delete(string codigo)
        {
            var ajuste = _ajusteService.BuscarxId(codigo).AjusteInventario;
            if (ajuste == null)
            {
                return BadRequest("Ajuste de Inventario no encontrado");
            }
            else
            {
                string mensaje = _ajusteService.Eliminar(ajuste.CodigoAjuste);
                return Ok(mensaje);
            }
        }    
    }
}
