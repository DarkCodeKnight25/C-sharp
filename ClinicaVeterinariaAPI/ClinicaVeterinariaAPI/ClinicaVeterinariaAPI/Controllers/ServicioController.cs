using ClinicaVeterinariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : Controller
    {
        private readonly ExamenFinalContext BD;
        public ServicioController(ExamenFinalContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Servicio> ListadeServicios()
        {
            return BD.Servicios.ToList();
        }

        [HttpPost()]
        public IActionResult CrearServicio([FromBody] Servicio pservicio)
        {
            if (ModelState.IsValid)
            {
                BD.Servicios.Add(pservicio);
                BD.SaveChanges();

                return new CreatedAtRouteResult("ServicioCreado", new
                {
                    id = pservicio.Idservicio
                }, pservicio);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarServicio([FromBody] Servicio pservicio, int id)
        {
            if (pservicio.Idservicio != id)
            {
                return BadRequest();
            }
            BD.Entry(pservicio).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarServicio(int id)
        {
            var servicio = BD.Servicios.FirstOrDefault(u => u.Idservicio == id);
            if (servicio == null)
            {
                return NotFound();
            }

            BD.Servicios.Remove(servicio);
            BD.SaveChanges();

            return Ok(servicio);
        }
    }
}
