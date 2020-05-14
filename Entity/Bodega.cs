using System.Collections.Generic;
namespace Entity
{
    public class Bodega
    {
        public string Nombre { get; set; }
        public string Detalle { get; set; }                
        public string Estado { get; set; }        
        public string Direccion { get; set; }
        public List<AjusteInventario> Ajustes { get; set; } 
    }
}