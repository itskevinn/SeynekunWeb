using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Venta
    {
        [Key]
        [StringLength(20, ErrorMessage = "Ingrese un codigo de venta valido")]
        public string CodigoVenta { get; set; }

        [Required(ErrorMessage="Se requiere código de detalle de venta")]
        [StringLength(20, ErrorMessage = "Ingrese un codigo de detalle de venta válido")]
        public List<DetalleVenta> DetallesVentas { get; set; }

        [Required(ErrorMessage="Se requiere identificacion del cliente")]
        [StringLength(20, ErrorMessage = "Ingrese una identificacion válida")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage="Se requiere la fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage="Se requiere observacion")]
        [StringLength(256, ErrorMessage = "Ingrese una observacion válida")]
        public string Observacion { get; set; }

        [Required(ErrorMessage="Se requiere el total de la venta")]
        public decimal TotalVenta { get; set; }
    }
}
