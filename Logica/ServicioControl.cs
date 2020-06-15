using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using Entity;

namespace Logica
{
    public class ServicioControl
    {
        private readonly SeynekunContext _context;

        public ServicioControl(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarControlResponse Guardar(Control control)
        {
            try
            {
                var controlBuscado = _context.Controles.Find(control.CodigoControl);
                if (controlBuscado != null)
                {
                    return new GuardarControlResponse("!Control ya registrado!");
                }
                control.CodigoControl = GenerarCodigoControl();
                _context.Controles.Add(control);
                _context.SaveChanges();
                return new GuardarControlResponse(control);
            }
            catch (Exception e)
            {
                return new GuardarControlResponse(e.Message);
            }
        }

        public ConsultarControlResponse Consultar()
        {
            var controles = _context.Controles.ToList();
            return new ConsultarControlResponse(controles);
        }

        public BuscarControlResponse Buscar(string codigo)
        {
            Control control = _context.Controles.Find(codigo);
            if (control != null)
            {
                return new BuscarControlResponse(control);
            }
            return new BuscarControlResponse("Control no encontrado");
        }

        private string GenerarCodigoControl()
        {
            try
            {
                string codigo = string.Empty;
                DateTime fecha = DateTime.Now;
                var masUno = 15 + Convert.ToDecimal(fecha.Second);
                string codigoTemp = Convert.ToString(fecha.Minute)+Convert.ToString(fecha.Month)+Convert.ToString(fecha.Year);
                string hora = Convert.ToString(masUno)+Convert.ToString(fecha.Hour)+Convert.ToString(fecha.Day);
                codigo = hora + codigoTemp;
                return codigo.ToString();
            }
            catch(Exception e){
                return e.Message;
            }
        }
    }

    public class GuardarControlResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Control Control { get; set; }

        public GuardarControlResponse(Control control)
        {
            Error = false;
            Control = control;
        }

        public GuardarControlResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarControlResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Control> Controles { get; set; }

        public ConsultarControlResponse(List<Control> controles)
        {
            Error = false;
            Controles = controles;
        }

        public ConsultarControlResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarControlResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Control Control { get; set; }

        public BuscarControlResponse(Control control)
        {
            Error = false;
            Control = control;
        }

        public BuscarControlResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
