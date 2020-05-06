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

        public BuscarCategoriaxIdResponse BuscarxId(string codigo)
        {
            try
            {
                _conexión.Abrir();
                Categoria categoria = repositorioCategoria.BuscarxId(codigo);
                _conexión.Cerrar();
                return new BuscarCategoriaxIdResponse(categoria);
            }
            catch (Exception e)
            {
                return new BuscarCategoriaxIdResponse(e.Message);
            }
        }

        public string Modificar(Categoria categoriaNuevo)
        {
            try
            {
                _conexión.Abrir();
                var categoriaViejo = repositorioCategoria.BuscarxId(categoriaNuevo.codigo);
                if (categoriaViejo != null)
                {
                    repositorioCategoria.ModificarEstado(categoriaViejo.codigo, "Modificado");
                    repositorioCategoria.Modificar(categoriaNuevo);
                    _conexión.Cerrar();
                    return ($"El categoria {categoriaNuevo.Nombre} se ha modificado satisfactoriamente.");
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
        public string Eliminar(string codigo)
        {
            try
            {
                _conexión.Abrir();
                Categoria categoria = repositorioCategoria.BuscarxId(codigo);
                if (categoria != null)
                {
                    repositorioCategoria.ModificarEstado(codigo, "Eliminado");
                    return $"El categoria {categoria.Nombre} se ha eliminado.";
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
        public List<Categoria> objetos;

        public ConsultarCategoriaResponse(List<Categoria> objetos)
        {
            Error = false;
            this.objetos = objetos;

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
        public Categoria categoria { get; set; }
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