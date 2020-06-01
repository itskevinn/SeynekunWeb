using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioFabricante
    {
        /*
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioFabricante repositorioFabricante;

        public ServicioFabricante(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioFabricante = new RepositorioFabricante(_conexión);
        }

        public GuardarFabricanteResponse Guardar(Fabricante fabricante)
        {
            try
            {
                fabricante.Estado = "Activo";
                _conexión.Abrir();
                repositorioFabricante.Guardar(fabricante);
                _conexión.Cerrar();
                return new GuardarFabricanteResponse(fabricante);
            }
            catch (Exception e)
            {
                return new GuardarFabricanteResponse(e.Message);
            }
        }

        public ConsultarFabricanteResponse Consultar() {
            try {
                _conexión.Abrir();
                List<Fabricante> fabricantes = repositorioFabricante.Consultar().FindAll(c => c.Estado.Equals("Activo") || c.Estado.Equals("Modificado"));;
                _conexión.Cerrar();
                return new ConsultarFabricanteResponse(fabricantes);
            }
            catch (Exception e) {
                return new ConsultarFabricanteResponse(e.Message);
            }
        }

        public BuscarFabricantexIdResponse BuscarxId(string identificacion)
        {
            try
            {
                _conexión.Abrir();
                Fabricante fabricante = repositorioFabricante.BuscarxId(identificacion);
                _conexión.Cerrar();
                if (fabricante != null && fabricante.Estado != "Eliminado") {
                    return new BuscarFabricantexIdResponse(fabricante);
                }
                return new BuscarFabricantexIdResponse("fabricante no encontrado");
            }
            catch (Exception e)
            {
                return new BuscarFabricantexIdResponse(e.Message);
            }
        }

        public string Modificar(Fabricante fabricanteNuevo)
        {
            try
            {
                _conexión.Abrir();
                var fabricanViejo = repositorioFabricante.BuscarxId(fabricanteNuevo.Identificacion);
                if (fabricanViejo != null && fabricanViejo.Estado != "Eliminado")
                {
                    repositorioFabricante.ModificarEstado(fabricanViejo.Identificacion, "Modificado");
                    repositorioFabricante.Modificar(fabricanteNuevo);
                    _conexión.Cerrar();
                    return ($"El fabricante {fabricanteNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return $"No se encontró Fabricante con la identificacion: {fabricanteNuevo.Identificacion} ingresada";
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
                Fabricante fabricante = repositorioFabricante.BuscarxId(identificacion);
                if (fabricante != null && fabricante.Estado != "Eliminado") {
                    repositorioFabricante.ModificarEstado(identificacion, "Eliminado");
                    return $"El fabricante {fabricante.Nombre} {fabricante.Apellido} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró fabricante con la cédula ingresada";
            }
            catch (Exception e) {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
        */
    }

    public class GuardarFabricanteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Fabricante Fabricante { get; set; }

        public GuardarFabricanteResponse(Fabricante fabricante)
        {
            Error = false;
            this.Fabricante = fabricante;
        }

        public GuardarFabricanteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarFabricanteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Fabricante> Fabricantes;

        public ConsultarFabricanteResponse(List<Fabricante> fabricantes)
        {
            Error = false;
            this.Fabricantes = fabricantes;
        }

        public ConsultarFabricanteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarFabricantexIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Fabricante Fabricante;

        public BuscarFabricantexIdResponse(Fabricante fabricante)
        {
            Error = false;
            this.Fabricante = fabricante;
        }

        public BuscarFabricantexIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
