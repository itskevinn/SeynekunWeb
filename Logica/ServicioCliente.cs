using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using Entity;

namespace Logica
{
    public class ServicioCliente
    {

        private readonly SeynekunContext _context;

        public ServicioCliente(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                cliente.Estado = "Activo";
                var clienteBuscado = _context.Clientes.Find(cliente.Identificacion);
                if (clienteBuscado != null)
                {
                    return new GuardarClienteResponse("!Cliente ya registrado!");
                }
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarClienteResponse(e.Message);
            }
        }

        public List<Cliente> Consultar()
        {
            var clientes = _context.Clientes.Where(c => c.Estado.Equals("Activo") || c.Estado.Equals("Modificado")).ToList();
            return clientes;
        }


        public BuscarClientexIdResponse BuscarxId(string identificacion)
        {
            var cliente = _context.Clientes.Find(identificacion);
            if (cliente != null && cliente.Estado != "Eliminado")
            {
                return new BuscarClientexIdResponse(cliente);
            }
            return new BuscarClientexIdResponse("Cliente no encontrado");
        }

        public string Modificar(Cliente clienteNuevo)
        {
            try
            {
                var clienteViejo = _context.Clientes.Find(clienteNuevo.Identificacion);
                if (clienteViejo != null && clienteViejo.Estado != "Eliminado")
                {
                    clienteViejo.TipoIdentificacion = clienteNuevo.TipoIdentificacion;
                    clienteViejo.Identificacion = clienteNuevo.Identificacion;
                    clienteViejo.Nombre = clienteNuevo.Nombre;
                    clienteViejo.NumeroTelefono = clienteNuevo.NumeroTelefono;
                    clienteViejo.NumeroTelefono2 = clienteNuevo.NumeroTelefono2;
                    clienteViejo.Municipio = clienteNuevo.Municipio;
                    clienteViejo.Email = clienteNuevo.Email;
                    clienteViejo.Direccion = clienteNuevo.Direccion;
                    clienteViejo.Departamento = clienteNuevo.Departamento;
                    clienteViejo.Barrio = clienteNuevo.Barrio;
                    clienteViejo.Apellido = clienteNuevo.Apellido;
                    clienteViejo.Estado = clienteNuevo.Estado;
                    _context.Update(clienteViejo);
                    _context.SaveChanges();
                    return "El cliente se actualizó";
                }
                else
                {
                    return $"No se encontró cliente con la identificacion: {clienteNuevo.Identificacion} ingresada";
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

                Cliente cliente = _context.Clientes.Find(identificacion);
                if (cliente != null && cliente.Estado != "Eliminado")
                {
                    cliente.Estado = "Eliminado";
                    _context.Update(cliente);
                    _context.SaveChanges();
                    return $"El cliente {cliente.Nombre} {cliente.Apellido} se ha eliminado.";
                }
                return "No se encontró cliente con la cédula ingresada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }

    public class GuardarClienteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente { get; set; }

        public GuardarClienteResponse(Cliente cliente)
        {
            Error = false;
            this.Cliente = cliente;
        }

        public GuardarClienteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarClienteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Cliente> Clientes;

        public ConsultarClienteResponse(List<Cliente> clientes)
        {
            Error = false;
            this.Clientes = clientes;
        }

        public ConsultarClienteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarClientexIdResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente Cliente;

        public BuscarClientexIdResponse(Cliente cliente)
        {
            Error = false;
            this.Cliente = cliente;
        }

        public BuscarClientexIdResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
