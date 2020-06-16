using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using seynekun.Models;
using Logica;
using Datos;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {
        private readonly ServicioInsumo servicioInsumo;
        public InsumoController(SeynekunContext context)
        {
            servicioInsumo = new ServicioInsumo(context);
        }
        [HttpPost]
        public ActionResult<InsumoViewModel> Post(InsumoInputModel insumoInputModel)
        {
            Insumo insumo = MapToInsumo(insumoInputModel);
            var response = servicioInsumo.Guardar(insumo);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Insumo);
        }
        private Insumo MapToInsumo(InsumoInputModel insumoInputModel)
        {
            var insumo = new Insumo
            {
                Id = insumoInputModel.Id,
                Nombre = insumoInputModel.Nombre,
                RegistroIca = insumoInputModel.RegistroIca,
                Resultado = insumoInputModel.Resultado,
                IdFabricante = insumoInputModel.IdFabricante,
                Uso = insumoInputModel.Uso,
                Descripcion = insumoInputModel.Descripcion,
                FichaTecnica = insumoInputModel.FichaTecnica,
                Estado = "Activo"
            };
            return insumo;
        }

        // GET: api/Insumo
        [HttpGet]
        public IEnumerable<InsumoViewModel> Gets()
        {
            var response = servicioInsumo.Consultar().Insumos.ConvertAll(e => new InsumoViewModel(e));
            return response;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<InsumoViewModel> Get(string identificacion)
        {
            var insumo = servicioInsumo.BuscarInsumo(identificacion).Insumo;
            if (insumo == null) return NotFound();
            var insumoViewModel = new InsumoViewModel(insumo);
            return insumoViewModel;
        }

        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(Insumo insumo, string identificacion)
        {
            var id = servicioInsumo.BuscarInsumo(identificacion);
            if (id == null)
            {
                return BadRequest("Insumo no econtrado");
            }
            else
            {
                var mensaje = servicioInsumo.Modificar(insumo);
                return Ok(mensaje);
            }
        }

        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = servicioInsumo.Eliminar(identificacion);
            return Ok(mensaje);
        }
    }
}
