using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entity;

using Logica;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using seynekun.Models;
namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly ServicioDeLote _servicioDeLote;
        public IConfiguration Configuration { get; }
        public LoteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string cadenaDeConexión = Configuration["ConnectionStrings:DefaultConnection"];
            _servicioDeLote = new ServicioDeLote(cadenaDeConexión);
        }

        // GET: api/Lote
        [HttpGet]
        public IEnumerable<LoteModel> Get()
        {
            var respuesta = _servicioDeLote.ConsultarLotes().Lotes.Select(p => new LoteModel());
            return respuesta;
        }

        // POST: api/Lote
        [HttpPost]
        public ActionResult<LoteModel> Post(LoteModel loteModel)
        {
            Lote Lote = MapearLote(loteModel);
            var respuesta = _servicioDeLote.Guardar(Lote);
            if (respuesta.Error)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.Lote);
        }
        private Lote MapearLote(LoteModel loteInput)
        {
            var lote = new Lote
            {
                NumeroLote = loteInput.NumeroLote,
                Variedad = loteInput.Variedad,
                NumeroArbol = loteInput.NumeroArbol,
                SistemaRenovacion = loteInput.SistemaRenovacion,                
          FechaSiembra =  loteInput.FechaSiembra,
Cultivo = loteInput.Cultivo,
EpocaCosecha = loteInput.EpocaCosecha,
EpocaFloriacion = loteInput.EpocaFloriacion,
EstimadoCosecha = loteInput.EstimadoCosecha,
TipoEstimado = loteInput.TipoEstimado,
            };
            return lote;
        }       
    }
}