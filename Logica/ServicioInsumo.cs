using System.Collections.Generic;
using System.Linq;
using Entity;
using System;
using Datos;

namespace Logica
{
    public class ServicioInsumo
    {
        private readonly SeynekunContext _context;
        public ServicioInsumo(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarInsumoResponse Guardar(Insumo insumo)
        {
            try
            {
                var insumoBuscado = _context.Insumos.Find(insumo.Id);
                if(insumoBuscado != null)
                {
                    return new GuardarInsumoResponse("Id de insumo ya registrada");
                }
                insumo.Estado = "Activo";
                _context.Insumos.Add(insumo);
                _context.SaveChanges();
                return new GuardarInsumoResponse(insumo);
            }
            catch (Exception e)
            {
                return new GuardarInsumoResponse(e.Message);
            }
        }

        public ConsultarInsumoResponse Consultar()
        {
            try
            {
                List<Insumo> insumos = _context.Insumos.ToList();
                return new ConsultarInsumoResponse(insumos);
            }
            catch (Exception e)
            {
                return new ConsultarInsumoResponse(e.Message);
            }
        }

        public BuscarInsumoResponse BuscarInsumo(string id)
        {
            try
            {
                Insumo insumo = _context.Insumos.Find(id);
                if(insumo == null)
                {
                    return new BuscarInsumoResponse("Insumo no registrado");
                }
                return new BuscarInsumoResponse(insumo);
            }
            catch (Exception e)
            {
                return new BuscarInsumoResponse(e.Message);
            }
        }

        public string Modificar(Insumo insumoNuevo)
        {
            try
            {
                var insumoViejo = _context.Insumos.Find(insumoNuevo.Id);
                if (insumoViejo != null)
                {
                    insumoViejo.Nombre = insumoNuevo.Nombre;
                    insumoViejo.Uso = insumoNuevo.Uso;
                    insumoViejo.RegistroIca = insumoNuevo.RegistroIca;
                    insumoViejo.Descripcion = insumoNuevo.Descripcion;
                    insumoViejo.Resultado = insumoNuevo.Resultado;
                    insumoViejo.Estado = "Modificado";
                    _context.Insumos.Update(insumoViejo);
                    _context.SaveChanges();
                    return ($"El insumo con id: {insumoViejo.Id} y nombre: {insumoViejo.Nombre} se ha modificado satisfactoriamente.");
                }
                return $"No se encontró insumo con id: {insumoNuevo.Id}";
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
                Insumo insumo = _context.Insumos.Find(id);
                if (insumo != null)
                {
                    insumo.Estado = "Eliminado";
                    _context.Insumos.Update(insumo);
                    _context.SaveChanges();
                    return $"El insumo con id: {insumo.Id} y nombre: {insumo.Nombre} se ha eliminado.";
                }
                return $"No se encontró insumo con id: {id}";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }

    public class GuardarInsumoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Insumo Insumo { get; set; }

        public GuardarInsumoResponse(Insumo insumo)
        {
            Error = false;
            Insumo = insumo;
        }

        public GuardarInsumoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarInsumoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Insumo> Insumos;

        public ConsultarInsumoResponse(List<Insumo> insumos)
        {
            Error = false;
            Insumos = insumos;
        }

        public ConsultarInsumoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarInsumoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Insumo Insumo;

        public BuscarInsumoResponse(Insumo insumo)
        {
            Error = false;
            Insumo = insumo;
        }

        public BuscarInsumoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
