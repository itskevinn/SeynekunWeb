using System;
using Entity;

namespace seynekun.Models
{
    public class MateriaPrimaModel
    {
        public class MateriaPrimaInputModel 
        {
            public decimal Codigo { get; set; }
            public DateTime Fecha { get; set; }            
            public decimal Cantidad { get; set; }
            public string CodigoProductor { get; set; }
            public string UnidadMedida { get; set; }
        }

        public class MateriaPrimaViewModel : MateriaPrimaInputModel
        {
            public MateriaPrimaViewModel(MateriaPrima materiaPrima)
            {
                //Codigo = materiaPrima.Codigo;
                Fecha = materiaPrima.Fecha;                
                Cantidad = materiaPrima.Cantidad;
                CodigoProductor = materiaPrima.CodigoProductor;                
                UnidadMedida = materiaPrima.UnidadMedida;                
            }
        }
    }
}
