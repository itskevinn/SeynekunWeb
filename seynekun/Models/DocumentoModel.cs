using System.ComponentModel.DataAnnotations;
using Entity;

namespace seynekun.Models
{
    public class DocumentoInputModel
    {
        [Required(ErrorMessage = "La id es requerida")]
        [StringLength(20)]
        public string Id { get; set; }

        [Required(ErrorMessage = "La id del insumo es requerida")]
        [StringLength(20)]
        public string IdInsumo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El enlace del documento es requerido")]
        [StringLength(20)]
        public string Enlace { get; set; }
        public string Descripcion { get; set; }
    }

    public class DocumentoViewModel : DocumentoInputModel
    {
        public DocumentoViewModel(Documento documento)
        {
            Id = documento.Id;
            IdInsumo = documento.IdInsumo;
            Nombre = documento.Nombre;
            Enlace = documento.Enlace;
            Descripcion = documento.Descripcion;
        }
    }
}
