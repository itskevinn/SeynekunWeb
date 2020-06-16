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
                var productoBuscado = _context.Productos.Find(producto.Codigo);
                if (productoBuscado == null)
                {
                    _context.Productos.Add(producto);
                    _context.SaveChanges();
                    return new GuardarProductoResponse(producto);
                }
                else
                {
                    return new GuardarProductoResponse("¡Producto ya registrado!");
                }
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
            return new BuscarProductoxIdResponse("Producto no encontradp");
        }


        private void RealizarAjuste(Producto producto, AjusteInventario ajuste)
        {
            if(ajuste.TipoAjuste == "Incremento" && producto.ContenidoNeto > ajuste.Cantidad)
            {
                producto.ContenidoNeto = producto.ContenidoNeto + ajuste.Cantidad;
            }else if(ajuste.TipoAjuste == "Disminucion" && producto.ContenidoNeto > ajuste.Cantidad){
                producto.ContenidoNeto = producto.ContenidoNeto - ajuste.Cantidad;
            }
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public string Modificar(Producto productoNueva)
        {
            try
            {
                var productoVieja = _context.Productos.Find(productoNueva.Codigo);
                if (productoVieja != null && productoVieja.Estado != "Eliminado")
                {
                    productoVieja.Nombre = productoNueva.Nombre;
                    productoVieja.ContenidoNeto = productoNueva.ContenidoNeto;
                    productoVieja.Estado = productoNueva.Estado;
                    productoVieja.Descripcion = productoNueva.Descripcion;
                    productoVieja.NombreCategoria = productoNueva.NombreCategoria;
                    productoVieja.UnidadMedida = productoNueva.UnidadMedida;
                    productoVieja.Precio = productoNueva.Precio;
                    _context.Productos.Update(productoVieja);
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

        public string GenerarCodigoProducto()
        {
            try
            {
                string codigo = string.Empty;
                DateTime fecha = DateTime.Now;
                var masUno = 21 + Convert.ToDecimal(fecha.Second);
                string codigoTemp = Convert.ToString(fecha.Minute)+Convert.ToString(fecha.Day)+Convert.ToString(fecha.Year);
                string hora = Convert.ToString(masUno)+Convert.ToString(fecha.Hour)+Convert.ToString(fecha.Month);
                codigo = hora + codigoTemp;
                return codigo.ToString();
            }
            catch(Exception e){
                return e.Message;
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