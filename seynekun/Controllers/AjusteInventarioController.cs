using System.Collections.Generic;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.AjusteInventarioModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjusteInventarioController : ControllerBase
    {
        private readonly ServicioAjusteInventario _ajusteService;
        public AjusteInventarioController(AjusteInventarioContext context)
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
                return BadRequest(response.Mensaje);
            }
            return Ok(response.AjusteInventario);
        }

        private AjusteInventario MapToAjusteInventario(AjusteInventarioInputModel ajusteInventarioInputModel)
        {
            var ajusteInventario = new AjusteInventario
            {
                Codigo = ajusteInventarioInputModel.Codigo,
                Fecha = ajusteInventarioInputModel.Fecha,
                Descipcion = ajusteInventarioInputModel.Descipcion,
                Cantidad = ajusteInventarioInputModel.Cantidad,
                CodigoElemento = ajusteInventarioInputModel.CodigoElemento,
                Tipo = ajusteInventarioInputModel.Tipo,
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
        public ActionResult<AjusteInventarioViewModel> Get(decimal codigo)
        {
            var ajusteInventario = _ajusteService.BuscarxId(codigo).AjusteInventario;
            if (ajusteInventario == null) return NotFound();
            var ajusteInventarioViewModel = new AjusteInventarioViewModel(ajusteInventario);
            return ajusteInventarioViewModel;
        }
        [HttpPut("{codigo}")]
        public ActionResult<string> Put(AjusteInventario ajusteInventario, decimal codigo)
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
        public ActionResult<string> Delete(decimal codigo)
        {
            var id = _ajusteService.BuscarxId(codigo);
            if (id == null)
            {
                return BadRequest("Ajuste de Inventario no econtrado");
            }
            else
            {
                string mensaje = _ajusteService.Eliminar(codigo);
                return Ok(mensaje);
            }
        }
        [HttpGet("{bodega}/{producto}")]
       public ActionResult<decimal> GetCantidad(string bodega, string producto)
        {
            var cantidadSumada = _ajusteService.SumarCantidad(producto, bodega);
            if (cantidadSumada == -1) return NoContent();
            var cantidad = cantidadSumada;
            return cantidad;
        }
    }
}