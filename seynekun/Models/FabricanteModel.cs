using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Entity;

namespace seynekun.Models
{
    public class FabricanteInputModel
    {
        [Required(ErrorMessage = "El Tipo de Id es requerida")]
        [StringLength(20)]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "La Id es requerida")]
        [StringLength(20)]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(40, ErrorMessage="Dirección demasido larga, trate de simplificarla")]
        public string Direccion { get; set; }

        [StringLength(13, ErrorMessage="Ingrese un número de telefono válido")]
        [Range(0, 13, ErrorMessage = "Ingrese un número de telefono válido")]        
        public string NumeroTelefono { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un correo electrónico válido")]
        [EmailAddress(ErrorMessage="Ingrese un correo electrónico válido")]
        [StringLength(30, ErrorMessage="Correo demasiado largo")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "El fax es requerido")]
        [StringLength(20)]
        public string Fax { get; set; }

        [Required]
        [StringLength(20)]
        public string SitioWeb { get; set; }
    }

    public class FabricanteViewModel : FabricanteInputModel
    {
        public List<Insumo> Insumos { get; set; }
        public FabricanteViewModel(Fabricante fabricante)
        {
            TipoIdentificacion = fabricante.TipoIdentificacion;
            Identificacion = fabricante.Identificacion;
            Nombre = fabricante.Nombre;
            Direccion = fabricante.Direccion;
            NumeroTelefono = fabricante.NumeroTelefono;
            Email = fabricante.Email;
            Fax = fabricante.Fax;
            SitioWeb = fabricante.SitioWeb;
            Insumos = fabricante.Insumos;
        }
    }
}
