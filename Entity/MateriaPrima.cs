using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class MateriaPrima
    {
        [Key]
        [Required(ErrorMessage="Se requiere un código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage="Se requiere la fecha de ingreso")]
        public DateTime Fecha { get; set; }
        [StringLength(20,ErrorMessage="Unidad inválida")]
        [Required(ErrorMessage="Se requiere una unidad de medida")]
        public string UnidadMedida { get; set; }
        [Required(ErrorMessage="Se requiere el código del producto")]
        public string CodigoProductor { get; set; }
        [Required(ErrorMessage="Se requiere la cantidad del producto")]
        public decimal Cantidad { get; set; }        
    }
}
