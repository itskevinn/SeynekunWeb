using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using Entity;

namespace Logica
{
    public class ServicioDetalleVenta
    {
        private readonly SeynekunContext _context;

        public ServicioDetalleVenta(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarDetalleResponse Guardar(DetalleVenta detalle)
        {
            try
            {
                var detalleBuscado = _context.DetallesVentas.Find(detalle.codigoDetalle);
                if (detalleBuscado != null)
                {
                    return new GuardarDetalleResponse("!Detalle de venta ya registrada!");
                }
                _context.DetallesVentas.Add(detalle);
                _context.SaveChanges();
                return new GuardarDetalleResponse(detalle);
            }
            catch (Exception e)
            {
                return new GuardarDetalleResponse(e.Message);
            }
        }

        public ConsultarDetalleResponse Consultar()
        {
            try
            {
                var detalles = _context.DetallesVentas.ToList();
                return new ConsultarDetalleResponse(detalles);
            }
            catch (Exception e)
            {
                return new ConsultarDetalleResponse(e.Message);
            }
        }

        public BuscarDetalleResponse Buscar(string codigo)
        {
            try
            {
                var detalle = _context.DetallesVentas.Find(codigo);
                if( detalle != null)
                {
                    return new BuscarDetalleResponse(detalle);
                }
                return new BuscarDetalleResponse("Detalle no encontrada");
            }
            catch (Exception e)
            {
                return new BuscarDetalleResponse(e.Message);
            }
        }
    }

    public class GuardarDetalleResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public DetalleVenta Detalle { get; set; }

        public GuardarDetalleResponse(DetalleVenta detalle)
        {
            Error = false;
            this.Detalle = detalle;
        }

        public GuardarDetalleResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarDetalleResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<DetalleVenta> Detalles { get; set; }

        public ConsultarDetalleResponse(List<DetalleVenta> detalles)
        {
            Error = false;
            this.Detalles = detalles;
        }

        public ConsultarDetalleResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarDetalleResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public DetalleVenta Detalle { get; set; }

        public BuscarDetalleResponse(DetalleVenta detalle)
        {
            Error = false;
            this.Detalle = detalle;
        }

        public BuscarDetalleResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
