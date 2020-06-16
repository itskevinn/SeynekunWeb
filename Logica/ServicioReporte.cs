using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioReporte
    {  
        private readonly SeynekunContext _context;
        public ServicioReporte(SeynekunContext context)
        {
            _context = context;
        }

        public string GenerarReporte(string tipoReporte)
        {
            try
            {
                if(tipoReporte == "Reporte de empleados")
                {
                    List<Empleado> lista = _context.Empleados.ToList();
                    GenetrarDocumento(lista, tipoReporte);
                }
                return tipoReporte;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        private void GenetrarDocumento(List<Empleado> lista, string tipo){
            ServicioDocumentoPDF  servicioDocumentoPDF = new ServicioDocumentoPDF();
            servicioDocumentoPDF.CrearDocumentoPDF(lista, tipo);
        }
    }
}