using ClinicaVeterinariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : Controller
    {
        private readonly ExamenFinalContext BD;
        public MascotaController(ExamenFinalContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Mascota> ListadeMascotas()
        {
            return BD.Mascotas.ToList();
        }

        [HttpPost()]
        public IActionResult CrearMascotas([FromBody] Mascota pmascota)
        {
            if (ModelState.IsValid)
            {
                BD.Mascotas.Add(pmascota);
                BD.SaveChanges();

                return new CreatedAtRouteResult("MascotaCreada", new
                {
                    id = pmascota.Idmascota
                }, pmascota);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarMascota([FromBody] Mascota pmascota, int id)
        {
            if (pmascota.Idmascota != id)
            {
                return BadRequest();
            }
            BD.Entry(pmascota).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarMascota(int id)
        {
            var mascotas = BD.Mascotas.FirstOrDefault(u => u.Idmascota == id);
            if (mascotas == null)
            {
                return NotFound();
            }

            BD.Mascotas.Remove(mascotas);
            BD.SaveChanges();

            return Ok(mascotas);
        }
    }
}
