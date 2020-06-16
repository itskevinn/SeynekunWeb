using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class DetalleVenta
    {
        [Key]
        [Required(ErrorMessage="Ingrese un código para el detalle de venta")]
        [StringLength(20, ErrorMessage = "Ingrese un codigo de detalle de venta válido")]
        public string codigoDetalle { get; set; }

        [Required(ErrorMessage = "Se necesita el código de venta")]
        public string CodigoVenta { get; set; }

        [Required(ErrorMessage = "Se necesita el código del producto")]
        public string CodigoProducto { get; set; }

        [Required(ErrorMessage="Se requiere la cantidad el producto")]
        public decimal CantidadProducto { get; set; }

        [Required(ErrorMessage="Se requiere el total de detalle de venta")]
        public decimal TotalDetalle { get; set; }

        [Required(ErrorMessage="Se requiere el nombre de la bodega")]
        public string NombreBodega { get; set; }
    }
}
