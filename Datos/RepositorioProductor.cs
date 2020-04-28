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

        public List<Productor> Consultar()
        {
            List<Productor> productores = new List<Productor>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Productores";
                var datos = comando.ExecuteReader();
                if(datos.HasRows)
                {
                    while (datos.Read())
                    {
                        productores.Add(MapToProductor(datos));
                    }
                }
            }
            return productores;
        }

public Productor BuscarxId(string identificacion)
        {            
            SqlDataReader datos;
            Productor productor = new Productor();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Productores where Cedula=@Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                datos = comando.ExecuteReader();
                datos.Read();
                return MapToProductor(datos);

            }
            return productor;
        }
        public void Modificar(Productor productorAntiguo, Productor productorNuevo){
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Productores set Cedula = @Cedula, Nombre = @Nombre, Apellido = @Apellido, CedulaCafetera = @CedulaCafetera, NombrePredio = @NombrePredio, CodigoFinca = @CodigoFinca, CodigoSica = @CodigoSica, Municipio = @Municipio, Vereda = @Vereda , NumeroTelefono = @NumeroTelefono, AfiliacionSalud = @AfiliacionSalud where Cedula = @CedulaAntigua";
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
                comando.Parameters.AddWithValue("@CedulaAntigua", productorAntiguo.Cedula);
                comando.ExecuteNonQuery();                                
            }
        }

        private Productor MapToProductor(SqlDataReader datos)
        {
            if(!datos.HasRows) return null;
            Productor productor = new Productor();
            productor.Cedula = (string) datos["Cedula"];
            productor.Nombre = (string) datos["Nombre"];
            productor.Apellido = (string) datos["Apellido"];
            productor.CedulaCafetera = (string) datos["CedulaCafetera"];
            productor.NombrePredio = (string) datos["NombrePredio"];
            productor.CodigoFinca = (string) datos["CodigoFinca"];
            productor.CodigoSica = (string) datos["CodigoSica"];
            productor.Municipio = (string) datos["Municipio"];
            productor.Vereda = (string) datos["Vereda"];
            productor.NumeroTelefono = (string) datos["NumeroTelefono"];
            productor.AfiliacionSalud = (string) datos["AfiliacionSalud"];
            return productor;
        }
    }
}
