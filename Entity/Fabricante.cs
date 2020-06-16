using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class Fabricante
    {
        [Required(ErrorMessage = "Proporcione un tipo de identificación")]
        [StringLength(20)]
        public string TipoIdentificacion { get; set; }

        [Key]
        [Required(ErrorMessage = "Proporcione el número de identificación del fabricante o la empresa fabricante")]
        [StringLength(20)]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Proporcione un nombre para el fabricante o la empresa fabricante")]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Proporcione la dirección del fabricante o la empresa fabricante")]
        [StringLength(20)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Proporcione un número de contacto del fabricante o la empresa fabricante")]
        [StringLength(13)]
        public string NumeroTelefono { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string SitioWeb { get; set; }
        public List<Insumo> Insumos { get; set; }

        [Required]
        [StringLength(13)]
        public string Estado { get; set; }
    }
}
