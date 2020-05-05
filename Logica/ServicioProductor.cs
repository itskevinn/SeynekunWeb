using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica {
    public class ServicioProductor {
    
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioProductor repositorioProductor;

        public ServicioProductor(string cadenaDeConexión) {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioProductor = new RepositorioProductor(_conexión);
        }

        public GuardarProductorResponse Guardar(Productor productor) {
            try {
                productor.Estado = "Activo";
                productor.NombreUsuario = "Probando";
                productor.Contrasena = "Probando";
                _conexión.Abrir();
                repositorioProductor.Guardar(productor);
                _conexión.Cerrar();
                return new GuardarProductorResponse(productor);
            }
            catch (Exception e) {
                return new GuardarProductorResponse(e.Message);
            }
        }

        public ConsultarProductorResponse Consultar() {
            try {
                _conexión.Abrir();
                List<Productor> productores = repositorioProductor.Consultar().FindAll(p => p.Estado.Equals("Activo") || p.Estado.Equals("Modificado"));
                _conexión.Cerrar();
                return new ConsultarProductorResponse(productores);
            }
            catch (Exception e) {
                return new ConsultarProductorResponse(e.Message);
            }
        }

        public BuscarxIdProductorResponse BuscarxId(string identificacion) {
            try {
                _conexión.Abrir();
                Productor productor = repositorioProductor.BuscarxId(identificacion);
                _conexión.Cerrar();
                if (productor != null && productor.Estado != "Eliminado") {
                    return new BuscarxIdProductorResponse(productor);
                }
                return new BuscarxIdProductorResponse("Productor no encontrado");
            }
            catch (Exception e) {
                return new BuscarxIdProductorResponse(e.Message);
            }
        }

        public string Modificar(Productor productorNuevo) {
            try {
                _conexión.Abrir();
                var productorViejo = repositorioProductor.BuscarxId(productorNuevo.Identificacion);
                if (productorViejo != null && productorViejo.Estado != "Eliminado") {
                    repositorioProductor.ModificarEstado(productorViejo.Identificacion, "Modificado");
                    repositorioProductor.Modificar(productorNuevo);
                    _conexión.Cerrar();
                    return ($"El productor {productorNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else {
                    return $"No se encontró productor con la identificacion: {productorNuevo.Identificacion} ingresada";
                }
            }
            catch (Exception e) {
                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexión.Cerrar(); }
        }

        public string Eliminar(string identificacion) {
            try {
                _conexión.Abrir();
                Productor productor = repositorioProductor.BuscarxId(identificacion);
                if (productor != null && productor.Estado != "Eliminado")
                {
                    repositorioProductor.ModificarEstado(productor.Identificacion, "Eliminado");
                    return $"El productor {productor.Nombre} {productor.Apellido} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró productor con la cédula ingresada";
            }
            catch (Exception e) {
                return $"Error de la aplicación: {e.Message} ";
            }
        }

        public class GuardarProductorResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Productor Productor { get; set; }

            public GuardarProductorResponse(Productor productor)
            {
                Error = false;
                this.Productor = productor;
            }

            public GuardarProductorResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }

        public class ConsultarProductorResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Productor> Productores;

            public ConsultarProductorResponse(List<Productor> productores)
            {
                Error = false;
                this.Productores = productores;

            }

            public ConsultarProductorResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }

        public class BuscarxIdProductorResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Productor Productor;

            public BuscarxIdProductorResponse(Productor productor)
            {
                Error = false;
                this.Productor = productor;
            }

            public BuscarxIdProductorResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
    }
}
