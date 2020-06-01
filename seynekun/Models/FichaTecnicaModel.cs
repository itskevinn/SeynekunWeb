using System.ComponentModel.DataAnnotations;
using Entity;

namespace seynekun.Models
{
    public class FichaTecnicaInputModel
    {
        [StringLength(20)]
        public string Id { get; set; }

        [StringLength(20)]
        public string IdInsumo { get; set; }

        [Required]
        [StringLength(20)]
        public string Ingrediente { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoIngrediente { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroCas { get; set; }

        [StringLength(20)]
        public string Observacion { get; set; }

        [Required]
        [StringLength(20)]
        public string Ce { get; set; }

        [Required]
        [StringLength(20)]
        public string Nop { get; set; }

        [Required]
        [StringLength(20)]
        public string Jas { get; set; }

        [Required]
        [StringLength(20)]
        public string Etapa { get; set; }

        [Required]
        [StringLength(20)]
        public string Col { get; set; }
    }

    public class FichaTecnicaViewModel : FichaTecnicaInputModel
    {
        public FichaTecnicaViewModel(FichaTecnica fichaTecnica)
        {
            Id =  fichaTecnica.Id;
            IdInsumo = fichaTecnica.IdInsumo;
            Ingrediente = fichaTecnica.Ingrediente;
            TipoIngrediente = fichaTecnica.TipoIngrediente;
            NumeroCas = fichaTecnica.NumeroCas;
            Observacion = fichaTecnica.Observacion;
            Ce = fichaTecnica.Ce;
            Nop = fichaTecnica.Nop;
            Jas = fichaTecnica.Jas;
            Etapa = fichaTecnica.Etapa;
            Col = fichaTecnica.Col;
        }
    }
}
