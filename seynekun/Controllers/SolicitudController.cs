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
    public class SolicitudController : ControllerBase
    {
        private readonly ServicioProductor servicioProductor;

        public SolicitudController(SeynekunContext context)
        {
            servicioProductor = new ServicioProductor(context);
        }
        [HttpGet]
        public IEnumerable<ProductorViewModel> Gets()
        {
            var response = servicioProductor.ConsultarPendientes().Select(p => new ProductorViewModel(p));
            return response;
        }

        [HttpPut("{identificacion},{estado}")]
        public ActionResult<string> PutEstado(string identificacion, string estado)
        {
            var productorBuscado = servicioProductor.BuscarxIdModEstado(identificacion).Productor;
            if (productorBuscado == null) return NotFound();

            productorBuscado.Estado = estado;
            var mensaje = servicioProductor.ModificarEstado(productorBuscado);
            return Ok(mensaje);
        }
    }
}