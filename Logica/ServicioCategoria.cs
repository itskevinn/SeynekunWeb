using System;
using System.Collections.Generic;
using Datos;
using Entity;
namespace Logica
{
    public class ServicioCategoria
    {
        
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioCategoria repositorioCategoria;

        public ServicioCategoria(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioCategoria = new RepositorioCategoria(_conexión);
        }

        public GuardarCategoriaResponse Guardar(Categoria categoria)
        {
            try
            {
                _conexión.Abrir();
                repositorioCategoria.Guardar(categoria);
                _conexión.Cerrar();
                return new GuardarCategoriaResponse(categoria);
            }
            catch (Exception e)
            {
                return new GuardarCategoriaResponse(e.Message);
            }
        }

        public ConsultarCategoriaResponse Consultar()
        {
            try
            {
                _conexión.Abrir();
                List<Categoria> categorias = repositorioCategoria.Consultar();
                _conexión.Cerrar();
                return new ConsultarCategoriaResponse(categorias);
            }
            catch (Exception e)
            {
                return new ConsultarCategoriaResponse(e.Message);
            }
        }

        public BuscarCategoriaxIdResponse BuscarxId(string nombre)
        {
            try
            {
                _conexión.Abrir();
                Categoria categoria = repositorioCategoria.BuscarxId(nombre);
                _conexión.Cerrar();
                return new BuscarCategoriaxIdResponse(categoria);
            }
            catch (Exception e)
            {
                return new BuscarCategoriaxIdResponse(e.Message);
            }
        }

        public string Modificar(Categoria categoriaNueva)
        {
            try
            {
                _conexión.Abrir();
                var categoriaVieja = repositorioCategoria.BuscarxId(categoriaNueva.Nombre);
                if (categoriaVieja != null)
                {
                    repositorioCategoria.ModificarEstado(categoriaVieja.Nombre, "Modificada");
                    repositorioCategoria.Modificar(categoriaNueva);
                    _conexión.Cerrar();
                    return ($"La categoria {categoriaNueva.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró categoria con el código ingresada";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexión.Cerrar(); }

        }
        public string Eliminar(string nombre)
        {
            try
            {
                _conexión.Abrir();
                Categoria categoria = repositorioCategoria.BuscarxId(nombre);
                if (categoria != null)
                {
                    repositorioCategoria.Eliminar(nombre);
                    return $"La categoria {categoria.Nombre} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró categoria con el código ingresada";
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