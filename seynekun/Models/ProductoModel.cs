using System.ComponentModel.DataAnnotations;
using Entity;

namespace seynekun.Models
{
    public class ProductoModel
    {
        public class ProductoInputModel
        {
            [Required(ErrorMessage = "Se necesita el código del producto")]
            [StringLength(30, ErrorMessage = "Código demasiado largo")]
            public string Codigo { get; set; }
            [Required(ErrorMessage = "Se requiere el nombre del producto")]
            [StringLength(30, ErrorMessage = "Nombre demasiado largo")]
            public string Nombre { get; set; }
            [Required(ErrorMessage = "Proporcione un precio para el producto")]
            public decimal Precio { get; set; }
            [Required(ErrorMessage = "El Estado es requerido")]
            [StringLength(13, ErrorMessage = "Estado demasido largo")]
            public string Estado { get; set; }
            [StringLength(100, ErrorMessage = "Descripción demasiado larga")]
            public string Descripcion { get; set; }
            [StringLength(17, ErrorMessage = "Nombre de caregoría inválido")]
            public string NombreCategoria { get; set; }
            [Required(ErrorMessage = "Se requiere la cantidad del producto")]
            public decimal Cantidad { get; set; }
            [Required(ErrorMessage = "Se requiere la unidad de medida del producto")]
            [StringLength(13, ErrorMessage = "Unidad inválida")]
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