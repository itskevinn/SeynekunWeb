using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models {
    public class ClienteInputModel {        
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public string NumeroTelefono2 { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Barrio { get; set; }
    }

    public class ClienteViewModel : ClienteInputModel {

        public string Estado { get; set; }

        public ClienteViewModel(Cliente cliente) {
            TipoIdentificacion = cliente.TipoIdentificacion;
            Identificacion = cliente.Identificacion;
            Nombre = cliente.Nombre;
            Apellido = cliente.Apellido;
            NumeroTelefono = cliente.NumeroTelefono;
            NumeroTelefono2 = cliente.NumeroTelefono2;
            Email = cliente.Email;
            Direccion = cliente.Direccion;
            Departamento = cliente.Departamento;
            Municipio = cliente.Municipio;
            Barrio = cliente.Barrio;
            Estado = cliente.Estado;
        }
    }
}
