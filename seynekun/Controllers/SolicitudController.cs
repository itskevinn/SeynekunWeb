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
        [HttpPut("{identificacion}")]
        public ActionResult<string> PutEstado(string identificacion, Productor productor)
        {
            var id = servicioProductor.BuscarxId(identificacion).Productor;
            if (id == null) return NotFound();
            var mensaje = servicioProductor.ModificarEstado(productor);
            return Ok(mensaje);
        }
    }
}