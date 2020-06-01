using System.Collections.Generic;
using System.Linq;
using Entity;
using System;
using Datos;

namespace Logica
{
    public class ServicioDocumento
    {
        private readonly SeynekunContext _context;
        public ServicioDocumento(SeynekunContext context)
        {
            _context = context;
        }

        public GuardarDocumentoResponse Guardar(Documento documento)
        {
            try
            {
                Documento documentoBuscado = _context.Documentos.Find(documento.Id);
                if(documentoBuscado != null)
                {
                    return new GuardarDocumentoResponse("Id de documento ya registrada");
                }
                documento.Estado = "Activo";
                _context.Documentos.Add(documento);
                _context.SaveChanges();
                return new GuardarDocumentoResponse(documento);
            }
            catch (Exception e)
            {
                return new GuardarDocumentoResponse(e.Message);
            }
        }

        public ConsultarDocumentosResponse Consultar()
        {
            try
            {
                List<Documento> documentos = _context.Documentos.ToList();
                return new ConsultarDocumentosResponse(documentos);
            }
            catch (Exception e)
            {
                return new ConsultarDocumentosResponse(e.Message);
            }
        }

        public BuscarDocumentoResponse BuscarDocumento(string id)
        {
            try
            {
                Documento documento = _context.Documentos.Find(id);
                if(documento == null)
                {
                    return new BuscarDocumentoResponse("Documento no registrado");
                }
                return new BuscarDocumentoResponse(documento);
            }
            catch (Exception e)
            {
                return new BuscarDocumentoResponse(e.Message);
            }
        }

        public string Modificar(Documento documento)
        {
            try
            {
                var documentoViejo = _context.Documentos.Find(documento.Id);
                if (documentoViejo != null)
                {
                    documentoViejo.Nombre = documento.Nombre;
                    documentoViejo.Enlace = documento.Enlace;
                    documentoViejo.Descripcion = documento.Descripcion;
                    documentoViejo.Estado = "Modificado";
                    _context.Documentos.Update(documentoViejo);
                    _context.SaveChanges();
                    return ($"El Documento con id: {documentoViejo.Id} se ha modificado satisfactoriamente.");
                }
                return $"No se encontró el documento con id: {documento.Id}";
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
                Documento documento = _context.Documentos.Find(id);
                if (documento != null)
                {
                    documento.Estado = "Eliminado";
                    _context.Documentos.Update(documento);
                    _context.SaveChanges();
                    return $"El Documento con id: {documento.Id} se ha eliminado.";
                }
                return $"No se encontró el documento con id: {id}";
            }
            catch (Exception e)
            {
                return $"Error de la aplicación: {e.Message} ";
            }
        }
    }

    public class GuardarDocumentoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Documento Documento { get; set; }

        public GuardarDocumentoResponse(Documento documento)
        {
            Error = false;
            Documento = documento;
        }

        public GuardarDocumentoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultarDocumentosResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Documento> Documentos;

        public ConsultarDocumentosResponse(List<Documento> documentos)
        {
            Error = false;
            Documentos = documentos;
        }

        public ConsultarDocumentosResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }

    public class BuscarDocumentoResponse
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Documento Documento;

        public BuscarDocumentoResponse(Documento documento)
        {
            Error = false;
            Documento = documento;
        }

        public BuscarDocumentoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
