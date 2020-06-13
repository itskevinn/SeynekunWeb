using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Cliente : Persona
    {
        [StringLength(13, ErrorMessage = "Ingrese un número de telefono válido")]
        public string NumeroTelefono2 { get; set; }
        [StringLength(40, ErrorMessage = "Dirección demasido larga, trate de simplificarla")]
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        [StringLength(30, ErrorMessage = "Nombre del barrio demasiado largo, trate de simplificarlo")]
        public string Barrio { get; set; }
    }
}
