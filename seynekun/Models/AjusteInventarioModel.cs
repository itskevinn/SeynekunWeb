using System;
using Entity;
namespace seynekun.Models
{
    public class AjusteInventarioModel
    {
        public class AjusteInventarioInputModel
        {
         public string Codigo { get; set; }   
         public DateTime Fecha { get; set; }
         public string Descipcion { get; set; }
         public decimal Cantidad { get; set; }
         public string CodigoElemento { get; set; }
         public string Tipo { get; set; }
         public string CodigoMateriaPrima { get; set; }
         public string NombreBodega { get; set; }
        }

        public class AjusteInventarioViewModel : AjusteInventarioInputModel
        {
            public AjusteInventarioViewModel(AjusteInventario ajusteInventario)
            {
                Codigo = ajusteInventario.Codigo;
                Fecha = ajusteInventario.Fecha;
                Descipcion = ajusteInventario.Descipcion;
                Cantidad = ajusteInventario.Cantidad;
                CodigoMateriaPrima = ajusteInventario.CodigoMateriaPrima;
                CodigoElemento = ajusteInventario.CodigoElemento;
                Tipo = ajusteInventario.Tipo;
                NombreBodega = ajusteInventario.NombreBodega;
            }
        }   
    }
}