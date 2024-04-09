using WEB_API_DAVIDVEGA_EC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEB_API_DAVIDVEGA_EC2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly LifeSureContext BD;
        public ProductosController(LifeSureContext context)
        {
            BD = context;
        }


        [HttpGet]
        public IEnumerable<Producto> listadeProductos()
        {
            return BD.Productos.ToList();
        }

        [HttpPost()]
        public IActionResult CreateProduct([FromBody] Producto pProducto)
        {
            if (ModelState.IsValid)
            {
                BD.Productos.Add(pProducto);
                BD.SaveChanges();

                return new CreatedAtRouteResult("UsuarioCreado", new
                {
                    id = pProducto.ProductoId
                }, pProducto);
            }
            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult ModificarUsuario([FromBody] Producto pProducto, int id)
        {
            if (pProducto.ProductoId != id)
            {
                return BadRequest();
            }
            BD.Entry(pProducto).State = EntityState.Modified;
            BD.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var producto = BD.Productos.FirstOrDefault(u => u.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            BD.Productos.Remove(producto);
            BD.SaveChanges();

            return Ok(producto);
        }
    }
}
