using ClinicaVeterinariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly ExamenFinalContext BD;
        public ClienteController(ExamenFinalContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Cliente> ListadeCliente()
        {
            return BD.Clientes.ToList();
        }

        [HttpPost()]
        public IActionResult CrearCliente([FromBody] Cliente pcliente)
        {
            if (ModelState.IsValid)
            {
                BD.Clientes.Add(pcliente);
                BD.SaveChanges();

                return new CreatedAtRouteResult("ClienteCreado", new
                {
                    id = pcliente.Idcliente
                }, pcliente);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarCliente([FromBody] Cliente pcliente, int id)
        {
            if (pcliente.Idcliente != id)
            {
                return BadRequest();
            }
            BD.Entry(pcliente).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            var cliente = BD.Clientes.FirstOrDefault(u => u.Idcliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            BD.Clientes.Remove(cliente);
            BD.SaveChanges();

            return Ok(cliente);
        }
    }
}
