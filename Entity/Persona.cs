using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Persona
    {
        [Required(ErrorMessage = "Se requiere un tipo de identificación")]
        [StringLength(3)]
        public string TipoIdentificacion { get; set; }

        [Key]
        [StringLength(30, ErrorMessage="Número de identificación demasiado largo")]
        [Required(ErrorMessage = "Se requiere un número de identificación")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "Se requiere un nombre")]
        [StringLength(30, ErrorMessage="Proporcione un nombre válido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere un apellido")]
        [StringLength(30, ErrorMessage="Proporcione un apellido válido")]
        public string Apellido { get; set; }
        [StringLength(13, ErrorMessage = "Proporcione un número de teléfono válido")]
        public string NumeroTelefono { get; set; }
        [StringLength(50, ErrorMessage = "Correo demasiado largo, por favor, proporcione una dirección de correo más corta")]
        public string Email { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Proporcione un estado válido")]
        public string Estado { get; set; }
    }
}
