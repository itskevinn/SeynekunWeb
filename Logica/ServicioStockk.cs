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

        public List<ProductoStock> ObtenerProductosEnBodega(string nombreBodega)
        {
            List<ProductoStock> productosStock = new List<ProductoStock>();
            ProductoStock productoStock;
            Producto producto;
            List<Producto> productos = new List<Producto>();
            var ajustes = _context.AjusteInventarios.Where(a => a.NombreBodega == nombreBodega).ToList();
            foreach (var ajuste in ajustes)
            {
                producto = _context.Productos.Find(ajuste.CodigoElemento);
                productos.Add(producto);
            }
            foreach (var _producto in productos)
            {
                productoStock = new ProductoStock();
                productoStock.Producto = _producto;
                productoStock.Cantidad = SumarCantidadEnBodega(_producto.Codigo, nombreBodega);
                if (!EsRepetido(productosStock, productoStock.Producto.Codigo))
                {
                    if (productoStock.Cantidad > 0)
                    {
                        productosStock.Add(productoStock);
                    }
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
        public IEnumerable<AjusteInventario> ObtenerAjustesElementoBodega(string codigoElemento, string nombreBodega)
        {
            return _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento && a.NombreBodega == nombreBodega);
        }
        public decimal SumarCantidadEnBodega(string codigoElemento, string nombreBodega)
        {
            var ajustesSolicitadosxBodega = ObtenerAjustesElementoBodega(codigoElemento, nombreBodega);
            var sumaIncremento = ajustesSolicitadosxBodega.Where(a => a.TipoAjuste == "Incremento").Sum(a => a.Cantidad);
            var sumaDisminucion = ajustesSolicitadosxBodega.Where(a => a.TipoAjuste == "Disminucion").Sum(a => a.Cantidad);
            var cantidad = sumaIncremento - sumaDisminucion;
            if (0 > cantidad)
            {
                return 0;
            }
            return cantidad;
        }
        public List<BodegaProducto> ObtenerBodegasxProducto(string codigoProducto)
        {
            List<BodegaProducto> bodegasStock = new List<BodegaProducto>();
            BodegaProducto bodegaStock;
            Bodega bodega;
            List<Bodega> bodegas = new List<Bodega>();
            var ajustes = _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoProducto).ToList();
            foreach (var ajuste in ajustes)
            {
                bodega = _context.Bodegas.Find(ajuste.NombreBodega);
                bodegas.Add(bodega);
            }
            foreach (var _bodega in bodegas)
            {
                bodegaStock = new BodegaProducto();
                bodegaStock.Bodega = _bodega;
                bodegaStock.Cantidad = SumarCantidadEnBodega(codigoProducto, _bodega.Nombre);
                if (!EsRepetida(bodegasStock, bodegaStock.Bodega.Nombre))
                {
                    bodegasStock.Add(bodegaStock);
                }
            }
            return bodegasStock;
        }
        private bool EsRepetida(List<BodegaProducto> bodegas, string nombre)
        {
            for (int i = 0; i < bodegas.Count; i++)
            {
                if (bodegas[i].Bodega.Nombre == nombre) return true;
            }
            return false;
        }
    }
}
/*   public class ConsultarAjusteInventarioResponse
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
   }*/
/*   public List<AjusteInventario> Consultar()
   {
       List<AjusteInventario> ajusteInventarios = _context.AjusteInventarios.ToList();
       return ajusteInventarios;
   }*/
/*   public BuscarAjusteInventarioxIdResponse BuscarxId(decimal codigo)
   {
       var ajusteInventario = _context.AjusteInventarios.Find(codigo);
       if (ajusteInventario != null)
       {
           return new BuscarAjusteInventarioxIdResponse(ajusteInventario);
       }
       return new BuscarAjusteInventarioxIdResponse("Ajuste no encontrado");
   }*/
/*   public ProductoStock ObtenerProductoStockEnBodega(string codigoElemento, string nombreBodega)
 {
        ProductoStock producto = new ProductoStock();
        producto.Producto = _context.Productos.Find(codigoElemento);
        producto.Cantidad = SumarCantidadEnBodega(codigoElemento, nombreBodega);
        return producto;
    }*/
/*   public IEnumerable<AjusteInventario> ObtenerProductosDeMateria(decimal codigoMateriaPrima)
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
/*   public decimal SumarCantidad(string codigoElemento)
  {
      var ajustes = _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento);
      var sumaIncremento = ajustes.Where(a => a.TipoAjuste == "Incremento").Sum(a => a.Cantidad);
      var sumaDisminucion = ajustes.Where(a => a.TipoAjuste == "Disminucion").Sum(a => a.Cantidad);
      var cantidad = sumaIncremento - sumaDisminucion;
      if (0 > cantidad)
      {
          return 0;
      }
      return cantidad;
  }*/
/*   public InsumoStock ObtenerInsumoStockEnBodega(string codigo, string nombreBodega)
    {
        InsumoStock insumo = new InsumoStock();
        insumo.Insumo = _context.Insumos.Find(codigo);
        insumo.Cantidad = SumarCantidadEnBodega(codigo, nombreBodega);
        return insumo;
    }*/
