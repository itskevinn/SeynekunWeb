using Entity;

namespace seynekun.Models
{
    public class ClienteInputModel : Persona
    {
        public string TipoIdentifiacion { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string NumeroTelefono2 { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Barrio { get; set; }
    }

    public class ClienteViewModel : ClienteInputModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            Identificacion = cliente.Identificacion;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            NumeroTelefono = cliente.NumeroTelefono;
            Barrio = cliente.Barrio;
            Direccion = cliente.Direccion;
            Departamento = cliente.Departamento;
            Municipio = cliente.Municipio;
            TipoIdentifiacion = cliente.TipoIdentificacion;
            Email = cliente.Email;
            Estado = cliente.Estado;
            NumeroTelefono2 = cliente.NumeroTelefono2;
        }
    }
}