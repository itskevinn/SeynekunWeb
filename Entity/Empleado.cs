using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Empleado : Persona
    {
        [StringLength(30, ErrorMessage="Nombre del cargo demasiado largo")]        
        [Required(ErrorMessage = "Proporcione un cargo")]
        public string Cargo { get; set; }
    }
}