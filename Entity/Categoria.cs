using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Categoria
    {
        [Key]
        [Required(ErrorMessage = "Proporcione un nombre")]
        [StringLength(20, ErrorMessage = "Nombre demasiado largo")]
        public string Nombre { get; set; }
        [StringLength(200, ErrorMessage = "Detalle demasiado largo")]
        public string Detalle { get; set; }
        [Required(ErrorMessage = "Proporcione un estado")]
        [StringLength(13, ErrorMessage = "Estado inválido")]
        public string Estado { get; set; }
        public List<Producto> Productos { get; set; }
    }
}