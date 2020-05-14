using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models
{
    public class FabricanteInputModel
    {
        [Required(ErrorMessage = "El Tipo de Identificación es requerido")]
        public string TipoIdentificacion { get; set; }

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [StringLength(13, ErrorMessage="Ingrese un número de telefono válido")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un número de telefono válido")]        
        public string NumeroTelefono { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo válido")]
        [EmailAddress(ErrorMessage="Ingrese un correo electrónico válido")]
        [StringLength(30, ErrorMessage="Correo demasiado largo")] 
        public string Email { get; set; }

        [StringLength(40, ErrorMessage="Dirección demasido larga, trate de simplificarla")]
        public string Direccion { get; set; }

        public string Fax { get; set; }
        public string SitioWeb { get; set; }
    }

    public class FabricanteViewModel : FabricanteInputModel
    {
        public string Estado { get; set; }

        public FabricanteViewModel(Fabricante fabricante) {
            TipoIdentificacion = fabricante.TipoIdentificacion;
            Identificacion = fabricante.Identificacion;
            Nombre = fabricante.Nombre;
            Apellido = fabricante.Apellido;
            NumeroTelefono = fabricante.NumeroTelefono;
            Email = fabricante.Email;
            Direccion = fabricante.Direccion;
            Fax = fabricante.Fax;
            SitioWeb = fabricante.SitioWeb;
            Estado = fabricante.Estado;
        }
    }
}
