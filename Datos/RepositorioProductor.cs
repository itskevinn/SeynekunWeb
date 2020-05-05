using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos {
    public class RepositorioProductor {

        private readonly SqlConnection _conexión;

        public RepositorioProductor (GestionadorDeConexión conexión) {
            _conexión = conexión._conexion;
        }

        public void Guardar (Productor productor) {
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = @"Insert Into Productores (TipoIdentificacion,Identificacion,Nombre,Apellido,NumeroTelefono,CedulaCafetera,NombrePredio,CodigoFinca,CodigoSica,Municipio,Vereda,AfiliacionSalud,NombreUsuario,Contrasena,Estado)
                    values (@TipoIdentificacion,@Identificacion,@Nombre,@Apellido,@NumeroTelefono,@CedulaCafetera,@NombrePredio,@CodigoFinca,@CodigoSica,@Municipio,@Vereda,@AfiliacionSalud,@NombreUsuario,@Contrasena,@Estado)";
                comando.Parameters.AddWithValue ("@TipoIdentificacion", productor.TipoIdentificacion);
                comando.Parameters.AddWithValue ("@Identificacion", productor.Identificacion);
                comando.Parameters.AddWithValue ("@Nombre", productor.Nombre);
                comando.Parameters.AddWithValue ("@Apellido", productor.Apellido);
                comando.Parameters.AddWithValue ("@NumeroTelefono", productor.NumeroTelefono);
                comando.Parameters.AddWithValue ("@CedulaCafetera", productor.CedulaCafetera);
                comando.Parameters.AddWithValue ("@NombrePredio", productor.NombrePredio);
                comando.Parameters.AddWithValue ("@CodigoFinca", productor.CodigoFinca);
                comando.Parameters.AddWithValue ("@CodigoSica", productor.CodigoSica);
                comando.Parameters.AddWithValue ("@Municipio", productor.Municipio);
                comando.Parameters.AddWithValue ("@Vereda", productor.Vereda);
                comando.Parameters.AddWithValue ("@AfiliacionSalud", productor.AfiliacionSalud);
                comando.Parameters.AddWithValue ("@NombreUsuario", productor.NombreUsuario);
                comando.Parameters.AddWithValue ("@Contrasena", productor.Contrasena);
                comando.Parameters.AddWithValue ("@Estado", productor.Estado);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Productor> Consultar () {
            List<Productor> productores = new List<Productor>();
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Select * from Productores";
                var datos = comando.ExecuteReader();
                if (datos.HasRows) {
                    while (datos.Read()) {
                        productores.Add(MapToProductor(datos));
                    }
                }
            }
            return productores;
        }

        public Productor BuscarxId (string identificacion) {
            Productor productor;
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Select * from Productores where Identificacion=@Identificacion";
                comando.Parameters.AddWithValue ("@Identificacion", identificacion);
                var datos = comando.ExecuteReader ();
                if(datos.Read()){
                    return productor = MapToProductor(datos);
                }
            }
            return null;
        }

        public void Modificar (Productor productorNuevo) {
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Update Productores set Nombre = @Nombre, Apellido = @Apellido, NumeroTelefono = @NumeroTelefono, CedulaCafetera = @CedulaCafetera, NombrePredio = @NombrePredio, CodigoFinca = @CodigoFinca, CodigoSica = @CodigoSica, Municipio = @Municipio, Vereda = @Vereda , AfiliacionSalud = @AfiliacionSalud where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue ("@Identificacion", productorNuevo.Identificacion);
                comando.Parameters.AddWithValue ("@Nombre", productorNuevo.Nombre);
                comando.Parameters.AddWithValue ("@Apellido", productorNuevo.Apellido);
                comando.Parameters.AddWithValue ("@NumeroTelefono", productorNuevo.NumeroTelefono);
                comando.Parameters.AddWithValue ("@CedulaCafetera", productorNuevo.CedulaCafetera);
                comando.Parameters.AddWithValue ("@NombrePredio", productorNuevo.NombrePredio);
                comando.Parameters.AddWithValue ("@CodigoFinca", productorNuevo.CodigoFinca);
                comando.Parameters.AddWithValue ("@CodigoSica", productorNuevo.CodigoSica);
                comando.Parameters.AddWithValue ("@Municipio", productorNuevo.Municipio);
                comando.Parameters.AddWithValue ("@Vereda", productorNuevo.Vereda);
                comando.Parameters.AddWithValue ("@AfiliacionSalud", productorNuevo.AfiliacionSalud);
                comando.ExecuteNonQuery();
            }
        }
        
        public void ModificarEstado (string identificacion, string estado) {
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Update Productores set Estado = @Estado where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue ("@Identificacion", identificacion);
                comando.Parameters.AddWithValue ("@Estado", estado);
                comando.ExecuteNonQuery ();
            }
        }

        private Productor MapToProductor (SqlDataReader datos) {
            if (!datos.HasRows) return null;
            Productor productor = new Productor ();
            productor.TipoIdentificacion = (string) datos["TipoIdentificacion"];
            productor.Identificacion = (string) datos["Identificacion"];
            productor.Nombre = (string) datos["Nombre"];
            productor.Apellido = (string) datos["Apellido"];
            productor.NumeroTelefono = (string) datos["NumeroTelefono"];
            productor.CedulaCafetera = (string) datos["CedulaCafetera"];
            productor.NombrePredio = (string) datos["NombrePredio"];
            productor.CodigoFinca = (string) datos["CodigoFinca"];
            productor.CodigoSica = (string) datos["CodigoSica"];
            productor.Municipio = (string) datos["Municipio"];
            productor.Vereda = (string) datos["Vereda"];
            productor.AfiliacionSalud = (string) datos["AfiliacionSalud"];
            productor.NombreUsuario = (string) datos["NombreUsuario"];
            productor.Contrasena = (string) datos["Contrasena"];
            productor.Estado = (string) datos["Estado"];
            return productor;
        }
    }
}
