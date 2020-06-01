using Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace seynekun.Models
{
    public class BodegaModel
    {
        public class BodegaInputModel : Bodega
        {          
            public string Nombre { get; set; }
            public string Detalle { get; set; }
            public string Estado { get; set; }
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