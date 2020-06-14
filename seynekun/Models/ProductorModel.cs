using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models
{
    public class ProductorInputModel
    {
        public string Estado { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public string CedulaCafetera { get; set; }
        public string NombrePredio { get; set; }
        public string CodigoFinca { get; set; }
        public string CodigoSica { get; set; }
        public string Municipio { get; set; }
        public string Vereda { get; set; }
        public string AfiliacionSalud { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }

    public class ProductorViewModel : ProductorInputModel
    {
        public ProductorViewModel(Productor productor)
        {
            TipoIdentificacion = productor.TipoIdentificacion;
            Identificacion = productor.Identificacion;
            Nombre = productor.Nombre;
            Apellido = productor.Apellido;
            NumeroTelefono = productor.NumeroTelefono;
            CedulaCafetera = productor.CedulaCafetera;
            NombrePredio = productor.NombrePredio;
            CodigoFinca = productor.CodigoFinca;
            CodigoSica = productor.CodigoSica;
            Municipio = productor.Municipio;
            Vereda = productor.Vereda;
            AfiliacionSalud = productor.AfiliacionSalud;
            NombreUsuario = productor.NombreUsuario;
            Contrasena = productor.Contrasena;
            Estado = productor.Estado;
        }
    }
}
