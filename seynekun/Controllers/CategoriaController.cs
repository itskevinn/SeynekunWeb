using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using seynekun.Models;
using Logica;
using static seynekun.Models.CategoriaModel;

namespace seynekun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ServicioCategoria servicioCategoria;
        private readonly IConfiguration configuration1;
       
        public CategoriaController(IConfiguration configuration)
        {
            this.configuration1 = configuration;
            string cadenaDeConexión = this.configuration1["ConnectionStrings:DefaultConnection"];
            servicioCategoria = new ServicioCategoria(cadenaDeConexión);
        }

        // POST: api/Categoria
        [HttpPost]
        public ActionResult<CategoriaViewModel> Post(CategoriaInputModel categoriaInputModel)
        {
            Categoria categoria = MapToCategoria(categoriaInputModel);
            var response = servicioCategoria.Guardar(categoria);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Categoria);
        }

        private Categoria MapToCategoria(CategoriaInputModel categoriaInputModel)
        {
            var categoria = new Categoria
            {
                Detalle = categoriaInputModel.Detalle,
                Nombre = categoriaInputModel.Nombre,
                Estado = "Activo",
            };
            return categoria;
        }

        // GET: api/categoria
        [HttpGet]
        public IEnumerable<CategoriaViewModel> Gets()
        {
            var response = servicioCategoria.Consultar().Categorias.Select(b => new CategoriaViewModel(b));
            return response;
        }


        [HttpGet("{nombre}")]
        public ActionResult<CategoriaViewModel> Get(string nombre)
        {
            var categoria = servicioCategoria.BuscarxId(nombre).Categoria;
            if (categoria == null) return NotFound();
            var categoriaViewModel = new CategoriaViewModel(categoria);
            return categoriaViewModel;
        }
        [HttpPut("{nombre}")]
        public ActionResult<string> Put(Categoria categoria, string nombre)
        {
            var id = servicioCategoria.BuscarxId(nombre);
            if (id == null)
            {
                return BadRequest("Categoria no econtrada");
            }
            else
            {
                var mensaje = servicioCategoria.Modificar(categoria);
                return Ok(mensaje);
            }
        }
        [HttpDelete("{nombre}")]
        public ActionResult<string> Delete(string nombre)
        {
            string mensaje = servicioCategoria.Eliminar(nombre);
            return Ok(mensaje);
        }
    }

}