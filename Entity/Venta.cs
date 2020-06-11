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

        [Required(ErrorMessage="Se requiere código de detalle de venta 2")]
        public List<DetalleVenta> DetallesVentas { get; set; }

        [Required(ErrorMessage="Se requiere identificacion del cliente")]
        public string ClienteId { get; set; }

        [Required(ErrorMessage="Se requiere la fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage="Se requiere observacion")]
        [StringLength(256, ErrorMessage = "Ingrese una observacion válida")]
        public string Observacion { get; set; }

        [Required(ErrorMessage="Se requiere el total de la venta")]
        public decimal TotalVenta { get; set; }
    }
}
