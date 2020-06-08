using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioBodega
    {

         private readonly SeynekunContext _context;
        public ServicioBodega(SeynekunContext context)
        {
            _context = context;            
        }
        public GuardarBodegaResponse Guardar(Bodega bodega)
        {
            try
            {
                var bodegaBuscado = _context.Bodegas.Find(bodega.Nombre);
                if (bodegaBuscado != null)
                {
                    return new GuardarBodegaResponse("!Bodega ya registrada!");
                }
                _context.Bodegas.Add(bodega);
                _context.SaveChanges();
                return new GuardarBodegaResponse(bodega);
            }
            catch (Exception e)
            {
                return new GuardarBodegaResponse(e.Message);
            }
        }
        public List<Bodega> Consultar()
        {
            List<Bodega> bodegas = _context.Bodegas.ToList();
            return bodegas;
        }
        public BuscarBodegaxIdResponse BuscarxId(string nombre)
        {
            var bodega = _context.Bodegas.Find(nombre);
            if (bodega != null && bodega.Estado!="Eliminado")
            {
                return new BuscarBodegaxIdResponse(bodega);
            }
            return new BuscarBodegaxIdResponse("Bodega no encontrada");
        }
        public string Modificar(Bodega bodegaNueva)
        {
            try
            {
                var bodegaVieja = _context.Bodegas.Find(bodegaNueva.Nombre);
                if (bodegaVieja != null && bodegaVieja.Estado != "Eliminado")
                {
                    bodegaVieja.Nombre = bodegaNueva.Nombre;
                    bodegaVieja.Ajustes = bodegaNueva.Ajustes;
                    bodegaVieja.Detalle = bodegaNueva.Detalle;
                    bodegaVieja.Direccion = bodegaNueva.Direccion;
                    bodegaVieja.Estado = bodegaNueva.Estado;
                    _context.Bodegas.Update(bodegaVieja);
                    _context.SaveChanges();
                    return ($"La bodega se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro de la bodega solicitada";
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public string Eliminar(string nombre)
        {
            try
            {
                Bodega bodega = _context.Bodegas.Find(nombre);
                if (bodega != null)
                {
                    _context.Bodegas.Remove(bodega);
                    _context.SaveChanges();
                    return $"La bodega se ha eliminado.";
                }
                return "La bodega no fue encontrada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }
    public class ConsultarBodegaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Bodega> Bodegas;

        public ConsultarBodegaResponse(List<Bodega> objetos)
        {
            Error = false;
            this.Bodegas = objetos;

        }

        public ConsultarBodegaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarBodegaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Bodega Bodega { get; set; }
        public GuardarBodegaResponse(Bodega bodega)
        {
            Error = false;
            Bodega = bodega;
        }
        public GuardarBodegaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BuscarBodegaxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Bodega Bodega;

        public BuscarBodegaxIdResponse(Bodega bodega)
        {
            Error = false;
            this.Bodega = bodega;
        }

        public BuscarBodegaxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}