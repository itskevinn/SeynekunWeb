using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class ServicioCliente
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioCliente repositorioCliente;

        public ServicioCliente(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            repositorioCliente = new RepositorioCliente(_conexión);
        }

        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                _conexión.Abrir();
                repositorioCliente.Guardar(cliente);
                _conexión.Cerrar();
                return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarClienteResponse(e.Message);
            }
        }

        public ConsultarClienteResponse Consultar()
        {
            try
            {
                _conexión.Abrir();
                List<Cliente> clientes = repositorioCliente.Consultar();
                _conexión.Cerrar();
                return new ConsultarClienteResponse(clientes);
            }
            catch (Exception e)
            {
                return new ConsultarClienteResponse(e.Message);
            }
        }

        public BuscarClientexIdResponse BuscarxId(string identificacion)
        {
            try
            {
                _conexión.Abrir();
                Cliente cliente = repositorioCliente.BuscarxId(identificacion);
                _conexión.Cerrar();
                return new BuscarClientexIdResponse(cliente);
            }
            catch (Exception e)
            {
                return new BuscarClientexIdResponse(e.Message);
            }
        }

        public string Modificar(Cliente clienteNuevo)
        {
            try
            {
                _conexión.Abrir();
                var clienteViejo = repositorioCliente.BuscarxId(clienteNuevo.Identificacion);
                if (clienteViejo != null)
                {
                    repositorioCliente.ModificarEstado(clienteViejo.Identificacion, "Modificado");
                    repositorioCliente.Modificar(clienteNuevo);
                    _conexión.Cerrar();
                    return ($"El cliente {clienteNuevo.Nombre} se ha modificado satisfactoriamente.");
                }
                else
                {
                    return "No se encontró cliente con la cédula ingresada";
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
                Cliente cliente = repositorioCliente.BuscarxId(identificacion);
                if (cliente != null)
                {
                    repositorioCliente.ModificarEstado(identificacion, "Eliminado");
                    return $"El cliente {cliente.Nombre} {cliente.Apellido} se ha eliminado.";
                }
                _conexión.Cerrar();
                return "No se encontró cliente con la cédula ingresada";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }

    }

    public class ConsultarClienteResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Cliente> objetos;

        public ConsultarClienteResponse(List<Cliente> objetos)
        {
            Error = false;
            this.objetos = objetos;

        }

        public ConsultarClienteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
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
            Cliente = cliente;
        }
        public GuardarClienteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
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

