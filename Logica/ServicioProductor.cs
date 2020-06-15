using System.Linq;
using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioProductor
    {

        private readonly SeynekunContext _context;
        public ServicioProductor(SeynekunContext context)
        {
            _context = context;
        }
        public decimal SumarCantidadSolicitud()
        {
             return _context.Productores.Where(p => p.Estado.ToLower() == "pendiente").Count();
        }
        public List<Productor> ConsultarPendientes()
        {
            return _context.Productores.Where(p => p.Estado.ToLower() == "pendiente").ToList();
        }
        public GuardarProductorResponse Guardar(Productor producto)
        {
            try
            {
                var productoBuscado = _context.Productores.Find(producto.Identificacion);
                var usuarioBuscado = _context.Usuarios.Find(producto.NombreUsuario);
                if (productoBuscado == null && usuarioBuscado == null)
                {
                    _context.Productores.Add(producto);
                    GuardarUsuario(producto);
                    _context.SaveChanges();
                    return new GuardarProductorResponse(producto);
                }
                if (productoBuscado != null)
                {
                    return new GuardarProductorResponse("¡Productor ya registrado!");
                }
                return new GuardarProductorResponse("¡Usuario ya está en uso!");
            }
            catch (Exception e)
            {
                return new GuardarProductorResponse(e.Message);
            }
        }
        public void GuardarUsuario(Productor productor)
        {
            Usuario usuario = new Usuario();
            usuario.NombreUsuario = productor.NombreUsuario;
            usuario.NumeroTelefono = productor.NumeroTelefono;
            usuario.Nombre = productor.Nombre;
            usuario.Estado = productor.Estado;
            usuario.Email = productor.Email;
            usuario.Tipo = "Productor";
            usuario.Contrasena = productor.Contrasena;
            usuario.Id = productor.Identificacion;
            usuario.Apellido = productor.Apellido;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        public List<Productor> Consultar()
        {
            List<Productor> productos = _context.Productores.Where(p => p.Estado.ToLower() == "activo" || p.Estado.ToLower() == "modificado").ToList();
            return productos;
        }
        public BuscarProductorxIdResponse BuscarxId(string identificacion)
        {
            var producto = _context.Productores.Find(identificacion);
            if (producto != null && producto.Estado.ToLower() == "activo" || producto.Estado.ToLower() == "modificado")
            {
                return new BuscarProductorxIdResponse(producto);
            }
            return new BuscarProductorxIdResponse("Productor no encontrado");
        }

        public BuscarProductorxIdResponse BuscarxIdModEstado(string identificacion)
        {
            Productor productor = _context.Productores.Find(identificacion);
            if (productor != null && productor.Estado.ToLower() == "pendiente")
            {
                return new BuscarProductorxIdResponse(productor);
            }
            return new BuscarProductorxIdResponse("Productor no encontrado");
        }

        public string Modificar(Productor productoNueva)
        {
            try
            {
                var productoVieja = _context.Productores.Find(productoNueva.Identificacion);
                if (productoVieja != null && productoVieja.Estado != "Eliminado")
                {
                    productoVieja.TipoIdentificacion = productoNueva.TipoIdentificacion;
                    productoVieja.Contrasena = productoNueva.Contrasena;
                    productoVieja.NombreUsuario = productoNueva.NombreUsuario;
                    productoVieja.Estado = productoNueva.Estado;
                    productoVieja.Nombre = productoNueva.Nombre;
                    productoVieja.Apellido = productoNueva.Apellido;
                    productoVieja.Estado = productoNueva.Estado;
                    productoVieja.AfiliacionSalud = productoNueva.AfiliacionSalud;
                    productoVieja.NombrePredio = productoNueva.NombrePredio;
                    productoVieja.NombreUsuario = productoNueva.NombreUsuario;
                    productoVieja.NumeroTelefono = productoNueva.NumeroTelefono;
                    productoVieja.Municipio = productoNueva.Municipio;
                    productoVieja.Vereda = productoNueva.Vereda;
                    productoVieja.TipoIdentificacion = productoNueva.TipoIdentificacion;
                    productoVieja.CedulaCafetera = productoNueva.CedulaCafetera;
                    productoVieja.CodigoFinca = productoNueva.CodigoFinca;
                    productoVieja.CodigoSica = productoNueva.CodigoSica;
                    productoVieja.Contrasena = productoNueva.Contrasena;
                    productoVieja.Email = productoNueva.Email;
                    _context.Productores.Update(productoNueva);
                    _context.SaveChanges();
                    return ($"El productor se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro del productor solicitado";
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                Productor productor = _context.Productores.Find(identificacion);
                if (productor != null && productor.Estado != "Eliminado")
                {
                    productor.Estado = "Eliminado";
                    _context.Productores.Update(productor);
                    _context.SaveChanges();
                    return $"El productor se ha eliminado.";
                }
                return "El productor no fue encontrado";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
        public string ModificarEstado(Productor productorNuevo)
        {
            try
            {
                Productor productor = _context.Productores.Find(productorNuevo.Identificacion);
                Usuario usuario = _context.Usuarios.Find(productorNuevo.NombreUsuario);
                if ((productor != null && usuario != null) && (productor.Estado != "Eliminado"))
                {
                    productor.Estado = productorNuevo.Estado;
                    usuario.Estado = productorNuevo.Estado;
                    _context.Productores.Update(productor);
                    _context.Usuarios.Update(usuario);
                    _context.SaveChanges();
                    return $"El productor se ha aceptado.";
                }
                return "El productor no fue encontrado";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }
    public class ConsultarProductorResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Productor> Productores;

        public ConsultarProductorResponse(List<Productor> objetos)
        {
            Error = false;
            this.Productores = objetos;

        }

        public ConsultarProductorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
    public class GuardarProductorResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Productor Productor { get; set; }
        public GuardarProductorResponse(Productor producto)
        {
            Error = false;
            Productor = producto;
        }
        public GuardarProductorResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class BuscarProductorxIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Productor Productor;

        public BuscarProductorxIdResponse(Productor producto)
        {
            Error = false;
            this.Productor = producto;
        }

        public BuscarProductorxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}