using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class FichaTecnica
    {
        [Key]
        [StringLength(20)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string IdInsumo { get; set; }

        [Required]
        [StringLength(20)]
        public string Ingrediente { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoIngrediente { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroCas { get; set; }

        [StringLength(20)]
        public string Observacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Ce { get; set; }

        [Required]
        [StringLength(20)]
        public string Nop { get; set; }

        [Required]
        [StringLength(20)]
        public string Jas { get; set; }

        [Required]
        [StringLength(20)]
        public string Etapa { get; set; }

        [Required]
        [StringLength(20)]
        public string Col { get; set; }

        [Required]
        [StringLength(13)]
        public string Estado { get; set; }
    }
}
