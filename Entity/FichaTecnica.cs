using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class FichaTecnica
    {
        [Key]
        [Required(ErrorMessage = "Proporcione el código de la ficha técnica")]
        [StringLength(20, ErrorMessage = "Código ficha técnica demasido largo")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Proporcione el código de referencia del insumo")]
        [StringLength(30, ErrorMessage = "Código referencia insumo inválido")]
        public string IdInsumo { get; set; }

        [StringLength(40, ErrorMessage = "Nombre del ingrediente demasiado largo, trate de simplificarlo")]
        public string Ingrediente { get; set; }

        [StringLength(40, ErrorMessage = "Tipo de ingrediente demasiado largo, trate de simplificarlo")]
        public string TipoIngrediente { get; set; }

        [StringLength(30, ErrorMessage = "Número CAS demasiado largo")]
        public string NumeroCas { get; set; }

        [StringLength(200, ErrorMessage = "Observación demasiado larga, trate de simplificarla")]
        public string Observacion { get; set; }

        public decimal Ce { get; set; }

        public decimal Nop { get; set; }

        public decimal Jas { get; set; }

        public decimal Efapa { get; set; }
        public decimal Col { get; set; }

    }
}
