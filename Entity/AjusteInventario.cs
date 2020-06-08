using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class AjusteInventario
    {
        [Key]
        [Required(ErrorMessage = "Se requiere el código del ajuste")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha del ajuste")]           
        [DataType(DataType.Date,ErrorMessage="Ingrese una fecha válida")]
        public DateTime Fecha { get; set; }
        public string Descipcion { get; set; }
        [Required(ErrorMessage = "Se requiere la cantidad a ajustar")]
        public decimal Cantidad { get; set; }
        [Required(ErrorMessage ="Se requiere el código del elemento al que va a inventariar")]
        public string CodigoElemento { get; set; }
        
        [Required(ErrorMessage = "Se requiere un tipo")]
        [TipoValidacion(ErrorMessage = "Ingrese un tipo válido")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Se requiere el código de la materia prima")]
        public string CodigoMateriaPrima { get; set; }
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

