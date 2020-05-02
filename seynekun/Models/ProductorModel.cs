using Entity;

namespace seynekun.Models
{
    public class ProductorInputModel : Persona
    {
        public string CedulaCafetera { get; set; }
        public string NombrePredio { get; set; }
        public string CodigoFinca { get; set; }
        public string CodigoSica { get; set; }
        public string Municipio { get; set; }
        public string Vereda { get; set; }
        public string AfiliacionSalud { get; set; }
    }

    public class ProductorViewModel : ProductorInputModel
    {
        public ProductorViewModel(Productor productor)
        {
            Cedula = productor.Cedula;
            Nombre = productor.Nombre;
            Apellido = productor.Apellido;
            CedulaCafetera = productor.CedulaCafetera;
            NombrePredio = productor.NombrePredio;
            CodigoFinca = productor.CodigoFinca;
            CodigoSica = productor.CodigoSica;
            Municipio = productor.Municipio;
            Vereda = productor.Vereda;
            NumeroTelefono = productor.NumeroTelefono;
            AfiliacionSalud = productor.AfiliacionSalud;
        }
    }
}
