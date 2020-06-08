using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioCategoria
    {

        private readonly SeynekunContext _context;
        public ServicioCategoria(SeynekunContext context)
        {
            _context = context;
        }
        public GuardarCategoriaResponse Guardar(Categoria categoria)
        {
            try
            {
                var categoriaBuscado = _context.Categorias.Find(categoria.Nombre);
                if (categoriaBuscado != null)
                {
                    return new GuardarCategoriaResponse("!Categoria ya registrada!");
                }
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return new GuardarCategoriaResponse(categoria);
            }
            catch (Exception e)
            {
                return new GuardarCategoriaResponse(e.Message);
            }
        }
        public List<Categoria> Consultar()
        {
            List<Categoria> categorias = _context.Categorias.ToList();
            categorias = ConsultarProductosEnCategoria(categorias);
            return categorias;
        }

        private List<Categoria> ConsultarProductosEnCategoria(List<Categoria> categorias)
        {
            List<Categoria> _categorias = new List<Categoria>();
            foreach (var categoria in categorias)
            {
                categoria.Productos = _context.Productos.Where(p => p.NombreCategoria == categoria.Nombre).ToList();
                _categorias.Add(categoria);
            }
            return _categorias;
        }

        public BuscarCategoriaxIdResponse BuscarxId(string nombre)
        {
            var categoria = _context.Categorias.Find(nombre);
            if (categoria != null && categoria.Estado != "Eliminado")
            {
                return new BuscarCategoriaxIdResponse(categoria);
            }
            return new BuscarCategoriaxIdResponse("Categoria no encontrada");
        }
        public string Modificar(Categoria categoriaNueva)
        {
            try
            {
                var categoriaVieja = _context.Categorias.Find(categoriaNueva.Nombre);
                if (categoriaVieja != null && categoriaVieja.Estado != "Eliminado")
                {
                    categoriaVieja.Nombre = categoriaNueva.Nombre;
                    categoriaVieja.Detalle = categoriaNueva.Detalle;
                    categoriaVieja.Estado = categoriaNueva.Estado;
                    categoriaVieja.Productos = categoriaNueva.Productos;
                    _context.Categorias.Update(categoriaVieja);
                    _context.SaveChanges();
                    return ($"La categoria se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro de la categoria solicitada";
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
                Categoria categoria = _context.Categorias.Find(nombre);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    _context.SaveChanges();
                    return $"La categoria se ha eliminado.";
                }
                return "La categoria no fue encontrada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }
    public class ConsultarCategoriaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Categoria> Categorias;

        public ConsultarCategoriaResponse(List<Categoria> objetos)
        {
            Error = false;
            this.Categorias = objetos;

        }

        public ConsultarCategoriaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarCategoriaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Categoria Categoria { get; set; }
        public GuardarCategoriaResponse(Categoria categoria)
        {
            Error = false;
            Categoria = categoria;
        }
        public GuardarCategoriaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BuscarCategoriaxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Categoria Categoria;

        public BuscarCategoriaxIdResponse(Categoria categoria)
        {
            Error = false;
            this.Categoria = categoria;
        }

        public BuscarCategoriaxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}