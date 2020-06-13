using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class MateriaPrima
    {
        [Key]
        [Required(ErrorMessage = "Se requiere un código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Se requiere la fecha de ingreso")]
        public DateTime Fecha { get; set; }
        public string UnidadMedida { get; set; }
        [Required(ErrorMessage="Se requiere el tipo de materia prima que ingresó")]
        public string Tipo { get; set; }
        public string NombreProductor { get; set; }
        [Required(ErrorMessage = "Se requiere el código del productor")]
        public string CodigoProductor { get; set; }
        [Required(ErrorMessage = "Se requiere la cantidad ingresada de materia prima")]
        public decimal Cantidad { get; set; }
        public string EstadoMateria { get; set; }
    }
}
