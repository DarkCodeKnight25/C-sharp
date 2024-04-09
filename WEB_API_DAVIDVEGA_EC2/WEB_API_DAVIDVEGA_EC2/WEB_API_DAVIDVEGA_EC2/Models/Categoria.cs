using System;
using System.Collections.Generic;

namespace WEB_API_DAVIDVEGA_EC2.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
