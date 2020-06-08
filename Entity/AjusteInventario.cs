using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    //"Server=tcp:seynekun.database.windows.net,1433;Initial Catalog=Seynekun;Persist Security Info=False;User ID=adminn;Password=Kevin.2!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    public class AjusteInventario
    {
        [Key]
        [Required(ErrorMessage = "Se requiere el código del ajuste")]
        public string CodigoAjuste { get; set; }
        
        [Required(ErrorMessage = "Se requiere un tipo de elemento")]
        public string TipoElemento { get; set; }

        [Required(ErrorMessage = "Se requiere el nombre del elemento")]
        public string NombreElemento { get; set; }

        [Required(ErrorMessage="Se requiere el código del elemento")]
        public string CodigoElemento { get; set; }
        
        [Required(ErrorMessage = "Se requiere la fecha del ajuste")]           
        [DataType(DataType.Date,ErrorMessage="Ingrese una fecha válida")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Se requiere el tipo de ajuste")]  
        public string TipoAjusteInventario { get; set; }

        public string Descipcion { get; set; }

        [Required(ErrorMessage = "Se requiere la cantidad a ajustar")]
        public decimal Cantidad { get; set; }
        
        [Required(ErrorMessage = "Se requiere una bodega")]
        public string NombreBodega { get; set; }
    }

    public class TipoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToLower() == "incremento") || (value.ToString().ToLower() == "disminucion"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}

