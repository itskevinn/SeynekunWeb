using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class EmpleadoInputModel
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
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
