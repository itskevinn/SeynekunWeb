using Datos;
using System.Collections.Generic;
using System.Linq;
using Entity;
using System;

namespace Logica
{
    public class ServicioStock
    {
        private readonly SeynekunContext _context;
        public ServicioStock(SeynekunContext context)
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
        public ProductoStock ObtenerProductoStockEnBodega(string codigoElemento, string nombreBodega)
        {
            ProductoStock producto = new ProductoStock();
            producto.Producto = _context.Productos.Find(codigoElemento);
            producto.Cantidad = SumarCantidadEnBodega(codigoElemento, nombreBodega);
            return producto;
        }
        public List<ProductoStock> ObtenerProductosEnBodega(string nombreBodega)
        {
            List<ProductoStock> productosStock = new List<ProductoStock>();
            ProductoStock productoStock;
            Producto producto;
            List<Producto> productos = new List<Producto>();
            var ajustes = _context.AjusteInventarios.Where(a => a.NombreBodega == nombreBodega).ToList();
            foreach (var ajuste in ajustes)
            {
                producto = _context.Productos.Find("123");
                productos.Add(producto);
            }
            foreach (var _producto in productos)
            {
                productoStock = new ProductoStock();
                productoStock.Producto = _producto;
                productoStock.Cantidad = SumarCantidadEnBodega(_producto.Codigo, nombreBodega);
                if (!EsRepetido(productosStock, productoStock.Producto.Codigo))
                {
                    productosStock.Add(productoStock);
                }
            }
            return productosStock;
        }
        private bool EsRepetido(List<ProductoStock> productosEnBodega, string codigo)
        {
            for (int i = 0; i < productosEnBodega.Count; i++)
            {
                if (productosEnBodega[i].Producto.Codigo == codigo) return true;
            }
            return false;
        }
        public InsumoStock ObtenerInsumoStockEnBodega(string codigo, string nombreBodega)
        {
            InsumoStock insumo = new InsumoStock();
            insumo.Insumo = _context.Insumos.Find(codigo);
            insumo.Cantidad = SumarCantidadEnBodega(codigo, nombreBodega);
            return insumo;
        }
        public IEnumerable<AjusteInventario> ObtenerAjustesElementoBodega(string codigoElemento, string nombreBodega)
        {
            return _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento && a.NombreBodega == nombreBodega);
        }
        /*      public IEnumerable<AjusteInventario> ObtenerProductosDeMateria(decimal codigoMateriaPrima)
              {
                  var ajustesSolicitadosxMateria = _context.AjusteInventarios.Where(a => a.CodigoMateriaPrima == codigoMateriaPrima);
                  IEnumerable<ProductoStock> productos;
                  ProductoStock producto;
                  foreach (var ajuste in ajustesSolicitadosxMateria)
                  {
                      producto = new ProductoStock();
                      producto.Producto = _context.Productos.Find(a => a.CodigoMateriaPrima == ajuste.CodigoMateriaPrima);
                      producto.Cantidad = SumarCantidadTotal(producto.Producto.Codigo);
                  }
              }*/
        public decimal SumarCantidad(string codigoElemento)
        {
            var ajustes = _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento);
            var sumaIncremento = ajustes.Where(a => a.Tipo == "Incremento").Sum(a => a.Cantidad);
            var sumaDisminucion = ajustes.Where(a => a.Tipo == "Disminucion").Sum(a => a.Cantidad);
            var cantidad = sumaIncremento - sumaDisminucion;
            if (0 > cantidad)
            {
                return 0;
            }
            return cantidad;
        }
        public decimal SumarCantidadEnBodega(string codigoElemento, string nombreBodega)
        {
            var ajustesSolicitadosxBodega = ObtenerAjustesElementoBodega(codigoElemento, nombreBodega);
            var sumaIncremento = ajustesSolicitadosxBodega.Where(a => a.Tipo == "Incremento").Sum(a => a.Cantidad);
            var sumaDisminucion = ajustesSolicitadosxBodega.Where(a => a.Tipo == "Disminucion").Sum(a => a.Cantidad);
            var cantidad = sumaIncremento - sumaDisminucion;
            if (0 > cantidad)
            {
                return 0;
            }
            return cantidad;
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
}