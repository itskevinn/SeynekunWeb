using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Documento
    {
        [Key]
        [StringLength(20)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string IdInsumo { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Enlace { get; set; }

        [StringLength(20)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(13)]
        public string Estado { get; set; }
    }
}
