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
        public GuardarProductorResponse Guardar(Productor productor)
        {
            try
            {
                var productorBuscado = _context.Productores.Find(productor.Identificacion);
                var usuarioBuscado = _context.Usuarios.Find(productor.NombreUsuario);
                if (productorBuscado == null && usuarioBuscado == null)
                {
                    _context.Productores.Add(productor);
                    RegistrarUsuario(productor);
                    _context.SaveChanges();
                    return new GuardarProductorResponse(productor);
                }
                if (productorBuscado != null)
                {
                    return new GuardarProductorResponse("¡Productor ya registrado!");
                }
                return new GuardarProductorResponse("¡El nombre de usuario ya está en uso!");
            }
            catch (Exception e)
            {
                return new GuardarProductorResponse(e.Message);
            }
        }
        private void RegistrarUsuario(Productor productor)
        {
            Usuario usuario = new Usuario();
            usuario.NombreUsuario = productor.NombreUsuario;
            usuario.Nombre = productor.Nombre;
            usuario.Apellido = productor.Apellido;
            usuario.Contrasena = productor.Contrasena;
            usuario.Email = productor.Email;
            usuario.Estado = productor.Estado;
            usuario.NumeroTelefono = productor.NumeroTelefono;
            usuario.Tipo = "Productor";
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        public List<Productor> Consultar()
        {
            List<Productor> productors = _context.Productores.ToList();
            return productors;
        }
        public BuscarProductorxIdResponse BuscarxId(string identificacion)
        {
            var productor = _context.Productores.Find(identificacion);
            if (productor != null && productor.Estado != "Eliminado")
            {
                return new BuscarProductorxIdResponse(productor);
            }
            return new BuscarProductorxIdResponse("productorr no encontrado");
        }
        public string Modificar(Productor productorNueva)
        {
            try
            {
                var productorVieja = _context.Productores.Find(productorNueva.Identificacion);
                if (productorVieja != null && productorVieja.Estado != "Eliminado")
                {
                    productorVieja.Nombre = productorNueva.Nombre;
                    productorVieja.Apellido = productorNueva.Apellido;
                    productorVieja.Estado = productorNueva.Estado;
                    productorVieja.AfiliacionSalud = productorNueva.AfiliacionSalud;
                    productorVieja.NombrePredio = productorNueva.NombrePredio;
                    productorVieja.NombreUsuario = productorNueva.NombreUsuario;
                    productorVieja.NumeroTelefono = productorNueva.NumeroTelefono;
                    productorVieja.Municipio = productorNueva.Municipio;
                    productorVieja.Vereda = productorNueva.Vereda;
                    productorVieja.TipoIdentificacion = productorNueva.TipoIdentificacion;
                    productorVieja.CedulaCafetera = productorNueva.CedulaCafetera;
                    productorVieja.CodigoFinca = productorNueva.CodigoFinca;
                    productorVieja.CodigoSica = productorNueva.CodigoSica;
                    productorVieja.Contrasena = productorNueva.Contrasena;
                    productorVieja.Email = productorNueva.Email;
                    _context.Productores.Update(productorNueva);
                    _context.SaveChanges();
                    return ($"El productorr se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró registro del productorr solicitado";
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
                Productor productorr = _context.Productores.Find(identificacion);
                if (productorr != null && productorr.Estado != "Eliminado")
                {
                    productorr.Estado = "Eliminado";
                    _context.Productores.Update(productorr);
                    _context.SaveChanges();
                    return $"El productorr se ha eliminado.";
                }
                return "El productorr no fue encontrado";
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
        public GuardarProductorResponse(Productor productor)
        {
            Error = false;
            Productor = productor;
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

        public BuscarProductorxIdResponse(Productor productor)
        {
            Error = false;
            this.Productor = productor;
        }

        public BuscarProductorxIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}