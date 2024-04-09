using ClinicaVeterinariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : Controller
    {
        private readonly ExamenFinalContext BD;
        public CitaController(ExamenFinalContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Cita> ListadeCitas()
        {
            return BD.Citas.ToList();
        }

        [HttpPost()]
        public IActionResult CrearCitas([FromBody] Cita pcitas)
        {
            if (ModelState.IsValid)
            {
                BD.Citas.Add(pcitas);
                BD.SaveChanges();

                return new CreatedAtRouteResult("CitaCreada", new
                {
                    id = pcitas.Idcita
                }, pcitas);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarCitas([FromBody] Cita pcitas, int id)
        {
            if (pcitas.Idcita != id)
            {
                return BadRequest();
            }
            BD.Entry(pcitas).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCitas(int id)
        {
            var citas = BD.Citas.FirstOrDefault(u => u.Idcita == id);
            if (citas == null)
            {
                return NotFound();
            }

            BD.Citas.Remove(citas);
            BD.SaveChanges();

            return Ok(citas);
        }
    }
}
