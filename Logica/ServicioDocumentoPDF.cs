using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura;
using Entity;

namespace Logica
{
    public class ServicioDocumentoPDF
    {
        DocumentoPDF documentoPDF;

        public ServicioDocumentoPDF()
        {
            documentoPDF = new DocumentoPDF();
        }

        public void CrearDocumentoPDF(List<Empleado> lista, string tipo)
        {
            documentoPDF.CrearDocumentoPDF(lista,tipo);
        }
    }
}
