using System.Collections.Generic;
using System.Linq;
using Entity;
using System;
using Datos;

namespace Logica
{
    public class ServicioFichaTecnica
    {
        private readonly SeynekunContext _context;
        public ServicioFichaTecnica(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarFichaTecnicaResponse Guardar(FichaTecnica fichaTecnica)
        {
            try
            {
                var fichaTecnicaBuscado = _context.FichasTecnicas.Find(fichaTecnica.Id);
                if (fichaTecnicaBuscado != null)
                {
                    return new GuardarFichaTecnicaResponse("Id de ficha Tecnica ya registrada");
                }
                _context.FichasTecnicas.Add(fichaTecnica);
                _context.SaveChanges();
                return new GuardarFichaTecnicaResponse(fichaTecnica);
            }
            catch (Exception e)
            {
                return new GuardarFichaTecnicaResponse(e.Message);
            }
        }

        public ConsultarFichaTecnicaResponse Consultar()
        {
            try
            {
                List<FichaTecnica> fichasTecnicas = _context.FichasTecnicas.ToList();
                return new ConsultarFichaTecnicaResponse(fichasTecnicas);
            }
            catch (Exception e)
            {
                return new ConsultarFichaTecnicaResponse(e.Message);
            }
        }

        public BuscarFichaTecnicaResponse BuscarFichaTecnica(string id)
        {
            try
            {
                FichaTecnica fichaTecnica = _context.FichasTecnicas.Find(id);
                if (fichaTecnica != null)
                {
                    return new BuscarFichaTecnicaResponse("Ficha Tecnica no registrada");
                }
                return new BuscarFichaTecnicaResponse(fichaTecnica);
            }
            catch (Exception e)
            {
                return new BuscarFichaTecnicaResponse(e.Message);
            }
        }

        public string Modificar(FichaTecnica fichaTecnica)
        {
            try
            {
                var fichaTecnicaVieja = _context.FichasTecnicas.Find(fichaTecnica.Id);
                if (fichaTecnicaVieja != null)
                {
                    fichaTecnicaVieja.Ingrediente = fichaTecnica.Ingrediente;
                    fichaTecnicaVieja.TipoIngrediente = fichaTecnica.TipoIngrediente;
                    fichaTecnicaVieja.NumeroCas = fichaTecnica.NumeroCas;
                    fichaTecnicaVieja.Observacion = fichaTecnica.Observacion;
                    fichaTecnicaVieja.Ce = fichaTecnica.Ce;
                    fichaTecnicaVieja.Nop = fichaTecnica.Nop;
                    fichaTecnicaVieja.Jas = fichaTecnica.Jas;
                    fichaTecnicaVieja.Efapa = fichaTecnica.Efapa;
                    fichaTecnicaVieja.Col = fichaTecnica.Col;
                    _context.FichasTecnicas.Update(fichaTecnicaVieja);
                    _context.SaveChanges();
                    return ($"La Ficha Tecnica con id: {fichaTecnicaVieja.Id} se ha modificado satisfactoriamente.");
                }
                return $"No se encontró Ficha Tecnica con id: {fichaTecnica.Id}";
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }

        public string Eliminar(string id)
        {
            try
            {
                FichaTecnica fichaTecnica = _context.FichasTecnicas.Find(id);
                if (fichaTecnica != null)
                {
                    _context.FichasTecnicas.Update(fichaTecnica);
                    _context.SaveChanges();
                    return $"El Ficha Tecnica con id: {fichaTecnica.Id} se ha eliminado.";
                }
                return $"No se encontró Ficha Tecnica con id: {id}";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }

    public class GuardarFichaTecnicaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public FichaTecnica FichaTecnica { get; set; }

        public GuardarFichaTecnicaResponse(FichaTecnica fichaTecnica)
        {
            Error = false;
            FichaTecnica = fichaTecnica;
        }

        public GuardarFichaTecnicaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarFichaTecnicaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<FichaTecnica> FichasTecnicas;

        public ConsultarFichaTecnicaResponse(List<FichaTecnica> fichasTecnicas)
        {
            Error = false;
            FichasTecnicas = fichasTecnicas;
        }

        public ConsultarFichaTecnicaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarFichaTecnicaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public FichaTecnica FichaTecnica;

        public BuscarFichaTecnicaResponse(FichaTecnica fichaTecnica)
        {
            Error = false;
            FichaTecnica = fichaTecnica;
        }

        public BuscarFichaTecnicaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
