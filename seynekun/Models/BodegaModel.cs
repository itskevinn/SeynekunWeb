using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class BodegaModel
    {
        public class BodegaInputModel : Bodega
        {
            [Required(ErrorMessage = "Proporcione un nombre")]
            [StringLength(20, ErrorMessage = "Nombre demasiado largo")]
            public string Nombre { get; set; }
            [StringLength(200, ErrorMessage = "Detalle demasiado largo")]
            public string Detalle { get; set; }
        }

        public class BodegaViewModel : BodegaInputModel
        {
            public BodegaViewModel(Bodega bodega)
            {
                Nombre = bodega.Nombre;
                Detalle = bodega.Detalle;
                Valor = bodega.Valor;
                Productos = bodega.Productos;
            }
        }
    }
}