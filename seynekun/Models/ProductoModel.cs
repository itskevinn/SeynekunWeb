using System.ComponentModel.DataAnnotations;
using Entity;

namespace seynekun.Models
{
    public class ProductoModel
    {
        public class ProductoInputModel :Producto
        {
            public string Codigo { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public string Estado { get; set; }
            public string Descripcion { get; set; }
            public string NombreCategoria { get; set; }
            public decimal Cantidad { get; set; }
            public string UnidadMedida { get; set; }
        }

        public class ProductoViewModel : ProductoInputModel
        {
            public ProductoViewModel(Producto producto)
            {
                Codigo = producto.Codigo;
                Nombre = producto.Nombre;
                NombreCategoria = producto.NombreCategoria;
                Precio = producto.Precio;
                Estado = producto.Estado;
                Descripcion = producto.Descripcion;
                Cantidad = producto.Cantidad;
                UnidadMedida = producto.UnidadMedida;
            }
        }
    }
}