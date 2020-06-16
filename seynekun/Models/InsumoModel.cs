using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Entity;

namespace seynekun.Models
{
    public class InsumoInputModel
    {
        [Required(ErrorMessage = "El código de referencia del insumo es requerido")]
        [StringLength(20)]
        public string Id { get; set; }
        [Required(ErrorMessage = "La id del fabricante es requerida")]
        [StringLength(20)]
        public string IdFabricante { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El uso es requerido")]
        [StringLength(20)]
        public string Uso { get; set; }

        [Required(ErrorMessage = "Registro ICA es requerido")]
        [StringLength(20)]
        public string RegistroIca { get; set; }

        [StringLength(20)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El resultado es requerido")]
        [StringLength(20)]
        public string Resultado { get; set; }

        public List<Documento> Documentos { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
    }

    public class InsumoViewModel : InsumoInputModel
    {
        public InsumoViewModel(Insumo insumo)
        {
            Id = insumo.Id;
            Nombre = insumo.Nombre;
            Uso = insumo.Uso;
            RegistroIca = insumo.RegistroIca;
            Descripcion = insumo.Descripcion;
            Resultado = insumo.Resultado;
            Documentos = insumo.Documentos;
            FichaTecnica = insumo.FichaTecnica;
        }
    }
}
