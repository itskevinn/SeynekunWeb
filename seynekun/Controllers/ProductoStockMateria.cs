using System.Collections.Generic;
using System.Linq;
using Datos;
using Logica;
using Microsoft.AspNetCore.Mvc;
using static seynekun.Models.ProductoStockModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoStockMateriaController : ControllerBase
    {
        private readonly ServicioAjusteInventario servicioAjuste;
        private readonly ServicioStock servicioStock;
        public ProductoStockMateriaController(SeynekunContext context)
        {
            servicioStock = new ServicioStock(context);
            servicioAjuste = new ServicioAjusteInventario(context);
        }
        [HttpGet("{codigo}")]
        public IEnumerable<ProductoStockViewModel> Gets(string codigo)
        {
            var productos = servicioAjuste.ObtenerProductosDeMateria(codigo).Select(p => new ProductoStockViewModel(p));
            return productos;
        }

    }
}