using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using Entity;

namespace Logica
{
    public class ServicioVenta
    {
        private readonly SeynekunContext _context;

        public ServicioVenta(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarVentaResponse Guardar(Venta venta)
        {
            try
            {
                var ventaBuscada = _context.Ventas.Find(venta.CodigoVenta);
                if (ventaBuscada != null)
                {
                    return new GuardarVentaResponse("!Venta ya registrada!");
                }
                _context.Ventas.Add(venta);
                foreach (var item in venta.DetallesVentas)
                {
                    _context.DetallesVentas.Add(item);
                }
                 GuardarAjustes(venta);
                _context.SaveChanges();
                return new GuardarVentaResponse(venta);
            }
            catch (Exception e)
            {
                return new GuardarVentaResponse(e.Message);
            }
        }

        private void GuardarAjustes(Venta venta)
        {
            AjusteInventario ajuste;
            int cont = 0;
            ServicioAjusteInventario servicio = new ServicioAjusteInventario(_context);
            foreach (var item in venta.DetallesVentas)
            {
                ajuste= new AjusteInventario();
                cont++;
                ajuste.Codigo = Convert.ToString(cont) + venta.CodigoVenta;
                ajuste.CodigoMateriaPrima = item.CodigoProducto;
                ajuste.Fecha = venta.Fecha;
                ajuste.Descipcion = venta.Observacion;
                ajuste.Cantidad = item.CantidadProducto;
                ajuste.CodigoElemento = item.CodigoProducto;
                ajuste.TipoAjuste = "Disminucion";
                ajuste.NombreBodega = item.NombreBodega;
                ajuste.TipoElemento = "Producto";
                servicio.Guardar(ajuste);
            }
        }

        public ConsultarVentaResponse Consultar()
        {
            try
            {
                var ventas = _context.Ventas.ToList();
                return new ConsultarVentaResponse(ventas);
            }
            catch (Exception e)
            {
                return new ConsultarVentaResponse(e.Message);
            }
        }

        public BuscarVentaResponse Buscar(string codigo)
        {
            try
            {
                var venta = _context.Ventas.Find(codigo);
                if( venta != null)
                {
                    return new BuscarVentaResponse(venta);
                }
                return new BuscarVentaResponse("Venta no encontrada");
            }
            catch (Exception e)
            {
                return new BuscarVentaResponse(e.Message);
            }
        }
    }

    public class GuardarVentaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Venta Venta { get; set; }

        public GuardarVentaResponse(Venta venta)
        {
            Error = false;
            this.Venta = venta;
        }

        public GuardarVentaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarVentaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Venta> Ventas { get; set; }

        public ConsultarVentaResponse(List<Venta> ventas)
        {
            Error = false;
            this.Ventas = ventas;
        }

        public ConsultarVentaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarVentaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Venta Venta { get; set; }

        public BuscarVentaResponse(Venta venta)
        {
            Error = false;
            this.Venta = venta;
        }

        public BuscarVentaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
