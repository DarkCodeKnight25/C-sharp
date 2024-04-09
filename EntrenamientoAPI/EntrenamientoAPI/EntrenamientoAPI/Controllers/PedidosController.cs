using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntrenamientoAPI.Models;

namespace EntrenamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly TiendaVirtualDbContext BD;

        public PedidosController(TiendaVirtualDbContext context)
        {
            BD = context;   
        }

        //gET. /api/pedidos/2
        [HttpGet("{id}", Name = "PedidoCreado")]
        public IActionResult Pedido(int id)
        {
            var mPedido = (from p in BD.Pedidos
                           where p.Id == id
                           select new Pedido
                      { 
                          Id = p.Id,
                          IdCliente = p.IdCliente,
                          IdTarjeta = p.IdTarjeta,
                          FechaHora = p.FechaHora,
                          Estado = p.Estado,
                          Total = p.Total,
                          IdClienteNavigation = p.IdClienteNavigation,
                          IdTarjetaNavigation = p.IdTarjetaNavigation    
                      }).ToList().FirstOrDefault();
            if(mPedido == null)
            {
                return NotFound();
            }
            return Ok(mPedido);
        }

        //Post. /api/pedidos
        [HttpPost()]
        public IActionResult CrearPedido([FromBody] Pedido pPedido)
        {
            //Pedido pPedido = new Pedido();
            //pPedido.Estado = "En proceso";
            //pPedido.Total = 0;

            if(ModelState.IsValid)
            {
                BD.Pedidos.Add(pPedido);
                BD.SaveChanges();

                return new CreatedAtRouteResult("PedidoCreado", new { id = pPedido.Id }, pPedido);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPedido([FromBody] Pedido pPedido, int id)
        {
            if(pPedido.Id != id)
            {
                return BadRequest();
            }

            BD.Entry(pPedido).State = EntityState.Modified;
            BD.SaveChanges();

            return Ok();
        }

        private Cliente ObtenerCliente(int pIdCliente)
        {
            Cliente cli = new Cliente();

            using (TiendaVirtualDbContext BD1 = new TiendaVirtualDbContext())
            {
                cli = (from c in BD1.Clientes
                       where c.Id == pIdCliente
                       select c
                       ).ToList().First();
            }
            return cli;
        }

        private Tarjeta ObtenerTarjeta(int pIdTarjeta)
        {
            Tarjeta tar = new Tarjeta();

            using (TiendaVirtualDbContext BD2 = new TiendaVirtualDbContext())
            {
                tar = (from t in BD2.Tarjeta
                       where t.Id == pIdTarjeta
                       select t
                       ).ToList().First();  
            }

            return tar;
        }
    }
}
 