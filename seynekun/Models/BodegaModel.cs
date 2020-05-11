using Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
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
            [Required(ErrorMessage = "Proporcione un estado")]
            [StringLength(13, ErrorMessage = "Estado inválido")]
            public string Estado { get; set; }
            [StringLength(100,ErrorMessage="Direccion demasiado larga, trate de simplificarla")]
            public string Direccion { get; set; }            
        }

        public class BodegaViewModel : BodegaInputModel
        {
            public BodegaViewModel(Bodega bodega)
            {
                Nombre = bodega.Nombre;
                Detalle = bodega.Detalle;
                Direccion = bodega.Direccion;
                Estado = bodega.Estado;
                Ajustes = bodega.Ajustes;
            }
        }
    }
}