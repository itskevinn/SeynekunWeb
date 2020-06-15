using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
namespace Logica
{
    public class ServicioProduccion
    {
        private readonly SeynekunContext _context;
        public ServicioProduccion(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarProduccionResponse Guardar(Produccion produccion)
        {
            try
            {
                Produccion produccionBuscada = _context.Producciones.Find(produccion.CodigoProduccion);

                if (produccionBuscada == null)
                {
                    _context.Producciones.Add(produccion);
                    GuardarAjustes(produccion.Ajustes);
                    _context.SaveChanges();
                    return new GuardarProduccionResponse(produccion);

                }
                return new GuardarProduccionResponse("Codigo de produccion ya registrado");
            }
            catch (Exception e)
            {
                return new GuardarProduccionResponse(e.Message);
            }
        }
        private void GuardarAjustes(List<AjusteInventario> ajustes)
        {
            ServicioAjusteInventario servico = new ServicioAjusteInventario(_context);
            ServicioMateriaPrima servicioMateria = new ServicioMateriaPrima(_context);
            foreach (var item in ajustes)
            {
                servico.Guardar(item);
                servicioMateria.ModificarCantidad(item.CodigoMateriaPrima, item.CantidadMateriaPrima);
            }
        }

        public ConsultarProduccionResponse Consultar()
        {
            try
            {
                var producciones = _context.Producciones.ToList();
                return new ConsultarProduccionResponse(producciones);
            }
            catch (Exception e)
            {
                return new ConsultarProduccionResponse(e.Message);
            }
        }

        public BuscarProduccionResponse Buscar(string codigo)
        {
            try
            {
                Produccion produccion = _context.Producciones.Find(codigo);
                if (produccion != null)
                {
                    return new BuscarProduccionResponse(produccion);
                }
                return new BuscarProduccionResponse("Produccion no encontrada");
            }
            catch (Exception e)
            {
                return new BuscarProduccionResponse(e.Message);
            }
        }

        public string GenerarCodigoProduccion()
        {
            try
            {
                string codigo = string.Empty;
                DateTime fecha = DateTime.Now;
                var masUno = 6 + Convert.ToDecimal(fecha.Second);
                string codigoTemp = Convert.ToString(fecha.Minute) + Convert.ToString(fecha.Month) + Convert.ToString(fecha.Year);
                string hora = Convert.ToString(masUno) + Convert.ToString(fecha.Hour) + Convert.ToString(fecha.Day);
                codigo = hora + codigoTemp;
                return codigo.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    public class GuardarProduccionResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Produccion Produccion { get; set; }
        public GuardarProduccionResponse(Produccion produccion)
        {
            Error = false;
            Produccion = produccion;
        }
        public GuardarProduccionResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarProduccionResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Produccion> Producciones { get; set; }

        public ConsultarProduccionResponse(List<Produccion> producciones)
        {
            Error = false;
            Producciones = producciones;

        }

        public ConsultarProduccionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarProduccionResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Produccion Produccion { get; set; }

        public BuscarProduccionResponse(Produccion produccion)
        {
            Error = false;
            Produccion = produccion;
        }

        public BuscarProduccionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
