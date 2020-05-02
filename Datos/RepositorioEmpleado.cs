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
                    values (@Cedula,@Nombre,@Apellido,@NumeroTelefono,@Email,@Estado,@Cargo)";
                comando.Parameters.AddWithValue("@Cedula", empleado.Cedula);
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
                if(datos.HasRows)
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
            if(!datos.HasRows) return null;
            Empleado empleado = new Empleado();
            empleado.Cedula = (string) datos["Cedula"];
            empleado.Nombre = (string) datos["Nombre"];
            empleado.Apellido = (string) datos["Apellido"];
            empleado.NumeroTelefono = (string) datos["NumeroTelefono"];
            empleado.Email = (string) datos["Email"];
            empleado.Estado = (string) datos["Estado"];
            empleado.Cargo = (string) datos["Cargo"];
            return empleado;
        }
    }
}