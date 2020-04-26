using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RepositorioProductor
    {
        private readonly SqlConnection _conexión;
        private readonly List<Productor> productores;
        public RepositorioProductor(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar(Productor productor)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Productores (Cedula,Nombre,Apellido,CedulaCafetera,NombrePredio,CodigoFinca,CodigoSica,Municipio,Vereda,NumeroTelefono,AfiliacionSalud)
                    values (@Cedula,@Nombre,@Apellido,@CedulaCafetera,@NombrePredio,@CodigoFinca,@CodigoSica,@Municipio,@Vereda,@NumeroTelefono,@AfiliacionSalud)";
                comando.Parameters.AddWithValue("@Cedula", productor.Cedula);
                comando.Parameters.AddWithValue("@Nombre", productor.Nombre);
                comando.Parameters.AddWithValue("@Apellido", productor.Apellido);
                comando.Parameters.AddWithValue("@CedulaCafetera", productor.CedulaCafetera);
                comando.Parameters.AddWithValue("@NombrePredio", productor.NombrePredio);
                comando.Parameters.AddWithValue("@CodigoFinca", productor.CodigoFinca);
                comando.Parameters.AddWithValue("@CodigoSica", productor.CodigoSica);
                comando.Parameters.AddWithValue("@Municipio", productor.Municipio);
                comando.Parameters.AddWithValue("@Vereda", productor.Vereda);
                comando.Parameters.AddWithValue("@NumeroTelefono", productor.NumeroTelefono);
                comando.Parameters.AddWithValue("@AfiliacionSalud", productor.AfiliacionSalud);
                var filas = comando.ExecuteNonQuery();
            }
        }

    }
}
