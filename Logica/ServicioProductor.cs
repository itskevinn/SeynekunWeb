using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioProductor
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioProductor repositorioProductor;

        public ServicioProductor(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioProductor = new RepositorioProductor(_conexión);
        }

        public GuardarResponse Guardar(Productor productor)
        {
            try
            {
                _conexión.Abrir();
                repositorioProductor.Guardar(productor);
                _conexión.Cerrar();
                return new GuardarResponse(productor);
            }
            catch (Exception e)
            {
                return new GuardarResponse(e.Message);
            }
        }

        public ConsultarResponse Consultar()
        {
            try
            {
                _conexión.Abrir();
                List<Productor> productores = repositorioProductor.Consultar().FindAll(p => p.Estado. .Equals("match"));
                _conexión.Cerrar();
                return new ConsultarResponse(productores);
            }
            catch (Exception e)
            {
                return new ConsultarResponse(e.Message);
            }
        }

        public BuscarxIdResponse BuscarxId(string identificacion)
        {
            try
            {
                _conexión.Abrir();
                Productor productor = repositorioProductor.BuscarxId(identificacion);
                _conexión.Cerrar();
                return new BuscarxIdResponse(productor);
            }
            catch (Exception e)
            {
                return new BuscarxIdResponse(e.Message);
            }
        }

        public string Modificar(Productor productorNuevo)
        {
            try
            {
                _conexión.Abrir();
                var productorViejo = repositorioProductor.BuscarxId(productorNuevo.Cedula);
                if (productorViejo != null)
                {
                    repositorioProductor.ModificarEstado(productorViejo.Cedula, "Modificado");
                    repositorioProductor.Modificar(productorNuevo);
                    _conexión.Cerrar();
                    return ($"El productor {productorNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró productor con la cédula ingresada";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexión.Cerrar(); }

        }
        public string Eliminar(string identificacion)
        {
            try
            {
                _conexión.Abrir();
                Productor productor = repositorioProductor.BuscarxId(identificacion);
                if (productor != null)
                {
                    repositorioProductor.ModificarEstado(identificacion, "Eliminado");
                    return $"El productor {productor.Nombre} {productor.Apellido} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró productor con la cédula ingresada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }


        public class GuardarResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Object objeto { get; set; }

            public GuardarResponse(Object objeto)
            {
                Error = false;
                this.objeto = objeto;
            }

            public GuardarResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }

        public class ConsultarResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Productor> objetos;

            public ConsultarResponse(List<Productor> objetos)
            {
                Error = false;
                this.objetos = objetos;

            }

            public ConsultarResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }

        public class BuscarxIdResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Productor Productor;

            public BuscarxIdResponse(Productor productor)
            {
                Error = false;
                this.Productor = productor;
            }

            public BuscarxIdResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
    }
}
