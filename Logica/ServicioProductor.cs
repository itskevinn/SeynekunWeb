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
                List<Productor> productores = repositorioProductor.Consultar().FindAll(p => p.Estado.Equals("Activo") || p.Estado.Equals("Modificado"));
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

        public string Modificar(string identificacion, Productor productorNuevo)
        {
            try
            {
                _conexión.Abrir();
                Productor productorAntiguo = repositorioProductor.BuscarxId(identificacion);
                    if(productorAntiguo!=null){
                        repositorioProductor.Modificar(productorAntiguo, productorNuevo);
                        return $"El productor {productorAntiguo.Nombre} {productorAntiguo.Apellido} se ha modificado exitosamente.";
                    }                
                _conexión.Cerrar();
                return $"El productor {productorAntiguo.Cedula} no está registrado.";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
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
