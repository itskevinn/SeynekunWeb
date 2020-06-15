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
    public class ReporteController : ControllerBase
    {
         private readonly ServicioReporte servicioReporte;
         public ReporteController(SeynekunContext context)
         {
             servicioReporte = new ServicioReporte(context);
         }

         // POST: api/Reporte
        [HttpPost]
        public ActionResult<string> Post(string tipo)
        {
            string mensaje = servicioReporte.GenerarReporte("Reporte de empleados");
            return Ok(mensaje);
        }
    }
}
