using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Entity;
using System;

namespace seynekun.Models
{
    public class ProduccionModel
    {
        public class ProduccionInputModel
        {
            [StringLength(20, ErrorMessage = "Ingrese un codigo de produccion valido")]
            public string CodigoProduccion { get; set; }

            [Required(ErrorMessage="Se requiere la fecha")]
            public DateTime Fecha { get; set; }

            [StringLength(256)]
            public string Descripcion { get; set; }

            [Required(ErrorMessage="Se requieren los ajustes")]
            public List<AjusteInventario> Ajustes { get; set; }
        }

        public class ProduccionViewModel : ProduccionInputModel
        {
            public ProduccionViewModel(Produccion produccion)
            {
                CodigoProduccion = produccion.CodigoProduccion;
                Fecha = produccion.Fecha;
                Descripcion = produccion.Descripcion;
                Ajustes = produccion.Ajustes;
            }
        }
    }
}
