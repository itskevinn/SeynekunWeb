using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class Insumo
    {
        [Key]
        [StringLength(20)]
        public string Id { get; set; }

        [StringLength(20)]
        public string IdFabricante { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Uso { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistroIca { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(20)]
        public string Resultado { get; set; }

        [Required]
        [StringLength(13)]
        public string Estado { get; set; }
        public List<Documento> Documentos { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
    }
}
