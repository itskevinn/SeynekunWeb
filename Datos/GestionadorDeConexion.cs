using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Datos {
    public class GestionadorDeConexión {
        internal SqlConnection _conexion;
        public GestionadorDeConexión (string cadenaDeConexión) {
            _conexion = new SqlConnection (cadenaDeConexión);
        }
        public void Abrir ( ) {
            _conexion.Open ( );
        }
        public void Cerrar ( ) {
            _conexion.Close ( );
        }
    }
}