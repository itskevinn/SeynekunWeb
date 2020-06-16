using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using seynekun.Models;
using Logica;
using Datos;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly ServicioFabricante servicioFabricante;

        public FabricanteController(SeynekunContext context)
        {
            servicioFabricante = new ServicioFabricante(context);
        }
        
        // POST: api/Fabricante
        [HttpPost]
        public ActionResult<FabricanteViewModel> Post(FabricanteInputModel fabricanteInputModel)
        {
            Fabricante fabricante = MapToFabricante(fabricanteInputModel);
            var response = servicioFabricante.Guardar(fabricante);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Fabricante);
        }

        private Fabricante MapToFabricante(FabricanteInputModel fabricanteInputModel)
        {
            var fabricante = new Fabricante
            {
                TipoIdentificacion = fabricanteInputModel.TipoIdentificacion,
                Identificacion = fabricanteInputModel.Identificacion,
                Nombre = fabricanteInputModel.Nombre,
                NumeroTelefono = fabricanteInputModel.NumeroTelefono,
                Email = fabricanteInputModel.Email,
                Direccion = fabricanteInputModel.Direccion,
                Fax = fabricanteInputModel.Fax,
                SitioWeb = fabricanteInputModel.SitioWeb,
                Estado = fabricanteInputModel.Estado
            };
            return fabricante;
        }

        // GET: api/Fabricante
        [HttpGet]
        public IEnumerable<FabricanteViewModel> Gets()
        {
            var response = servicioFabricante.Consultar().Select(f => new FabricanteViewModel(f));
            return response;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<FabricanteViewModel> Get(string identificacion)
        {
            var response = servicioFabricante.BuscarxId(identificacion);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            var fabricante = new FabricanteViewModel(response.Fabricante);
            return Ok(fabricante);
        }

        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(Fabricante fabricante, string identificacion)
        {
            var response = servicioFabricante.BuscarxId(identificacion);
            if (response.Fabricante == null)
            {
                return BadRequest("Fabricante no econtrado");
            }
            var mensaje = servicioFabricante.Modificar(fabricante);
            return Ok(mensaje);
        }

        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = servicioFabricante.Eliminar(identificacion);
            return Ok(mensaje);
        }
    }
}
