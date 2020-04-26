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
    }

    public class GuardarResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Productor productor { get; set; }

        public GuardarResponse(Productor productor)
        {
            Error = false;
            this.productor = productor;
        }

        public GuardarResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}