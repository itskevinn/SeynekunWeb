using System;
using System.Collections.Generic;
using Datos;

using Entity;

namespace Logica
{
    public class ServicioDeLote
    {
        private readonly GestionadorDeConexión _conexión;
        private readonly RepositorioDeLote _repositorio;
        public ServicioDeLote(string cadenaDeConexión)
        {
            _conexión = new GestionadorDeConexión(cadenaDeConexión);
            _repositorio = new RepositorioDeLote(_conexión);
        }

        public GuardarLoteResponse Guardar(Lote lote)
        {            
            try
            {                                          
                _conexión.Abrir();                
                _repositorio.Guardar(lote);
                _conexión.Cerrar();
                return new GuardarLoteResponse(lote);
            }
            catch (Exception e)
            {
                return new GuardarLoteResponse(e.Message);
            }                        
        }        

        public ConsultarLotesResponse ConsultarLotes()
        {
            
            try
            {
                _conexión.Abrir();
                List<Lote> lotes = _repositorio.ConsultarTodos();
                _conexión.Cerrar();
                return new ConsultarLotesResponse(lotes);
            }
            catch (Exception e)
            {
                return new ConsultarLotesResponse(e.Message);
            }
        }        
        public class GuardarLoteResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Lote Lote { get; set; }
            public GuardarLoteResponse(Lote lote)
            {
                Error = false;
                Lote = lote;
            }
            public GuardarLoteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }
        public class ConsultarLotesResponse
        {
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Lote> Lotes = new List<Lote>();
            public ConsultarLotesResponse(List<Lote> lotes)
            {
                Error = false;
                Lotes = lotes;
            }
            public ConsultarLotesResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
        }

    }
}