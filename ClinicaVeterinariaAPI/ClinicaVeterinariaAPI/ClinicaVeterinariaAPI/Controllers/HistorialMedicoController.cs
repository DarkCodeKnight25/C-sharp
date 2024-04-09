using ClinicaVeterinariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialMedicoController : Controller
    {
        private readonly ExamenFinalContext BD;
        public HistorialMedicoController(ExamenFinalContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<HistorialMedico> ListadeHistoriasMedicas()
        {
            return BD.HistorialMedicos.ToList();
        }

        [HttpPost()]
        public IActionResult CrearHistorialMedico([FromBody] HistorialMedico phistoriam)
        {
            if (ModelState.IsValid)
            {
                BD.HistorialMedicos.Add(phistoriam);
                BD.SaveChanges();

                return new CreatedAtRouteResult("HistorialMedicoCreada", new
                {
                    id = phistoriam.Idhistorial
                }, phistoriam);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarHistorialMedico([FromBody] HistorialMedico phistoriam, int id)
        {
            if (phistoriam.Idhistorial != id)
            {
                return BadRequest();
            }
            BD.Entry(phistoriam).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarHistorialMedico(int id)
        {
            var historiam = BD.HistorialMedicos.FirstOrDefault(u => u.Idhistorial == id);
            if (historiam == null)
            {
                return NotFound();
            }

            BD.HistorialMedicos.Remove(historiam);
            BD.SaveChanges();

            return Ok(historiam);
        }
    }
}
