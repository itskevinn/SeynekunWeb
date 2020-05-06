using System.Collections.Generic;
namespace Entity
{
    public class Categoria
    {
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }
        public List<Producto> Productos { get; set; }
    }
}