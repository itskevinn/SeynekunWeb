using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioFabricante
    {

        private readonly SeynekunContext _context;
        public ServicioFabricante(SeynekunContext context)
        {
            _context = context;
        }
        public GuardarFabricanteResponse Guardar(Fabricante fabricante)
        {
            try
            {
                var fabricanteBuscado = _context.Fabricantes.Find(fabricante.Nombre);
                if (fabricanteBuscado != null)
                {
                    return new GuardarFabricanteResponse("Dos fabricantes no pueden tener el mismo nombre");
                }
                _context.Fabricantes.Add(fabricante);
                _context.SaveChanges();
                return new GuardarFabricanteResponse(fabricante);
            }
            catch (Exception e)
            {
                return new GuardarFabricanteResponse(e.Message);
            }
        }
        public List<Fabricante> Consultar()
        {
            List<Fabricante> fabricantes = _context.Fabricantes.ToList();
            return fabricantes;
        }
        public BuscarFabricantexIdResponse BuscarxId(string nombre)
        {
            var fabricante = _context.Fabricantes.Find(nombre);
            if (fabricante != null && fabricante.Estado != "Eliminado")
            {
                return new BuscarFabricantexIdResponse(fabricante);
            }
            return new BuscarFabricantexIdResponse("fabricante no encontrada");
        }
        public string Modificar(Fabricante fabricanteNueva)
        {
            try
            {
                var fabricanteVieja = _context.Fabricantes.Find(fabricanteNueva.Nombre);
                if (fabricanteVieja != null && fabricanteVieja.Estado != "Eliminado")
                {
                    fabricanteVieja.Nombre = fabricanteNueva.Nombre;
                    fabricanteVieja.Apellido = fabricanteNueva.Apellido;
                    fabricanteVieja.Direccion = fabricanteNueva.Direccion;
                    fabricanteVieja.Estado = fabricanteNueva.Estado;
                    fabricanteVieja.Email = fabricanteNueva.Email;
                    fabricanteVieja.Fax = fabricanteNueva.Fax;
                    fabricanteVieja.SitioWeb = fabricanteNueva.SitioWeb;
                    fabricanteVieja.Identificacion = fabricanteNueva.Identificacion;
                    fabricanteVieja.TipoIdentificacion = fabricanteNueva.TipoIdentificacion;
                    fabricanteVieja.NumeroTelefono = fabricanteNueva.NumeroTelefono;
                    _context.Fabricantes.Update(fabricanteNueva);
                    _context.SaveChanges();
                    return ($"La fabricante se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro de la fabricante solicitada";
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
                Fabricante fabricante = _context.Fabricantes.Find(nombre);
                if (fabricante != null)
                {
                    _context.Fabricantes.Remove(fabricante);
                    _context.SaveChanges();
                    return $"La fabricante se ha eliminado.";
                }
                return "La fabricante no fue encontrada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
        */
    }
    public class ConsultarFabricanteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Fabricante> Fabricantes;

        public ConsultarFabricanteResponse(List<Fabricante> objetos)
        {
            Error = false;
            this.Fabricantes = objetos;

        }

        public ConsultarFabricanteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarFabricanteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Fabricante Fabricante { get; set; }
        public GuardarFabricanteResponse(Fabricante fabricante)
        {
            Error = false;
            Fabricante = fabricante;
        }
        public GuardarFabricanteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
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