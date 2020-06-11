using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class DetalleVenta
    {
        [Key]
        [StringLength(20, ErrorMessage = "Ingrese un codigo de detalle de venta válido")]
        public string codigoDetalle { get; set; }

        [Required(ErrorMessage="Se requiere identificacion del cliente")]
        [StringLength(20, ErrorMessage = "Ingrese una identificacion de cliente válida")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Se necesita el código del producto")]
        [StringLength(30, ErrorMessage = "Código demasiado largo")]
        public Producto Producto { get; set; }

        [Required(ErrorMessage="Se requiere la cantidad el producto")]
        public decimal CantidadProducto { get; set; }

        [Required(ErrorMessage="Se requiere el total de detalle de venta")]
        public decimal TotalDetalle { get; set; }
    }
}
