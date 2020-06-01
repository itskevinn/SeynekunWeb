using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RepositorioFabricante
    {
        /*
        private readonly SqlConnection _conexión;

        public RepositorioFabricante(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar (Fabricante fabricante)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Fabricantes (TipoIdentificacion,Identificacion,Nombre,Apellido,NumeroTelefono,Email,Direccion,Fax,SitioWeb,Estado)
                    values (@TipoIdentificacion,@Identificacion,@Nombre,@Apellido,@NumeroTelefono,@Email,@Direccion,@Fax,@SitioWeb,@Estado)";
                comando.Parameters.AddWithValue ("@TipoIdentificacion", fabricante.TipoIdentificacion);
                comando.Parameters.AddWithValue ("@Identificacion", fabricante.Identificacion);
                comando.Parameters.AddWithValue ("@Nombre", fabricante.Nombre);
                comando.Parameters.AddWithValue ("@Apellido", fabricante.Apellido);
                comando.Parameters.AddWithValue ("@NumeroTelefono", fabricante.NumeroTelefono);
                comando.Parameters.AddWithValue ("@Email", fabricante.Email);
                comando.Parameters.AddWithValue ("@Direccion", fabricante.Direccion);
                comando.Parameters.AddWithValue ("@Fax", fabricante.Fax);
                comando.Parameters.AddWithValue ("@SitioWeb", fabricante.SitioWeb);
                comando.Parameters.AddWithValue ("@Estado", fabricante.Estado);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Fabricante> Consultar ()
        {
            List<Fabricante> fabricantes = new List<Fabricante>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Fabricantes";
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        fabricantes.Add(MapToFabricante(datos));
                    }
                }
            }
            return fabricantes;
        }

        public Fabricante BuscarxId (string identificacion)
        {
            Fabricante fabricante;
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Fabricantes where Identificacion=@Identificacion";
                comando.Parameters.AddWithValue ("@Identificacion", identificacion);
                var datos = comando.ExecuteReader ();
                if(datos.Read())
                {
                    return fabricante = MapToFabricante(datos);
                }
            }
            return null;
        }

        public void Modificar (Fabricante fabricanteNuevo)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Update Fabricantes set TipoIdentificacion = @TipoIdentificacion, Nombre = @Nombre, Apellido = @Apellido, NumeroTelefono = @NumeroTelefono, Email = @Email, Direccion = @Direccion, Fax = @Fax, SitioWeb = @SitioWeb where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue ("@TipoIdentificacion", fabricanteNuevo.TipoIdentificacion);
                comando.Parameters.AddWithValue ("@Identificacion", fabricanteNuevo.Identificacion);
                comando.Parameters.AddWithValue ("@Nombre", fabricanteNuevo.Nombre);
                comando.Parameters.AddWithValue ("@Apellido", fabricanteNuevo.Apellido);
                comando.Parameters.AddWithValue ("@NumeroTelefono", fabricanteNuevo.NumeroTelefono);
                comando.Parameters.AddWithValue ("@Email", fabricanteNuevo.Email);
                comando.Parameters.AddWithValue ("@Direccion", fabricanteNuevo.Direccion);
                comando.Parameters.AddWithValue ("@Fax", fabricanteNuevo.Fax);
                comando.Parameters.AddWithValue ("@SitioWeb", fabricanteNuevo.SitioWeb);
                comando.ExecuteNonQuery();
            }
        }

        public void ModificarEstado (string identificacion, string estado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Update Fabricantes set Estado = @Estado where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue ("@Identificacion", identificacion);
                comando.Parameters.AddWithValue ("@Estado", estado);
                comando.ExecuteNonQuery ();
            }
        }

        private Fabricante MapToFabricante (SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Fabricante fabricante = new Fabricante();
            fabricante.TipoIdentificacion = (string) datos["TipoIdentificacion"];
            fabricante.Identificacion = (string) datos["Identificacion"];
            fabricante.Nombre = (string) datos["Nombre"];
            fabricante.Apellido = (string) datos["Apellido"];
            fabricante.NumeroTelefono = (string) datos["NumeroTelefono"];
            fabricante.Email = (string) datos["Email"];
            fabricante.Direccion = (string) datos["Direccion"];
            fabricante.Fax = (string) datos["Fax"];
            fabricante.SitioWeb = (string) datos["SitioWeb"];
            fabricante.Estado = (string) datos["Estado"];
            return fabricante;
        }
        */
    }
}
