using System.ComponentModel.DataAnnotations;
using Entity;

namespace seynekun.Models
{
    public class ProductoModel
    {
        public class ProductoInputModel : Producto
        {
            [Required(ErrorMessage = "Proporcione un precio para el producto")]                        
            public decimal Precio { get; set; }
            [Required(ErrorMessage = "El Estado es requerido")]
            [StringLength(13, ErrorMessage = "Estado demasido largo")]
            public string Estado { get; set; }
            [StringLength(100, ErrorMessage = "Descripción demasiado larga")]            
            public string Descripcion { get; set; }
            public string NombreCategoria { get; set; }
            public string NombreBodega { get; set; }
        }

        public class ProductoViewModel : ProductoInputModel
        {
            public ProductoViewModel(Producto producto)
            {
                Codigo = producto.Codigo;
                Nombre = producto.Nombre;
                NombreBodega = producto.NombreBodega;
                NombreCategoria = producto.NombreCategoria;
                Precio = producto.Precio;
                Estado = producto.Estado;
                Descripcion = producto.Descripcion;
            }
        }
    }
}