using EntrenamientoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntrenamientoAPI.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly TiendaVirtualDbContext BD;
        public UsuarioController(TiendaVirtualDbContext context)
        { 
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Usuario> ListadeUsuarios()
        {
            return BD.Usuarios.ToList();
        }

        [HttpPost()]
        public IActionResult CreateUser([FromBody] Usuario pusuario)
        {
            if(ModelState.IsValid) 
            {
                BD.Usuarios.Add(pusuario);
                BD.SaveChanges();

                return new CreatedAtRouteResult("UsuarioCreado", new {
                    id = pusuario.Id 
                }, pusuario);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarUsuario([FromBody] Usuario pusuario, int id)
        {
            if(pusuario.Id!= id)
            {
                return BadRequest();
            }
            BD.Entry(pusuario).State=EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = BD.Usuarios.FirstOrDefault( u => u.Id==id);
            if(usuario == null)
            {
                return NotFound();
            }

            BD.Usuarios.Remove(usuario);
            BD.SaveChanges();

            return Ok(usuario);
        }
    }
}
