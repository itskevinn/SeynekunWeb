using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.ProductoStockModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoStockController : ControllerBase
    {
        private readonly ServicioAjusteInventario servicioAjuste;
        private readonly ServicioStock servicioStock;
        public ProductoStockController(SeynekunContext context)
        {
            servicioStock = new ServicioStock(context);
            servicioAjuste = new ServicioAjusteInventario(context);
        }
        [HttpGet("{nombre}")]
        public IEnumerable<ProductoStockViewModel> Get(string nombre)
        {
            var productos = servicioStock.ObtenerProductosEnBodega(nombre).Select(p => new ProductoStockViewModel(p));
            return productos;
        }
       
    }
}