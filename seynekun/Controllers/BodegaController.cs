
using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static seynekun.Models.BodegaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegaController
    {
        private readonly ServicioBodega servicioBodega;
        public IConfiguration configuration { get; }
        public BodegaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            string cadenaDeConexión = this.configuration["ConnectionStrings:DefaultConnection"];
            servicioBodega = new ServicioBodega(cadenaDeConexión);
        }

        // POST: api/Bodega
        [HttpPost]
        public ActionResult<BodegaViewModel> Post(BodegaInputModel bodegaInputModel)
        {
            Bodega bodega = MapToBodega(bodegaInputModel);
            var response = servicioBodega.Guardar(bodega);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Bodega);
        }

        private Bodega MapToBodega(BodegaInputModel bodegaInputModel)
        {
            var bodega = new Bodega
            {
                Detalle = bodegaInputModel.Detalle,
                Nombre = bodegaInputModel.Nombre,                
                Estado = "Activo"
            };
            return bodega;
        }

        // GET: api/Bodega
        [HttpGet]
        public IEnumerable<BodegaViewModel> Gets()
        {
            var response = servicioBodega.Consultar().Bodegas.Select(p => new BodegaViewModel(p));
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
        public ActionResult<string> Put(Bodega bodega, string nombre)
        {
            var id = servicioBodega.BuscarxId(nombre);
            if (id == null)
            {
                return BadRequest("Bodega no econtrada");
            }
            else
            {
                var mensaje = servicioBodega.Modificar(bodega);
                return Ok(mensaje);
            }
        }
        [HttpDelete("{nombre}")]
        public ActionResult<string> Delete(string nombre)
        {
            string mensaje = servicioBodega.Eliminar(nombre);
            return Ok(mensaje);
        }
    }
}
