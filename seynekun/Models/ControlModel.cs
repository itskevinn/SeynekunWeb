using System.ComponentModel.DataAnnotations;
using Entity;
using System;

namespace seynekun.Models
{
    public class ControlModel
    {
        public class ControlInputModel
        {
            [StringLength(20, ErrorMessage = "Ingrese un codigo de control válido")]
            public string CodigoControl { get; set; }

            [Required(ErrorMessage = "Proporcione un tipo de control")]
            [StringLength(20, ErrorMessage = "Tipo de control invalido")]
            public string TipoControl { get; set; }

            [Required(ErrorMessage = "Proporcione un tipo de control")]
            [StringLength(256, ErrorMessage = "Tipo de control invalido")]
            public string Descripcion { get; set; }

            [Required(ErrorMessage = "Se requiere fecha de creacion del control")]
            public DateTime FechaInicio { get; set; }

            [Required(ErrorMessage = "Se requiere fecha final del control")]
            public DateTime FechaFinal { get; set; }

            [Required(ErrorMessage = "Proporcione una observacion")]
            [StringLength(256, ErrorMessage = "Observacion invalida")]
            public string Observacion { get; set; }
        }

        public class ControlViewModel : ControlInputModel
        {
            public ControlViewModel(Control control)
            {
                CodigoControl = control.CodigoControl;
                TipoControl = control.TipoControl;
                Descripcion = control.Descripcion;
                FechaInicio = control.FechaInicio;
                FechaFinal = control.FechaFinal;
                Observacion = control.Observacion;
            }
        }
    }
}
