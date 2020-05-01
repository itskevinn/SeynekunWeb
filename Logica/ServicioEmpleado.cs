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

        public GuardarEmpleadoResponse Guardar(Empleado empleado)
        {
            try
            {
                _conexión.Abrir();
                repositorioEmpleado.Guardar(empleado);
                _conexión.Cerrar();
                return new GuardarEmpleadoResponse(empleado);
            }
            catch (Exception e)
            {
                return new GuardarEmpleadoResponse(e.Message);
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
    public class GuardarEmpleadoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Empleado Empleado { get; set; }
        public GuardarEmpleadoResponse(Empleado empleado)
        {
            Error = false;
            Empleado = empleado;
        }
        public GuardarEmpleadoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

}

