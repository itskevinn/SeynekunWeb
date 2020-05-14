using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class CategoriaModel
    {
        public class CategoriaInputModel : Categoria
        {
            [Required(ErrorMessage = "Proporcione un nombre")]
            [StringLength(20, ErrorMessage = "Nombre demasiado largo")]
            public string Nombre { get; set; }
            [StringLength(200, ErrorMessage = "Detalle demasiado largo")]
            public string Detalle { get; set; }
            [Required(ErrorMessage = "Proporcione un estado")]
            [StringLength(13, ErrorMessage = "Estado inválido")]
            public string Estado { get; set; }
        }

        public class CategoriaViewModel : CategoriaInputModel
        {
            public CategoriaViewModel(Categoria categoria)
            {
                Nombre = categoria.Nombre;
                Detalle = categoria.Detalle;
                Productos = categoria.Productos;
                Estado = categoria.Estado;
            }
        }
    }
}