using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class Fabricante
    {
        [Required]
        [StringLength(20)]
        public string TipoIdentificacion { get; set; }

        [Key]
        [StringLength(20)]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(13)]
        public string NumeroTelefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Fax { get; set; }

        [Required]
        [StringLength(20)]
        public string SitioWeb { get; set; }
        public List<Insumo> Insumos { get; set; }

        [Required]
        [StringLength(13)]
        public string Estado { get; set; }
    }
}
