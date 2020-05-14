using Datos;
using System.Collections.Generic;
using System.Linq;
using Entity;
using System;

namespace Logica
{
    public class ServicioAjusteInventario
    {
        private readonly AjusteInventarioContext _context;
        private readonly ServicioProducto servicioProducto = new ServicioProducto("Server=localhost\\SQLEXPRESS; Database=Seynekun; Trusted_Connection = True; MultipleActiveResultSets = true");
        public ServicioAjusteInventario(AjusteInventarioContext context)
        {
            _context = context;
        }
        public GuardarAjusteInventarioResponse Guardar(AjusteInventario ajusteInventario)
        {
            try
            {
                var ajusteInventarioBuscado = _context.AjusteInventarios.Find(ajusteInventario.Codigo);
                if (ajusteInventarioBuscado != null)
                {
                    return new GuardarAjusteInventarioResponse("Imposible añadir este ajuste, código duplicado");
                }
                _context.AjusteInventarios.Add(ajusteInventario);
                _context.SaveChanges();
                return new GuardarAjusteInventarioResponse(ajusteInventario);
            }
            catch (Exception e)
            {
                return new GuardarAjusteInventarioResponse(e.Message);
            }
        }
        public List<AjusteInventario> Consultar()
        {
            List<AjusteInventario> ajusteInventarios = _context.AjusteInventarios.ToList();
            return ajusteInventarios;
        }
        public BuscarAjusteInventarioxIdResponse BuscarxId(decimal codigo)
        {
            var ajusteInventario = _context.AjusteInventarios.Find(codigo);
            if (ajusteInventario != null)
            {
                return new BuscarAjusteInventarioxIdResponse(ajusteInventario);
            }
            return new BuscarAjusteInventarioxIdResponse("Ajuste no encontrado");
        }
        public string Modificar(AjusteInventario ajusteInventarioNuevo)
        {
            try
            {
                var ajusteInventarioViejo = _context.AjusteInventarios.Find(ajusteInventarioNuevo.Codigo);
                if (ajusteInventarioViejo != null)
                {
                    ajusteInventarioViejo.Fecha = ajusteInventarioNuevo.Fecha;
                    ajusteInventarioViejo.Descipcion = ajusteInventarioNuevo.Descipcion;
                    ajusteInventarioViejo.Cantidad = ajusteInventarioNuevo.Cantidad;
                    ajusteInventarioViejo.CodigoElemento = ajusteInventarioNuevo.CodigoElemento;
                    ajusteInventarioViejo.Tipo = ajusteInventarioNuevo.Tipo;
                    ajusteInventarioViejo.NombreBodega = ajusteInventarioNuevo.NombreBodega;
                    _context.AjusteInventarios.Update(ajusteInventarioViejo);
                    _context.SaveChanges();
                    return ($"El Ajuste se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro del ajuste solicitado";
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        private List<AjusteInventario> ObtenerAjustesxProductoyBodega(string codigoElemento, string nombreBodega)
        {
            return _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento && a.NombreBodega == nombreBodega).ToList();
        }
        private List<AjusteInventario> ObtenerAjustesxProductoyMateria(string codigoElemento, decimal codigoMateria)
        {
            return _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento && a.CodigoMateriaPrima == codigoMateria).ToList();
        }
        private decimal CalcularCantidad(List<AjusteInventario> ajustes)
        {
            var sumaIncremento = ajustes.Where(a => a.Tipo == "Incremento").Sum(a => a.Cantidad);
            var sumaDisminucion = ajustes.Where(a => a.Tipo == "Disminucion").Sum(a => a.Cantidad);
            var cantidad = sumaIncremento - sumaDisminucion;
            if (0 > cantidad)
            {
                return 0;
            }
            return cantidad;
        }
        public List<ProductoStock> ObtenerProductosEnBodega(string nombreBodega)
        {
            List<AjusteInventario> ajustes = Consultar();
            List<ProductoStock> productoEnBodegas = new List<ProductoStock>();
            foreach (var ajuste in ajustes)
            {
                ProductoStock productoEnBodega = new ProductoStock();
                productoEnBodega.Producto = servicioProducto.BuscarxId(ajuste.CodigoElemento).Producto;
                productoEnBodega.Cantidad = CalcularCantidad(ObtenerAjustesxProductoyBodega(productoEnBodega.Producto.Codigo, nombreBodega));
                if (!esRepetido(productoEnBodegas, productoEnBodega.Producto.Codigo))
                {
                    productoEnBodegas.Add(productoEnBodega);
                }
            }
            return productoEnBodegas;
        }
        public List<ProductoStock> ObtenerProductosDeMateria(decimal codigoMateria)
        {
            List<AjusteInventario> ajustes = Consultar();
            List<ProductoStock> productoEnBodegas = new List<ProductoStock>();
            foreach (var ajuste in ajustes)
            {
                ProductoStock productoEnBodega = new ProductoStock();
                productoEnBodega.Producto = servicioProducto.BuscarxId(ajuste.CodigoElemento).Producto;
                productoEnBodega.Cantidad = CalcularCantidad(ObtenerAjustesxProductoyMateria(productoEnBodega.Producto.Codigo, codigoMateria));
                if (!esRepetido(productoEnBodegas, productoEnBodega.Producto.Codigo))
                {
                    productoEnBodegas.Add(productoEnBodega);
                }
            }
            return productoEnBodegas;
        }
        private bool esRepetido(List<ProductoStock> productosEnBodega, string codigo)
        {
            for (int i = 0; i < productosEnBodega.Count; i++)
            {
                if (productosEnBodega[i].Producto.Codigo == codigo) return true;
            }
            return false;
        }
        public string Eliminar(decimal codigo)
        {
            try
            {
                AjusteInventario ajusteInventario = _context.AjusteInventarios.Find(codigo);
                if (ajusteInventario != null)
                {
                    _context.AjusteInventarios.Remove(ajusteInventario);
                    _context.SaveChanges();
                    return $"El Ajuste de Inventario se ha eliminado.";
                }
                return "El Ajuste de Inventario no fue encontrado";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }
    public class ConsultarAjusteInventarioResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<AjusteInventario> AjusteInventarios;

        public ConsultarAjusteInventarioResponse(List<AjusteInventario> objetos)
        {
            Error = false;
            this.AjusteInventarios = objetos;

        }

        public ConsultarAjusteInventarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarAjusteInventarioResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public AjusteInventario AjusteInventario { get; set; }
        public GuardarAjusteInventarioResponse(AjusteInventario ajusteInventario)
        {
            Error = false;
            AjusteInventario = ajusteInventario;
        }
        public GuardarAjusteInventarioResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BuscarAjusteInventarioxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public AjusteInventario AjusteInventario;

        public BuscarAjusteInventarioxIdResponse(AjusteInventario ajusteInventario)
        {
            Error = false;
            this.AjusteInventario = ajusteInventario;
        }

        public BuscarAjusteInventarioxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}