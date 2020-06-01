using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioProducto
    {

        private readonly SeynekunContext _context;
        public ServicioProducto(SeynekunContext context)
        {
            _context = context;
        }
        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                var productoBuscado = _context.Productos.Find(producto.Nombre);
                if (productoBuscado != null)
                {
                    return new GuardarProductoResponse("Dos productos no pueden tener el mismo nombre");
                }
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse(e.Message);
            }
        }
        public List<Producto> Consultar()
        {
            List<Producto> productos = _context.Productos.ToList();
            return productos;
        }
        public BuscarProductoxIdResponse BuscarxId(string nombre)
        {
            var producto = _context.Productos.Find(nombre);
            if (producto != null && producto.Estado != "Eliminado")
            {
                return new BuscarProductoxIdResponse(producto);
            }
            return new BuscarProductoxIdResponse("producto no encontrada");
        }
        public string Modificar(Producto productoNueva)
        {
            try
            {
                var productoVieja = _context.Productos.Find(productoNueva.Codigo);
                if (productoVieja != null && productoVieja.Estado != "Eliminado")
                {
                    productoVieja.Nombre = productoNueva.Nombre;
                    productoVieja.Cantidad = productoNueva.Cantidad;
                    productoVieja.Estado = productoNueva.Estado;
                    productoVieja.Descripcion = productoNueva.Descripcion;
                    productoVieja.NombreCategoria = productoNueva.NombreCategoria;
                    productoVieja.UnidadMedida = productoNueva.UnidadMedida;
                    productoVieja.Precio = productoNueva.Precio;
                    _context.Productos.Update(productoNueva);
                    _context.SaveChanges();
                    return ($"El producto se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro del producto solicitada";
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
                Producto producto = _context.Productos.Find(nombre);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    return $"El producto se ha eliminado.";
                }
                return "El producto no fue encontrado";
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
        public List<Producto> Productos;

        public ConsultarProductoResponse(List<Producto> objetos)
        {
            Error = false;
            this.Productos = objetos;

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