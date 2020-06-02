using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Logica;
using Datos;
using seynekun.Models;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly ServicioDocumento servicioDocumento;
        public DocumentoController(SeynekunContext context)
        {
            servicioDocumento = new ServicioDocumento(context);
        }

        // POST: api/Documento
        [HttpPost]
        public ActionResult<DocumentoViewModel> Post(DocumentoInputModel documentoInputModel)
        {
            Documento documento = MapToDocumento(documentoInputModel);
            var response = servicioDocumento.Guardar(documento);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Documento);
        }
        private Documento MapToDocumento(DocumentoInputModel documentoInputModel)
        {
            var documento = new Documento{
                Id = documentoInputModel.Id,
                IdInsumo = documentoInputModel.IdInsumo,
                Nombre = documentoInputModel.Nombre,
                Enlace = documentoInputModel.Enlace,
                Descripcion = documentoInputModel.Descripcion
            };
            return documento;
        }

        // GET: api/Documento
        [HttpGet]
        public IEnumerable<DocumentoViewModel> Gets()
        {
            var response = servicioDocumento.Consultar().Documentos.ConvertAll(d => new DocumentoViewModel(d));
            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<DocumentoViewModel> Get(string id)
        {
            var response = servicioDocumento.BuscarDocumento(id);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            var documento = new DocumentoViewModel(response.Documento);
            return documento;
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(Documento documento)
        {
            var response = servicioDocumento.BuscarDocumento(documento.Id);
            if (response.Documento == null)
            {
                return BadRequest("Documento no econtrado");
            }
            else
            {
                var mensaje = servicioDocumento.Modificar(documento);
                return Ok(mensaje);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            string mensaje = servicioDocumento.Eliminar(id);
            return Ok(mensaje);
        }
    }
}
