﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Productor : Persona
    {

        [StringLength(30, ErrorMessage = "Cédula cafetera inválida")]
        [Required(ErrorMessage = "La Cedula Cafetera es requerida")]
        public string CedulaCafetera { get; set; }

        [StringLength(30, ErrorMessage = "Nombre del predio demasiado largo, trate de simplificarlo")]
        [Required(ErrorMessage = "El nombre del predio es requerido")]
        public string NombrePredio { get; set; }

        [Required(ErrorMessage = "El código de la finca es requerido")]
        [StringLength(30, ErrorMessage = "Código de la Finca demasiado largo")]
        public string CodigoFinca { get; set; }

        [StringLength(30, ErrorMessage = "Código SICA demasiado largo")]
        [Required(ErrorMessage = "El código SICA es requerido")]
        public string CodigoSica { get; set; }

        [StringLength(20, ErrorMessage = "Nombre de municipio demasiado largo")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "La vereda es requerida")]
        [StringLength(30, ErrorMessage = "Nombre de vereda demasiado largo")]
        public string Vereda { get; set; }

        [StringLength(40, ErrorMessage = "Nombre de afiliación demasiado largo, trate de simplificarlo")]
        public string AfiliacionSalud { get; set; }
        [Required(ErrorMessage = "Nombre de usuario requerido")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Se requiere una contraseña")]
        [MinLength(4, ErrorMessage = "Se requiere una contraseña de mínino 4 dígitos")]
        public string Contrasena { get; set; }
    }
}
