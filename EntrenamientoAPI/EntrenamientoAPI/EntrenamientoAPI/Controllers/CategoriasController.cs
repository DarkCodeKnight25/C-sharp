using EntrenamientoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntrenamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly TiendaVirtualDbContext BD;

        public CategoriasController(TiendaVirtualDbContext context)
        {
            BD = context;
        }

        [HttpGet]
        public IEnumerable<Categorium> Categorias()
        {
            return BD.Categoria.ToList();
        }

        //Get. /api/categorias/activas
        [Route("activas")]
        [HttpGet]
        public IEnumerable<Categorium> CategoriasActivas()
        {
            List<Categorium> listaCategorias = new List<Categorium>();
            
            listaCategorias = (from c in BD.Categoria
                               where c.Activo == true
                               select c).ToList();

            return listaCategorias;
        }
    }
}
