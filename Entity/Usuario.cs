using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Usuario
    {
        [Key]
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        [Required]
        [StringLength(11)]
        public string Estado { get; set; }
        public string Tipo { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(25)]
        public string Apellido { get; set; }
        [StringLength(13)]
        public string NumeroTelefono { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
