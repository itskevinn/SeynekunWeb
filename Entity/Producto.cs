using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Producto
    {
        [Key]
        [Required(ErrorMessage = "Se necesita el código del producto")]
        [StringLength(30, ErrorMessage = "Código demasiado largo")]
        public string Codigo { get; set; }
        
        [Required(ErrorMessage = "Se requiere el nombre del producto")]
        [StringLength(30, ErrorMessage = "Nombre demasiado largo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Proporcione un precio para el producto")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El Estado es requerido")]
        [StringLength(13, ErrorMessage = "Estado demasido largo")]
        public string Estado { get; set; }
        [StringLength(100, ErrorMessage = "Descripción demasiado larga")]
        public string Descripcion { get; set; }

        [StringLength(17, ErrorMessage = "Nombre de categoría inválido")]
        public string NombreCategoria { get; set; }

        [Required(ErrorMessage = "Se requiere la cantidad del producto")]
        public decimal Cantidad { get; set; }
        [Required(ErrorMessage = "Se requiere la unidad de medida del producto")]
        [StringLength(13, ErrorMessage = "Unidad inválida")]
        public string UnidadMedida { get; set; }
    }
}