using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Persona
    {   
        [Required]
        [StringLength(3)]
        public string TipoIdentificacion { get; set; }

        [Key]
        [StringLength(20)]
        public string Identificacion { get; set; }
        
        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(25)]
        public string Apellido { get; set; }
        
        [Required]
        [StringLength(13)]
        public string NumeroTelefono { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(3)]
        public string Estado { get; set; }
    }
}
