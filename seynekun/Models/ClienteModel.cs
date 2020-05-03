using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class ClienteInputModel : Persona
    {        

        [Required(ErrorMessage = "El Tipo de Identificación es requerido")]
        public string TipoIdentifiacion { get; set; }        
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo válido")]
        [EmailAddress(ErrorMessage="Ingrese un correo electrónico válido")]
        [StringLength(30, ErrorMessage="Correo demasiado largo")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "El Estado es requerido")]
        [StringLength(13, ErrorMessage="Estado demasido largo")]
        public string Estado { get; set; }
        [StringLength(13, ErrorMessage="Ingrese un número válido")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un número válido")]        
        public string NumeroTelefono2 { get; set; }
        [StringLength(40, ErrorMessage="Dirección demasido larga, trate de simplificarla")]
        public string Direccion { get; set; }
         [StringLength(14, ErrorMessage="Departamento inválido")]
        public string Departamento { get; set; }
         [StringLength(14, ErrorMessage="Municipio inválido")]
        public string Municipio { get; set; }
         [StringLength(30, ErrorMessage="Nombre del barrio demasiado largo, trate de simplificarlo")]
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
