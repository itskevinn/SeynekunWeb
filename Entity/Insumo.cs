using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entity
{
    public class Insumo
    {
        [Key]
        [Required(ErrorMessage = "Proporcione el código del insumo")]
        [StringLength(30, ErrorMessage = "Código de referencia del insumo demasiado largo")]
        public string Id { get; set; }

        [StringLength(40, ErrorMessage = "Id de Fabricante demasiado largo")]
        public string IdFabricante { get; set; }

        [Required(ErrorMessage = "Proporcione el nombre del insumo")]
        [StringLength(35, ErrorMessage = "Nombre demasiado largo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Proporcione el uso de este insumo")]
        [StringLength(100, ErrorMessage = "Uso demasiado largo, trate de simplificarlo")]
        public string Uso { get; set; }

        [Required(ErrorMessage = "Proporcione el registro ICA de este insumo")]
        [StringLength(35, ErrorMessage = "Código ICA demasiado largo")]
        public string RegistroIca { get; set; }

        [StringLength(200, ErrorMessage = "Descripción demasiado larga, trate de simplificarla")]
        public string Descripcion { get; set; }

        [StringLength(100, ErrorMessage = "Resultado demasiado largo, trate de simplificarlo")]
        public string Resultado { get; set; }

        [Required(ErrorMessage = "Proporcione un estado")]
        [StringLength(13, ErrorMessage = "Estado inválido")]
        public string Estado { get; set; }
        public List<Documento> Documentos { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
    }
}
