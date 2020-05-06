namespace seynekun.Models
{
    public class CategoriaModel
    {
        public class CategoriaInputModel : Persona
    {        
        [Required(ErrorMessage="Proporcione un nombre")]
        [StringLength(20, ErrorMessage="Nombre demasiado largo")]                
        public string Nombre { get; set; }                          
        [StringLength(200, ErrorMessage="Detalle demasiado largo")]                
        public string Detalle { get; set; }
    }

    public class CategoriaViewModel : CategoriaInputModel
    {
        public CategoriaViewModel(Categoria categoria)
        {
            Nombre = categoria.Nombre;
            Detalle = categoria.Detalle;
        }
    }
    }
}