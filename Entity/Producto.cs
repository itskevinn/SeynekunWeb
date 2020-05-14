using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Producto
    {        
        [Key]
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string NombreCategoria { get; set; }        
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
    }
}