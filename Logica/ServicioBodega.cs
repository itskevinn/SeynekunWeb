using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioBodega
    {

        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioBodega repositorioBodega;

        public ServicioBodega(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioBodega = new RepositorioBodega(_conexión);
        }

        public GuardarBodegaResponse Guardar(Bodega bodega)
        {
            try
            {
                _conexión.Abrir();
                repositorioBodega.Guardar(bodega);
                _conexión.Cerrar();
                return new GuardarBodegaResponse(bodega);
            }
            catch (Exception e)
            {
                return new GuardarBodegaResponse(e.Message);
            }
        }

        public ConsultarBodegaResponse Consultar()
        {
            try
            {
                _conexión.Abrir();
                List<Bodega> bodegas = repositorioBodega.Consultar().FindAll(c => c.Estado.Equals("Activo") || c.Estado.Equals("Modificado")); ;
                _conexión.Cerrar();
                return new ConsultarBodegaResponse(bodegas);
            }
            catch (Exception e)
            {
                return new ConsultarBodegaResponse(e.Message);
            }
        }

        public BuscarBodegaxIdResponse BuscarxId(string codigo)
        {
            try
            {
                _conexión.Abrir();
                Bodega bodega = repositorioBodega.BuscarxId(codigo);
                _conexión.Cerrar();
                return new BuscarBodegaxIdResponse(bodega);
            }
            catch (Exception e)
            {
                return new BuscarBodegaxIdResponse(e.Message);
            }
        }

        public string Modificar(Bodega bodegaNuevo)
        {
            try
            {
                _conexión.Abrir();
                var bodegaViejo = repositorioBodega.BuscarxId(bodegaNuevo.Nombre);
                if (bodegaViejo != null)
                {
                    repositorioBodega.ModificarEstado(bodegaViejo.Nombre, "Modificado");
                    repositorioBodega.Modificar(bodegaNuevo);
                    _conexión.Cerrar();
                    return ($"El bodega {bodegaNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró bodega con el código ingresada";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexión.Cerrar(); }

        }
        public string Eliminar(string codigo)
        {
            try
            {
                _conexión.Abrir();
                Bodega bodega = repositorioBodega.BuscarxId(codigo);
                if (bodega != null)
                {
                    repositorioBodega.ModificarEstado(codigo, "Eliminado");
                    return $"El bodega {bodega.Nombre} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró bodega con el código ingresada";
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

        public ConsultarBodegaResponse(List<Bodega> bodegas)
        {
            Error = false;
            this.Bodegas = bodegas;
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