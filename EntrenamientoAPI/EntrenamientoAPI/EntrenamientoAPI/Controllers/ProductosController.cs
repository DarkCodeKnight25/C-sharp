
using EntrenamientoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntrenamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly TiendaVirtualDbContext BD;

        public ProductosController(TiendaVirtualDbContext context)
        {
            BD = context;
        }

        //Get. /Api/productos
        [HttpGet]
        public IEnumerable<Producto> productos()
        {
            return BD.Productos.ToList();
        }

        //Get. /api/productos/destacados
        [Route("destacados")]
        [HttpGet]
        public IEnumerable<Producto> ProductosDestacados()
        {
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = (from p in BD.Productos
                              where p.Destacado == true && p.Activo == true
                              select p).ToList();

            return listaProductos;
        }

        //Get. /api/productos/porcategoria/2
        //[Route("por categoria/{id}")]
        [HttpGet("por categoria/{id}")]
        public IEnumerable<Producto> ProductosPorCategoria(int id)
        {
            List<Producto> listaProductos = new List<Producto>();

            listaProductos = (from p in BD.Productos
                              where p.IdCategoria == id && p.Activo == true
                              select p).ToList();

            return listaProductos;
        }

        //Get. /api/productos/producto/2
        //[route("producto/{id}")]
        [HttpGet("NombreCat/{id}")]
        public IActionResult Producto(int id)
        {
            var mproducto = (from p in BD.Productos
                             where p.Id == id
                             select new Producto
                             {
                                 Id = p.Id,
                                 IdCategoria = p.IdCategoria,
                                 IdMarca = p.IdMarca,
                                 Nombre = p.Nombre,
                                 Descripcion = p.Descripcion,
                                 Precio = p.Precio,
                                 Url = p.Url,
                                 Destacado = p.Destacado,
                                 Activo = p.Activo,
                                 IdCategoriaNavigation = p.IdCategoriaNavigation,
                            IdMarcaNavigation = p.IdMarcaNavigation,
                             }).ToList().FirstOrDefault();

            if(mproducto == null)
            {
                return NotFound();
            }

            return Ok(mproducto);
        }

        private Categorium ObtenerCategoriaStatic(int? pIdCategoria)
        {
            Categorium cat = new Categorium();
            using (TiendaVirtualDbContext BD1 = new TiendaVirtualDbContext())
            {
                cat = (from c in BD1.Categoria
                       where c.Id == pIdCategoria
                       select c
                       ).ToList().First();  
            }

            return cat;
        }

        private Marca ObtenerMarcaStatic(int? pIdMarca)
        {
            Marca mar = new Marca();

            using (TiendaVirtualDbContext BD2 = new TiendaVirtualDbContext())
            {
                mar = (from m in BD2.Marcas
                       where m.Id == pIdMarca
                       select m
                       ).ToList().First();
            }
            return mar;
        }
    }
}

