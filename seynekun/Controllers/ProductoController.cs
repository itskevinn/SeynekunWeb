using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static seynekun.Models.ProductoModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ServicioProducto servicioProducto;

        public ProductoController(SeynekunContext context)
        {
            servicioProducto = new ServicioProducto(context);
        }

        // POST: api/Producto
        [HttpPost]
        public ActionResult<ProductoViewModel> Post(ProductoInputModel productoInputModel)
        {
            Producto producto = MapToProducto(productoInputModel);
            var response = servicioProducto.Guardar(producto);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Producto);
        }

        private Producto MapToProducto(ProductoInputModel productoInputModel)
        {
            var producto = new Producto
            {
                Codigo = productoInputModel.Codigo,
                Nombre = productoInputModel.Nombre,
                NombreCategoria = productoInputModel.NombreCategoria,                
                Descripcion = productoInputModel.Descripcion,
                Precio = productoInputModel.Precio,
                Estado = "Activo",
                Cantidad = productoInputModel.Cantidad,
                UnidadMedida = productoInputModel.UnidadMedida
            };
            return producto;
        }

        // GET: api/Producto
        [HttpGet]
        public IEnumerable<ProductoViewModel> Gets()
        {
            var response = servicioProducto.Consultar().Select(p => new ProductoViewModel(p));
            return response;
        }


        [HttpGet("{codigo}")]
        public ActionResult<ProductoViewModel> Get(string codigo)
        {
            var producto = servicioProducto.BuscarxId(codigo).Producto;
            if (producto == null) return NotFound();
            var productoViewModel = new ProductoViewModel(producto);
            return productoViewModel;
        }
        [HttpPut("{codigo}")]
        public ActionResult<string> Put(Producto producto, string codigo)
        {
            var id = servicioProducto.BuscarxId(codigo);
            if (id == null)
            {
                return BadRequest("Producto no econtrado");
            }
            else
            {
                var mensaje = servicioProducto.Modificar(producto);
                return Ok(mensaje);
            }
        }
        [HttpDelete("{codigo}")]
        public ActionResult<string> Delete(string codigo)
        {
            string mensaje = servicioProducto.Eliminar(codigo);
            return Ok(mensaje);
        }
    }
}
