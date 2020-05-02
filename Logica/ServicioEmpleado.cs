using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioEmpleado
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioEmpleado repositorioEmpleado;

        public ServicioEmpleado(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioEmpleado = new RepositorioEmpleado(_conexión);
        }

        public GuardarResponse Guardar(Empleado empleado)
        {
            try
            {
                _conexión.Abrir();
                repositorioEmpleado.Guardar(empleado);
                _conexión.Cerrar();
                return new GuardarResponse(empleado);
            }
            catch (Exception e)
            {
                return new GuardarResponse(e.Message);
            }
        }

        public ConsultarEmpleadoResponse Consultar()
        {
            try
            {
                _conexión.Abrir();
                List<Empleado> empleados = repositorioEmpleado.Consultar();
                _conexión.Cerrar();
                return new ConsultarEmpleadoResponse(empleados);
            }
            catch (Exception e)
            {
                return new ConsultarEmpleadoResponse(e.Message);
            }
        }
    }

    public class ConsultarEmpleadoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Empleado> objetos;

        public ConsultarEmpleadoResponse(List<Empleado> objetos)
        {
            Error = false;
            this.objetos = objetos;
            
        }

        public ConsultarEmpleadoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

}
