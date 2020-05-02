using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RepositorioCliente
    {
        private readonly SqlConnection _conexión;

        public RepositorioCliente(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar(Cliente cliente)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Cliente (TipoId, Identificacion,Nombre,Apellido,NumeroTelefono,NumeroTelefono2,Email,Direccion,Barrio,Departamento,Municipio,Estado)
                    values (@TipoId,@Identificacion,@Nombre,@Apellido,@NumeroTelefono,@NumeroTelefono2,@Email,@Direccion,@Barrio,@Departamento,@Municipio,@Estado)";
                comando.Parameters.AddWithValue("@TipoId", cliente.TipoIdentificacion);
                comando.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@NumeroTelefono", cliente.NumeroTelefono);
                comando.Parameters.AddWithValue("@NumeroTelefono2", cliente.NumeroTelefono2);
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@Barrio", cliente.Barrio);
                comando.Parameters.AddWithValue("@Departamento", cliente.Departamento);
                comando.Parameters.AddWithValue("@Municipio", cliente.Municipio);
                comando.Parameters.AddWithValue("@Estado", cliente.Estado);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Cliente> Consultar()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Cliente";
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        clientes.Add(MapToCliente(datos));
                    }
                }
            }
            return clientes;
        }

        private Cliente MapToCliente(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Cliente cliente = new Cliente();
            cliente.TipoIdentificacion = (string)datos["TipoId"];
            cliente.Identificacion = (string)datos["Identificacion"];
            cliente.Nombre = (string)datos["Nombre"];
            cliente.Apellido = (string)datos["Apellido"];
            cliente.NumeroTelefono = (string)datos["NumeroTelefono"];
            cliente.NumeroTelefono2 = (string)datos["NumeroTelefono2"];
            cliente.Email = (string)datos["Email"];
            cliente.Direccion = (string)datos["Direccion"];
            cliente.Barrio = (string)datos["Barrio"];
            cliente.Departamento = (string)datos["Departamento"];
            cliente.Municipio = (string)datos["Municipio"];
            cliente.Estado = (string)datos["Estado"];
            return cliente;
        }
        public Cliente BuscarxId(string identificacion)
        {
            Cliente cliente = new Cliente();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Cliente where Identificacion=@Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                var datos = comando.ExecuteReader();
                datos.Read();
                return MapToCliente(datos);
            }
        }

        public void Modificar(Cliente clienteNuevo)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Cliente set Direccion = @Direccion, Barrio=@Barrio,Departamento=@Departamento,Municipio=@Municipio, Nombre = @Nombre, Apellido = @Apellido, Estado = @Estado, NumeroTelefono2 = @NumeroTelefono2, NumeroTelefono = @NumeroTelefono, Email = @Email where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue("@TipoId", clienteNuevo.TipoIdentificacion);
                comando.Parameters.AddWithValue("@Nombre", clienteNuevo.Nombre);
                comando.Parameters.AddWithValue("@Apellido", clienteNuevo.Apellido);
                comando.Parameters.AddWithValue("@NumeroTelefono", clienteNuevo.NumeroTelefono);
                comando.Parameters.AddWithValue("@NumeroTelefono2", clienteNuevo.NumeroTelefono2);
                comando.Parameters.AddWithValue("@Email", clienteNuevo.Email);
                comando.Parameters.AddWithValue("@Direccion", clienteNuevo.Direccion);
                comando.Parameters.AddWithValue("@Barrio", clienteNuevo.Barrio);
                comando.Parameters.AddWithValue("@Departamento", clienteNuevo.Departamento);
                comando.Parameters.AddWithValue("@Municipio", clienteNuevo.Municipio);
                comando.Parameters.AddWithValue("@Estado", clienteNuevo.Estado);
                comando.Parameters.AddWithValue("@Identificacion", clienteNuevo.Identificacion);
                comando.ExecuteNonQuery();
            }
        }
        public void ModificarEstado(string identificacion, string estado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Cliente set Estado = @Estado where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.ExecuteNonQuery();
            }
        }

    }
}