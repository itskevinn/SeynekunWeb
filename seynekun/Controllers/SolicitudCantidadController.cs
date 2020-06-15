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
    public class SolicitudCantidadController
    {
        private readonly ServicioProductor servicioProductor;

        public SolicitudCantidadController(SeynekunContext context)
        {
            servicioProductor = new ServicioProductor(context);
        }
       [HttpGet]
        public decimal GetCantidadSolicitud()
        {
            return servicioProductor.SumarCantidadSolicitud();
        }
    }
}