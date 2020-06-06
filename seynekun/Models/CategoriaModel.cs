using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class CategoriaModel
    {
        public class CategoriaInputModel : Categoria
        {
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