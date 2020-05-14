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
                List<Empleado> empleados = repositorioEmpleado.Consultar().FindAll(e => e.Estado.Equals("Activo") || e.Estado.Equals("Modificado"));;
                _conexión.Cerrar();
                return new ConsultarEmpleadoResponse(empleados);
            }
            catch (Exception e)
            {
                return new ConsultarEmpleadoResponse(e.Message);
            }
        }

        public BuscarxIdResponse BuscarxId(string identificacion)
        {
            try
            {
                _conexión.Abrir();
                Empleado empleado = repositorioEmpleado.BuscarxId(identificacion);
                _conexión.Cerrar();
                return new BuscarxIdResponse(empleado);
            }
            catch (Exception e)
            {
                return new BuscarxIdResponse(e.Message);
            }
        }

        public string Modificar(Empleado empleadoNuevo)
        {
            try
            {
                _conexión.Abrir();
                var empleadoViejo = repositorioEmpleado.BuscarxId(empleadoNuevo.Identificacion);
                if (empleadoViejo != null)
                {
                    repositorioEmpleado.ModificarEstado(empleadoViejo.Identificacion, "Modificado");
                    repositorioEmpleado.Modificar(empleadoNuevo);
                    _conexión.Cerrar();
                    return ($"El empleado {empleadoNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró empleado con la cédula ingresada";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexión.Cerrar(); }

        }
        public string Eliminar(string identificacion)
        {
            try
            {
                _conexión.Abrir();
                Empleado empleado = repositorioEmpleado.BuscarxId(identificacion);
                if (empleado != null)
                {
                    repositorioEmpleado.ModificarEstado(identificacion, "Eliminado");
                    return $"El empleado {empleado.Nombre} {empleado.Apellido} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró empleado con la cédula ingresada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
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
    public class BuscarxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Empleado Empleado;

        public BuscarxIdResponse(Empleado empleado)
        {
            Error = false;
            this.Empleado = empleado;
        }

        public BuscarxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

}

