using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Logica;
using static seynekun.Models.BodegaModel;
using Datos;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController : ControllerBase
    {
        private readonly ServicioBodega servicioBodega;
        public BodegaController(SeynekunContext context)
        {
            servicioBodega = new ServicioBodega(context);
        }

        // POST: api/Bodega
        [HttpPost]
        public ActionResult<BodegaViewModel> Post(BodegaInputModel bodegaInputModel)
        {
            Bodega bodega = MapToBodega(bodegaInputModel);
            var response = servicioBodega.Guardar(bodega);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar bodega", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Bodega);
        }

        private Bodega MapToBodega(BodegaInputModel bodegaInputModel)
        {
            var bodega = new Bodega
            {
                Detalle = bodegaInputModel.Detalle,
                Nombre = bodegaInputModel.Nombre,
                Estado = "Activo",
                Direccion = bodegaInputModel.Direccion,
            };
            return bodega;
        }

        // GET: api/Bodega
        [HttpGet]
        public IEnumerable<BodegaViewModel> Gets()
        {
            var response = servicioBodega.Consultar().Select(b => new BodegaViewModel(b));
            return response;
        }


        [HttpGet("{nombre}")]
        public ActionResult<BodegaViewModel> Get(string nombre)
        {
            var bodega = servicioBodega.BuscarxId(nombre).Bodega;
            if (bodega == null) return NotFound();
            var bodegaViewModel = new BodegaViewModel(bodega);
            return bodegaViewModel;
        }
        [HttpPut("{nombre}")]
        public ActionResult<string> Put(string nombre, Bodega bodega)
        {
            var id = servicioBodega.BuscarxId(bodega.Nombre);
            if (id == null)
            {
                return BadRequest("Bodega no encontrada");
            }
            var mensaje = servicioBodega.Modificar(bodega);
            return Ok(mensaje);
        }
        [HttpDelete("{nombre}")]
        public ActionResult<string> Delete(string nombre)
        {
            var id = servicioBodega.BuscarxId(nombre);
            if (id == null) return BadRequest("Bodega no encontrada");
            string mensaje = servicioBodega.Eliminar(nombre);
            return Ok(mensaje);
        }
    }
}
