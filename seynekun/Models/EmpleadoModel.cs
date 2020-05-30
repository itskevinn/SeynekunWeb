using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class EmpleadoInputModel
    {
        [Required(ErrorMessage = "El Tipo de Identificación es requerido")]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "La identificación es requerida")]
        public string Identificacion { get; set; }
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }

        [Required(ErrorMessage="Proporcione un correo")]
        [StringLength(30, ErrorMessage="Correo demasiado largo")]        
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo válido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        [StringLength(11, ErrorMessage="Estado demasido largo")]
        public string Estado { get; set; }
        
        [StringLength(30, ErrorMessage="Nombre del cargo demasiado largo")]        
        [Required(ErrorMessage = "Proporcione un cargo")]
        public string Cargo { get; set; }
    }

    public class EmpleadoViewModel : EmpleadoInputModel
    {
        public EmpleadoViewModel(Empleado empleado)
        {
            TipoIdentificacion = empleado.TipoIdentificacion;
            Identificacion = empleado.Identificacion;
            Nombre = empleado.Nombre;
            Apellido = empleado.Apellido;
            NumeroTelefono = empleado.NumeroTelefono;
            Email = empleado.Email;
            Estado = empleado.Estado;
            Cargo = empleado.Cargo;
        }
    }
}
