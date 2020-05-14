using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RepositorioEmpleado
    {
        private readonly SqlConnection _conexión;

        public RepositorioEmpleado(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar(Empleado empleado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Empleados (Cedula,Nombre,Apellido,NumeroTelefono,Email,Estado,Cargo)
                    values (@Identificacion,@Nombre,@Apellido,@NumeroTelefono,@Email,@Estado,@Cargo)";
                comando.Parameters.AddWithValue("@Identificacion", empleado.Identificacion);
                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                comando.Parameters.AddWithValue("@NumeroTelefono", empleado.NumeroTelefono);
                comando.Parameters.AddWithValue("@Email", empleado.Email);
                comando.Parameters.AddWithValue("@Estado", empleado.Estado);
                comando.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Empleado> Consultar()
        {
            List<Empleado> empleados = new List<Empleado>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Empleados";
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        empleados.Add(MapToEmpleado(datos));
                    }
                }
            }
            return empleados;
        }

        private Empleado MapToEmpleado(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Empleado empleado = new Empleado();
            empleado.Identificacion = (string)datos["Cedula"];
            empleado.Nombre = (string)datos["Nombre"];
            empleado.Apellido = (string)datos["Apellido"];
            empleado.NumeroTelefono = (string)datos["NumeroTelefono"];
            empleado.Email = (string)datos["Email"];
            empleado.Estado = (string)datos["Estado"];
            empleado.Cargo = (string)datos["Cargo"];
            return empleado;
        }
        public Empleado BuscarxId(string identificacion)
        {
            Empleado empleado = new Empleado();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Empleados where Cedula=@Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                var datos = comando.ExecuteReader();
                datos.Read();
                return MapToEmpleado(datos);
            }
        }

        public void Modificar(Empleado empleadoNuevo)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Empleados set Nombre = @Nombre, Apellido = @Apellido, Estado = @Estado,  NumeroTelefono = @NumeroTelefono, Email = @Email, Cargo = @Cargo where Cedula = @Identificacion";
                comando.Parameters.AddWithValue("@Cedula", empleadoNuevo.Identificacion);
                comando.Parameters.AddWithValue("@Nombre", empleadoNuevo.Nombre);
                comando.Parameters.AddWithValue("@Apellido", empleadoNuevo.Apellido);
                comando.Parameters.AddWithValue("@Estado", empleadoNuevo.Estado);
                comando.Parameters.AddWithValue("@NumeroTelefono", empleadoNuevo.NumeroTelefono);
                comando.Parameters.AddWithValue("@Email", empleadoNuevo.Email);
                comando.Parameters.AddWithValue("@Cargo", empleadoNuevo.Cargo); 
                comando.ExecuteNonQuery();
            }
        }
        public void ModificarEstado(string identificacion, string estado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Empleados set Estado = @Estado where Cedula = @Identificacion";
                comando.Parameters.AddWithValue("@Identificacion", identificacion);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.ExecuteNonQuery();
            }
        }

    }
}