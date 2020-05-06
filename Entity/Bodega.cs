using System.Collections.Generic;
namespace Entity
{
    public class Bodega
    {
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public decimal Valor { get; set; }
        public List<Producto> Productos { get; set; }
        public string Estado { get; set; }        
    }
}