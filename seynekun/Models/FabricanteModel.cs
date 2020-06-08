using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Entity;

namespace seynekun.Models
{
    public class FabricanteInputModel 
    {
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public string NumeroTelefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Fax { get; set; }
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
