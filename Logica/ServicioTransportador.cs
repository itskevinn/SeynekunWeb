using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioTransportador
    {
        private readonly SeynekunContext _context;
        public ServicioTransportador(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarTransportadorResponse Guardar(Transportador transportador)
        {
            try
            {
                var transportadorBuscado = _context.Transportadores.Find(transportador.Identificacion);
                if (transportadorBuscado == null)
                {
                    _context.Transportadores.Add(transportador);
                    _context.SaveChanges();
                    return new GuardarTransportadorResponse(transportador);
                }
                return new GuardarTransportadorResponse("!Transportador ya registrado!");
            }
            catch (Exception e)
            {
                return new GuardarTransportadorResponse(e.Message);
            }
        }

        public ConsultarTransportadorResponse Consultar()
        {
            try
            {
                var transportadores = _context.Transportadores.ToList();
                return new ConsultarTransportadorResponse(transportadores);
            }
            catch (Exception e)
            {
                return new ConsultarTransportadorResponse(e.Message);
            }
        }

        public BuscarTransportadorResponse Buscar(string codigo)
        {
            try
            {
                var transportador = _context.Transportadores.Find(codigo);
                if (transportador != null)
                {
                    return new BuscarTransportadorResponse(transportador);
                }
                return new BuscarTransportadorResponse("Transportador no encontrado");
            }
            catch (Exception e)
            {
                return new BuscarTransportadorResponse(e.Message);
            }
        }
    }

    public class GuardarTransportadorResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Transportador Transportador { get; set; }
        public GuardarTransportadorResponse(Transportador transportador)
        {
            Error = false;
            Transportador = transportador;
        }
        public GuardarTransportadorResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarTransportadorResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Transportador> Transportadores { get; set; }

        public ConsultarTransportadorResponse(List<Transportador> transportadores)
        {
            Error = false;
            Transportadores = transportadores;

        }

        public ConsultarTransportadorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    
    public class BuscarTransportadorResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Transportador Transportador { get; set; }

        public BuscarTransportadorResponse(Transportador transportador)
        {
            Error = false;
            Transportador = transportador;
        }

        public BuscarTransportadorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
