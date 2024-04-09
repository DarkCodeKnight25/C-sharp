using WEB_API_DAVIDVEGA_EC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_DAVIDVEGA_EC2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly LifeSureContext BD;
        public CategoriasController(LifeSureContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Categoria> ListadeCategorias()
        {
            return BD.Categoria.ToList();
        }

        [HttpPost()]
        public IActionResult CreateCategory([FromBody] Categoria pcategoria)
        {
            if (ModelState.IsValid)
            {
                BD.Categoria.Add(pcategoria);
                BD.SaveChanges();

                return new CreatedAtRouteResult("CategoriaCreada", new
                {
                    id = pcategoria.CategoriaId
                }, pcategoria);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarCategoria([FromBody] Categoria pcategoria, int id)
        {
            if (pcategoria.CategoriaId != id)
            {
                return BadRequest();
            }
            BD.Entry(pcategoria).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCategoria(int id)
        {
            var categoria = BD.Categoria.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            BD.Categoria.Remove(categoria);
            BD.SaveChanges();

            return Ok(categoria);
        }
    }
}
