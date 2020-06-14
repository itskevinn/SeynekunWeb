using System.ComponentModel.DataAnnotations;
using Entity;

namespace seynekun.Models
{
    public class TransportadorModel
    {
        public class TransportadorInputModel
        {
            [StringLength(20, ErrorMessage = "Ingrese un numero de identificacion valido")]
            public string Identificacion { get; set; }

            [Required(ErrorMessage="Se requiere el nombre")]
            [StringLength(30, ErrorMessage = "Ingrese el nombre mas corto")]
            public string Nombre { get; set; }

            [Required(ErrorMessage="Se requiere el apellido")]
            [StringLength(30, ErrorMessage = "Ingrese el apellido mas corto")]
            public string Apellido { get; set; }

            [Required(ErrorMessage="Se requiere numero de telefono")]
            [StringLength(13, ErrorMessage = "Ingrese un numero de telefono mas corto")]
            public string NumeroTelefono { get; set; }

            [Required(ErrorMessage="Se requiere numero de licencia")]
            [StringLength(20, ErrorMessage = "Ingrese un numero de licencia valido")]
            public string NumeroLicencia { get; set; }

            [Required(ErrorMessage="Se requiere email")]
            [StringLength(30, ErrorMessage = "Ingrese un email mas corto")]
            public string Email { get; set; }
        }

        public class TransportadorViewModel : TransportadorInputModel
        {
            public TransportadorViewModel(Transportador transportador)
            {
                Identificacion = transportador.Identificacion;
                Nombre = transportador.Nombre;
                Apellido = transportador.Apellido;
                NumeroTelefono = transportador.NumeroTelefono;
                NumeroLicencia = transportador.NumeroLicencia;
                Email = transportador.Email;
            }
        }
    }
}
