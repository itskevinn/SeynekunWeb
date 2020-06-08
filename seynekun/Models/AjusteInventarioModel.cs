using System;
using Entity;
using System.ComponentModel.DataAnnotations;

namespace seynekun.Models
{
    public class AjusteInventarioModel
    {
        public class AjusteInventarioInputModel
        {
<<<<<<< HEAD
         public string Codigo { get; set; }   
         public DateTime Fecha { get; set; }
         public string Descipcion { get; set; }
         public decimal Cantidad { get; set; }
         public string CodigoElemento { get; set; }
         public string Tipo { get; set; }
         public string CodigoMateriaPrima { get; set; }
         public string NombreBodega { get; set; }
=======
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
>>>>>>> 7ded797877973524ffa5f2dc915dc9abbf6404c0
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
                TipoAjusteInventario = ajusteInventario.TipoAjusteInventario;
                Descipcion = ajusteInventario.Descipcion;
                Cantidad = ajusteInventario.Cantidad;
                NombreBodega = ajusteInventario.NombreBodega;
            }
        }
    }
}
