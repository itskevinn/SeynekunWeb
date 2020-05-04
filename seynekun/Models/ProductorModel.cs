using Entity;
using System.ComponentModel.DataAnnotations;
namespace seynekun.Models
{
    public class ProductorInputModel : Persona
    {
        [StringLength(20, ErrorMessage="Cédula cafetera inválida")]
        [Required(ErrorMessage="La Cedula Cafetera es requerida")]
        public string CedulaCafetera { get; set; }
        [StringLength(30, ErrorMessage="Nombre del predio demasiado largo, trate de simplificarlo")]
        [Required(ErrorMessage="El nombre del predio es requerido")]
        public string NombrePredio { get; set; }
        [Required(ErrorMessage="El código de la finca es requerido")]
        [StringLength(15, ErrorMessage="Código de la Finca demasiado largo")]
        public string CodigoFinca { get; set; }
        [StringLength(15, ErrorMessage="Código SICA demasiado largo")]
        [Required(ErrorMessage="El código SICA es requerido")]
        public string CodigoSica { get; set; }
        [StringLength(20, ErrorMessage="Nombre de municipio demasiado largo")]
        [Required(ErrorMessage="El municipio es requerido")]
        public string Municipio { get; set; }
        [Required(ErrorMessage="La vereda es requerida")]
        [StringLength(20, ErrorMessage="Nombre de vereda demasiado largo")]
        public string Vereda { get; set; }
        [StringLength(30, ErrorMessage="Nombre de afiliación demasiado largo, trate de simplificarlo")]
        [Required(ErrorMessage="La afiliación de salud es requerida")]        
        public string AfiliacionSalud { get; set; }
          [Required(ErrorMessage = "El Estado es requerido")]
        [StringLength(13, ErrorMessage="Estado demasiado largo")]
        public string Estado { get; set; }
    }

    public class ProductorViewModel : ProductorInputModel
    {
        public ProductorViewModel(Productor productor)
        {
            Identificacion = productor.Identificacion;
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
            Estado = productor.Estado;
        }
    }
}
