using Entity;
using Datos;
using System.Collections.Generic;
using System;

namespace Logica
{
    public class ServicioProducto
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioProducto repositorioProducto;

        public ServicioProducto(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioProducto = new RepositorioProducto(_conexión);
        }

        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                _conexión.Abrir();
                repositorioProducto.Guardar(producto);
                _conexión.Cerrar();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse(e.Message);
            }
        }

        public ConsultarProductoResponse Consultar()
        {
            try
            {
                _conexión.Abrir();
                List<Producto> productos = repositorioProducto.Consultar().FindAll(c => c.Estado.Equals("Activo") || c.Estado.Equals("Modificado"));
                _conexión.Cerrar();
                return new ConsultarProductoResponse(productos);
            }
            catch (Exception e)
            {
                return new ConsultarProductoResponse(e.Message);
            }
        }

        public BuscarProductoxIdResponse BuscarxId(string codigo)
        {
            try
            {
                _conexión.Abrir();
                Producto producto = repositorioProducto.BuscarxId(codigo);
                _conexión.Cerrar();
                return new BuscarProductoxIdResponse(producto);
            }
            catch (Exception e)
            {
                return new BuscarProductoxIdResponse(e.Message);
            }
        }

        public string Modificar(Producto productoNuevo)
        {
            try
            {
                _conexión.Abrir();
                var productoViejo = repositorioProducto.BuscarxId(productoNuevo.Codigo);
                if (productoViejo != null)
                {
                    repositorioProducto.ModificarEstado(productoViejo.Codigo, "Modificado");
                    repositorioProducto.Modificar(productoNuevo);
                    _conexión.Cerrar();
                    return ($"El producto {productoNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró producto con el código ingresada";
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
                Producto producto = repositorioProducto.BuscarxId(codigo);
                if (producto != null)
                {
                    repositorioProducto.ModificarEstado(codigo, "Eliminado");
                    return $"El producto {producto.Nombre} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró producto con el código ingresada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }

    }

    public class ConsultarProductoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Producto> objetos;

        public ConsultarProductoResponse(List<Producto> objetos)
        {
            Error = false;
            this.objetos = objetos;

        }

        public ConsultarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarProductoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto Producto { get; set; }
        public GuardarProductoResponse(Producto producto)
        {
            Error = false;
            Producto = producto;
        }
        public GuardarProductoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BuscarProductoxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto Producto;

        public BuscarProductoxIdResponse(Producto producto)
        {
            Error = false;
            this.Producto = producto;
        }

        public BuscarProductoxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }    
}