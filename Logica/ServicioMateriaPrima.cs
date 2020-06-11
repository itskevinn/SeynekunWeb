using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
namespace Logica
{
    public class ServicioMateriaPrima
    {

        private readonly SeynekunContext _context;
        public ServicioMateriaPrima(SeynekunContext context)
        {
            _context = context;
        }
        public GuardarMateriaPrimaResponse Guardar(MateriaPrima materiaPrima)
        {
            try
            {
                var materiaPrimaBuscado = _context.MateriasPrimas.Find(materiaPrima.Codigo);
                var productor = _context.Productores.Find(materiaPrima.CodigoProductor);
                if (materiaPrimaBuscado != null)
                {
                    if (productor == null)
                    {
                        return new GuardarMateriaPrimaResponse("Este productor no existe");
                    }
                    return new GuardarMateriaPrimaResponse("Imposible añadir este registro, código duplicado");
                }
                _context.MateriasPrimas.Add(materiaPrima);
                _context.SaveChanges();
                return new GuardarMateriaPrimaResponse(materiaPrima);
            }
            catch (Exception e)
            {
                return new GuardarMateriaPrimaResponse(e.Message);
            }
        }
        public List<MateriaPrima> Consultar()
        {
            List<MateriaPrima> MateriasPrimas = _context.MateriasPrimas.ToList();
            return MateriasPrimas;
        }
        public List<MateriaPrima> ConsultarDisponibles()
        {
            List<MateriaPrima> materiaPrimas = _context.MateriasPrimas.Where(m => m.EstadoMateria == "Pendiente").ToList();
            return materiaPrimas;
        }
        public List<MateriaPrima> ConsultarxProductor(string codigo)
        {
            List<MateriaPrima> MateriasPrimas = _context.MateriasPrimas.Where(m => m.CodigoProductor == codigo).ToList();
            return MateriasPrimas;
        }
        public BuscarMateriaPrimaxIdResponse BuscarxId(string codigo)
        {
            var materiaPrima = _context.MateriasPrimas.Find(codigo);
            if (materiaPrima != null)
            {
                return new BuscarMateriaPrimaxIdResponse(materiaPrima);
            }
            return new BuscarMateriaPrimaxIdResponse("Materia no encontrado");
        }
        public string Modificar(MateriaPrima materiaPrimaNuevo)
        {
            try
            {
                var materiaPrimaViejo = _context.MateriasPrimas.Find(materiaPrimaNuevo.Codigo);
                if (materiaPrimaViejo != null)
                {
                    materiaPrimaViejo.Fecha = materiaPrimaNuevo.Fecha;
                    materiaPrimaViejo.Cantidad = materiaPrimaNuevo.Cantidad;
                    materiaPrimaViejo.CodigoProductor = materiaPrimaNuevo.CodigoProductor;
                    materiaPrimaViejo.UnidadMedida = materiaPrimaNuevo.UnidadMedida;
                    _context.MateriasPrimas.Update(materiaPrimaViejo);
                    _context.SaveChanges();
                    return ($"El Ajuste se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro del ajuste solicitado";
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public string Eliminar(string codigo)
        {
            try
            {
                MateriaPrima materiaPrima = _context.MateriasPrimas.Find(codigo);
                if (materiaPrima != null)
                {
                    _context.MateriasPrimas.Remove(materiaPrima);
                    _context.SaveChanges();
                    return $"El Ajuste de Inventario se ha eliminado.";
                }
                return "El Ajuste de Inventario no fue encontrado";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }
    public class ConsultarMateriaPrimaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<MateriaPrima> MateriasPrimas;

        public ConsultarMateriaPrimaResponse(List<MateriaPrima> objetos)
        {
            Error = false;
            this.MateriasPrimas = objetos;

        }

        public ConsultarMateriaPrimaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarMateriaPrimaResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
        public GuardarMateriaPrimaResponse(MateriaPrima materiaPrima)
        {
            Error = false;
            MateriaPrima = materiaPrima;
        }
        public GuardarMateriaPrimaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BuscarMateriaPrimaxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public MateriaPrima MateriaPrima;

        public BuscarMateriaPrimaxIdResponse(MateriaPrima materiaPrima)
        {
            Error = false;
            this.MateriaPrima = materiaPrima;
        }

        public BuscarMateriaPrimaxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}