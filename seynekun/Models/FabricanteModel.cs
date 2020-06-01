using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models
{
    public class FabricanteInputModel : Fabricante
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public string NumeroTelefono { get; set; }
        public string Email { get; set; }
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
