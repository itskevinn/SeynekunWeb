using System;
using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models
{
    public class AjusteInventarioModel
    {
        public class AjusteInventarioInputModel
        {
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
            public string TipoAjuste { get; set; }
            public string Descripcion { get; set; }

            [Required(ErrorMessage = "Se requiere la cantidad a ajustar")]
            public decimal Cantidad { get; set; }

            [Required(ErrorMessage = "Se requiere una bodega")]
            public string NombreBodega { get; set; }
        }

        public class AjusteInventarioViewModel : AjusteInventarioInputModel
        {
            public AjusteInventarioViewModel(AjusteInventario ajusteInventario)
            {
                CodigoAjuste = ajusteInventario.CodigoAjuste;
                TipoElemento = ajusteInventario.TipoElemento;
                NombreElemento = ajusteInventario.NombreElemento;
                CodigoElemento = ajusteInventario.CodigoElemento;
                Fecha = ajusteInventario.Fecha;
                TipoAjuste = ajusteInventario.TipoAjuste;
                Descripcion = ajusteInventario.Descripcion;
                Cantidad = ajusteInventario.Cantidad;
                NombreBodega = ajusteInventario.NombreBodega;
            }
        }
    }
}
