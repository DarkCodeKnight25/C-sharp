using WEB_API_DAVIDVEGA_EC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_DAVIDVEGA_EC2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : Controller
    {
        private readonly LifeSureContext BD;
        public MarcasController(LifeSureContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Marca> ListadeMarcas()
        {
            return BD.Marcas.ToList();
        }

        [HttpPost()]
        public IActionResult CreateMarca([FromBody] Marca pmarca)
        {
            if (ModelState.IsValid)
            {
                BD.Marcas.Add(pmarca);
                BD.SaveChanges();

                return new CreatedAtRouteResult("MarcaCreada", new
                {
                    id = pmarca.MarcaId
                }, pmarca);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarMarca([FromBody] Marca pmarca, int id)
        {
            if (pmarca.MarcaId != id)
            {
                return BadRequest();
            }
            BD.Entry(pmarca).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMarca(int id)
        {
                var marca = BD.Marcas.FirstOrDefault(u => u.MarcaId == id);
                if (marca == null)
                {
                    return NotFound(); // 404 Not Found si la marca no existe
                }

                BD.Marcas.Remove(marca);
                BD.SaveChanges();

                return NoContent(); // 204 No Content después de eliminar con éxito
            //var marca = BD.Marcas.FirstOrDefault(u => u.MarcaId == id);
            //if (marca == null)
            //{
            //    return NotFound();
            //}

            //BD.Marcas.Remove(marca);
            //BD.SaveChanges();

            //return Ok(marca);
        }
    }
}
