using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static seynekun.Models.ControlModel;
using Microsoft.AspNetCore.Authorization;
using Logica;
using Datos;

namespace seynekun.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ControlController : ControllerBase
    {
        private readonly ServicioControl servicioControl;
        public ControlController(SeynekunContext context)
        {
            servicioControl = new ServicioControl(context);
        }

        // POST: api/Control
        [HttpPost]
        public ActionResult<ControlViewModel> Post(ControlInputModel controlInput)
        {
            Control control = MapToControl(controlInput);
            var response = servicioControl.Guardar(control);
            if (response.Error)
            {
                ModelState.AddModelError("Error al registrar control", response.Mensaje);
                var detallesProblema = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(detallesProblema);
            }
            return Ok(response.Control);
        }
        private Control MapToControl(ControlInputModel controlInput)
        {
            Control control = new Control
            {
                TipoControl = controlInput.TipoControl,
                Descripcion = controlInput.Descripcion,
                FechaInicio = controlInput.FechaInicio,
                FechaFinal = controlInput.FechaFinal,
                Observacion = controlInput.Observacion,
            };
            return control;
        }

        // GET: api/Control
        [HttpGet]
        public IEnumerable<ControlViewModel> Gets()
        {
            var response = servicioControl.Consultar().Controles.Select(c => new ControlViewModel(c));
            return response;
        }

        [HttpGet("{codigo}")]
        public ActionResult<ControlViewModel> Get(string codigo)
        {
            Control control = servicioControl.Buscar(codigo).Control;
            if (control == null) return NotFound();
            var controlViewModel = new ControlViewModel(control);
            return controlViewModel;
        }
    }
}
