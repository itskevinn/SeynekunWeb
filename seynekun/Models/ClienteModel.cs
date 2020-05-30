using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models {
    public class ClienteInputModel {        

        [Required(ErrorMessage = "El Tipo de Identificación es requerido")]
        public string TipoIdentificacion { get; set; }

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [StringLength(13, ErrorMessage="Ingrese un número de telefono válido")]       
        public string NumeroTelefono { get; set; }

        public string NumeroTelefono2 { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo válido")]
        [EmailAddress(ErrorMessage="Ingrese un correo electrónico válido")]
        [StringLength(30, ErrorMessage="Correo demasiado largo")] 
        public string Email { get; set; }
        
        [StringLength(40, ErrorMessage="Dirección demasido larga, trate de simplificarla")]
        public string Direccion { get; set; }

        [StringLength(14, ErrorMessage="Departamento inválido")]
        public string Departamento { get; set; }

        public string Municipio { get; set; }

        [StringLength(30, ErrorMessage="Nombre del barrio demasiado largo, trate de simplificarlo")]
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
