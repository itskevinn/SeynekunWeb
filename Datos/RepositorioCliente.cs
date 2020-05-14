using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos {
    public class RepositorioCliente {

        private readonly SqlConnection _conexión;

        public RepositorioCliente(GestionadorDeConexión conexión) {
            _conexión = conexión._conexion;
        }

        public void Guardar(Cliente cliente) {
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = @"Insert Into Clientes (TipoIdentificacion, Identificacion,Nombre,Apellido,NumeroTelefono,NumeroTelefono2,Email,Direccion,Barrio,Departamento,Municipio,Estado)
                    values (@TipoIdentificacion,@Identificacion,@Nombre,@Apellido,@NumeroTelefono,@NumeroTelefono2,@Email,@Direccion,@Barrio,@Departamento,@Municipio,@Estado)";
                comando.Parameters.AddWithValue("@TipoIdentificacion", cliente.TipoIdentificacion);
                comando.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@NumeroTelefono", cliente.NumeroTelefono);
                comando.Parameters.AddWithValue("@NumeroTelefono2", cliente.NumeroTelefono2);
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@Departamento", cliente.Departamento);
                comando.Parameters.AddWithValue("@Municipio", cliente.Municipio);
                comando.Parameters.AddWithValue("@Barrio", cliente.Barrio);
                comando.Parameters.AddWithValue("@Estado", cliente.Estado);
                var filas = comando.ExecuteNonQuery();
            }
        }
        
        public List<Cliente> Consultar() {
            List<Cliente> clientes = new List<Cliente>();
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Select * from Clientes";
                var datos = comando.ExecuteReader();
                if (datos.HasRows) {
                    while (datos.Read()) {
                        clientes.Add(MapToCliente(datos));
                    }
                }
            }
            return clientes;
        }

        public Cliente BuscarxId(string identificacion) {
            Cliente cliente;
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Select * from Clientes where Identificacion=@Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                var datos = comando.ExecuteReader();
                if(datos.Read()) {
                    return cliente = MapToCliente(datos);
                }
            }
            return null;
        }

        public void Modificar(Cliente clienteNuevo) {
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Update Clientes set TipoIdentificacion = @TipoIdentificacion, Nombre = @Nombre, Apellido = @Apellido, NumeroTelefono = @NumeroTelefono, NumeroTelefono2 = @NumeroTelefono2, Email = @Email, Direccion = @Direccion, Departamento=@Departamento, Municipio=@Municipio, Barrio=@Barrio where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue("@TipoIdentificacion", clienteNuevo.TipoIdentificacion);
                comando.Parameters.AddWithValue("@Identificacion", clienteNuevo.Identificacion);
                comando.Parameters.AddWithValue("@Nombre", clienteNuevo.Nombre);
                comando.Parameters.AddWithValue("@Apellido", clienteNuevo.Apellido);
                comando.Parameters.AddWithValue("@NumeroTelefono", clienteNuevo.NumeroTelefono);
                comando.Parameters.AddWithValue("@NumeroTelefono2", clienteNuevo.NumeroTelefono2);
                comando.Parameters.AddWithValue("@Email", clienteNuevo.Email);
                comando.Parameters.AddWithValue("@Direccion", clienteNuevo.Direccion);
                comando.Parameters.AddWithValue("@Departamento", clienteNuevo.Departamento);
                comando.Parameters.AddWithValue("@Municipio", clienteNuevo.Municipio);
                comando.Parameters.AddWithValue("@Barrio", clienteNuevo.Barrio);
                comando.ExecuteNonQuery();
            }
        }

        public void ModificarEstado(string identificacion, string estado) {
            using (var comando = _conexión.CreateCommand()) {
                comando.CommandText = "Update Clientes set Estado = @Estado where Identificacion = @Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.ExecuteNonQuery();
            }
        }

        private Cliente MapToCliente(SqlDataReader datos) {
            if (!datos.HasRows) return null;
            Cliente cliente = new Cliente();
            cliente.TipoIdentificacion = (string) datos["TipoIdentificacion"];
            cliente.Identificacion = (string) datos["Identificacion"];
            cliente.Nombre = (string) datos["Nombre"];
            cliente.Apellido = (string) datos["Apellido"];
            cliente.NumeroTelefono = (string) datos["NumeroTelefono"];
            cliente.NumeroTelefono2 = (string) datos["NumeroTelefono2"];
            cliente.Email = (string) datos["Email"];
            cliente.Direccion = (string) datos["Direccion"];
            cliente.Departamento = (string) datos["Departamento"];
            cliente.Municipio = (string) datos["Municipio"];
            cliente.Barrio = (string) datos["Barrio"];
            cliente.Estado = (string) datos["Estado"];
            return cliente;
        }
    }
}
