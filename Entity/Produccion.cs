using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Entity
{
    public class Produccion
    {
        [Required(ErrorMessage = "Ingrese un código de producción")]
        [Key]
        [StringLength(20, ErrorMessage = "Ingrese un codigo de produccion valido")]
        public string CodigoProduccion { get; set; }

        [Required(ErrorMessage = "Se requiere la fecha")]
        public DateTime Fecha { get; set; }

        [StringLength(256, ErrorMessage = "Ingrese una descripcion válida")]
        public string Descripcion { get; set; }
        public List<AjusteInventario> Ajustes { get; set; }
    }
}
