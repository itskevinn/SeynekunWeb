using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Bodega
    {
        [Key]
        [Required(ErrorMessage = "Proporcione un nombre para la bodega")]
        [StringLength(20, ErrorMessage = "Nombre demasiado largo")]
        public string Nombre { get; set; }
        [StringLength(200, ErrorMessage = "Detalle demasiado largo")]
        public string Detalle { get; set; }
        [Required(ErrorMessage = "Proporcione un estado")]
        [StringLength(13, ErrorMessage = "Estado inválido")]
        public string Estado { get; set; }
        [StringLength(100, ErrorMessage = "Direccion demasiado larga, trate de simplificarla")]
        public string Direccion { get; set; }
        public List<AjusteInventario> Ajustes { get; set; }
    }
}