using System;
using Entity;

namespace seynekun.Models
{
    public class MateriaPrimaModel
    {
        public class MateriaPrimaInputModel
        {
            public string Codigo { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Cantidad { get; set; }
            public string NombreProductor { get; set; }
            public string Tipo { get; set; }
            public string CodigoProductor { get; set; }
            public string EstadoMateria { get; set; }
        }

        public class MateriaPrimaViewModel : MateriaPrimaInputModel
        {
            public MateriaPrimaViewModel(MateriaPrima materiaPrima)
            {
                Codigo = materiaPrima.Codigo;
                Fecha = materiaPrima.Fecha;
                Cantidad = materiaPrima.Cantidad;
                CodigoProductor = materiaPrima.CodigoProductor;
                NombreProductor = materiaPrima.NombreProductor;
                EstadoMateria = materiaPrima.EstadoMateria;
                Tipo = materiaPrima.Tipo;
            }
        }
    }
}
