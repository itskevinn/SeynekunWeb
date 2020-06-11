using Datos;
using System.Collections.Generic;
using System.Linq;
using Entity;
using System;

namespace Logica
{
    public class ServicioAjusteInventario
    {
        private readonly SeynekunContext _context;
        private ServicioProducto servicioProducto;
        public ServicioAjusteInventario(SeynekunContext context)
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
                    return new GuardarAjusteInventarioResponse("¡Ajuste de inventario ya registrado!");
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

        public BuscarAjusteInventarioxIdResponse BuscarxId(string codigo)
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
                    ajusteInventarioViejo.TipoAjuste = ajusteInventarioNuevo.TipoAjuste;
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

        public IEnumerable<AjusteInventario> ObtenerAjustesxProductoyBodega(string codigoElemento, string nombreBodega)
        {
            return _context.AjusteInventarios.Where(a => a.CodigoElemento == codigoElemento && a.NombreBodega == nombreBodega);
        }
        public IEnumerable<ProductoStock> ObtenerProductosDeMateria(string codigoMateriaPrima)
        {
            var ajustesSolicitadosxMateria = _context.AjusteInventarios.Where(a => a.CodigoMateriaPrima == codigoMateriaPrima);
            List<ProductoStock> productos = new List<ProductoStock>();
            decimal cantidad;
            ProductoStock productoStock = new ProductoStock();
            foreach (var ajuste in ajustesSolicitadosxMateria)
            {
                if (ajuste.TipoAjuste == "Incremento")
                {
                    cantidad = +ajuste.Cantidad;
                }
                else cantidad = -ajuste.Cantidad;
                if (ajuste.TipoElemento == "Producto")
                {
                    productoStock.Producto = BuscarProductoxId(ajuste.CodigoElemento);
                    productoStock.Cantidad = cantidad;
                    productos.Add(productoStock);
                }
            }
            return productos;
        }
        private Producto BuscarProductoxId(string id)
        {
            return _context.Productos.Find(id);
        }
        public decimal SumarCantidadTotal(string codigoElemento)
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
        }

        public decimal SumarCantidad(string codigoElemento, string nombreBodega)
        {
            var ajustesSolicitadosxBodega = ObtenerAjustesxProductoyBodega(codigoElemento, nombreBodega);
            var sumaIncremento = ajustesSolicitadosxBodega.Where(a => a.TipoAjuste == "Incremento").Sum(a => a.Cantidad);
            var sumaDisminucion = ajustesSolicitadosxBodega.Where(a => a.TipoAjuste == "Disminucion").Sum(a => a.Cantidad);
            var cantidad = sumaIncremento - sumaDisminucion;
            if (0 > cantidad)
            {
                return 0;
            }
            return cantidad;
        }

        public string Eliminar(string codigo)
        {
            try
            {
                AjusteInventario ajusteInventario = _context.AjusteInventarios.Find(codigo);
                if (ajusteInventario != null)
                {
                    _context.AjusteInventarios.Remove(ajusteInventario);
                    _context.SaveChanges();
                    return $"El ajuste de inventario se ha eliminado.";
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
