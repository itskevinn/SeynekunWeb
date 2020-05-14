using System.Collections.Generic;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoStockController : ControllerBase
    {
        private readonly ServicioAjusteInventario _ajusteService;
        public ProductoStockController(AjusteInventarioContext context)
        {
            _ajusteService = new ServicioAjusteInventario(context);
        }

        [HttpGet("{codigoMateria}")]
        public IEnumerable<ProductoStock> GetProductosxMateria(decimal codigoMateria)
        {
            var ProductoStocks = _ajusteService.ObtenerProductosDeMateria(codigoMateria);
            if (ProductoStocks == null) return null;
            return ProductoStocks;
        }
        [HttpGet("{nombre}")]
        public IEnumerable<ProductoStock> GetProductosxBodega(string nombre)
        {
            var ProductoStocks = _ajusteService.ObtenerProductosEnBodega(nombre);
            if (ProductoStocks == null) return null;
            return ProductoStocks;
        }
    }
}