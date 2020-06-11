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
         public string TipoElemento { get; set; }
         public string CodigoElemento { get; set; }
         public string TipoAjuste { get; set; }
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
                TipoAjuste = ajusteInventario.TipoAjuste;
                TipoElemento = ajusteInventario.TipoElemento;
                NombreBodega = ajusteInventario.NombreBodega;
            }
        }   
    }
}