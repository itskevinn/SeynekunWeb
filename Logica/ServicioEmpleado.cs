using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioEmpleado
    {
        private readonly SeynekunContext _context;
        public ServicioEmpleado(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarEmpleadoResponse Guardar(Empleado empleado)
        {
            try
            {
                var empleadoBuscado = _context.Empleados.Find(empleado.Identificacion);
                if(empleadoBuscado != null)
                {
                    return new GuardarEmpleadoResponse("Id de empleado ya registrada");
                }
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
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
                List<Empleado> empleados = _context.Empleados.ToList();
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
                Empleado empleado = _context.Empleados.Find(identificacion);
                if(empleado == null)
                {
                    return new BuscarxIdResponse("Empleado no registrado");
                }
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
                var empleadoViejo = _context.Empleados.Find(empleadoNuevo.Identificacion);
                if (empleadoViejo != null)
                {
                    empleadoViejo.TipoIdentificacion = empleadoNuevo.TipoIdentificacion;
                    empleadoViejo.Nombre = empleadoNuevo.Nombre;
                    empleadoViejo.Apellido = empleadoNuevo.Nombre;
                    empleadoViejo.NumeroTelefono = empleadoNuevo.NumeroTelefono;
                    empleadoViejo.Email = empleadoNuevo.Email;
                    empleadoViejo.Cargo = empleadoNuevo.Cargo;
                    empleadoViejo.Estado = "Modificado";
                    _context.Empleados.Update(empleadoViejo);
                    _context.SaveChanges();
                    return ($"El empleado {empleadoNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                return "No se encontró empleado con la cédula ingresada";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                Empleado empleado = _context.Empleados.Find(identificacion);
                if (empleado != null)
                {
                    _context.Empleados.Remove(empleado);
                    _context.SaveChanges();
                    return $"El empleado {empleado.Nombre} {empleado.Apellido} se ha eliminado.";
                }
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
        public List<Empleado> Empleados;

        public ConsultarEmpleadoResponse(List<Empleado> empleados)
        {
            Error = false;
            this.Empleados = empleados;
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
