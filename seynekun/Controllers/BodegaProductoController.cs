using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.BodegaProductoModel;
using Microsoft.AspNetCore.Authorization;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BodegaProductoController : ControllerBase
    {
        private readonly ServicioAjusteInventario servicioAjuste;
        private readonly ServicioStock servicioStock;
        public BodegaProductoController(SeynekunContext context)
        {
            servicioStock = new ServicioStock(context);
            servicioAjuste = new ServicioAjusteInventario(context);
        }
        [HttpGet("{nombre}")]
        public IEnumerable<BodegaProductoViewModel> Get(string nombre)
        {
            var productos = servicioStock.ObtenerBodegasxProducto(nombre).Select(p => new BodegaProductoViewModel(p));
            return productos;
        }
       
    }
}