using Entity;

namespace seynekun.Models
{
    public class EmpleadoInputModel : Persona
    {
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Cargo { get; set; }
    }

    public class EmpleadoViewModel: EmpleadoInputModel
    {
        public EmpleadoViewModel(Empleado empleado)
        {
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