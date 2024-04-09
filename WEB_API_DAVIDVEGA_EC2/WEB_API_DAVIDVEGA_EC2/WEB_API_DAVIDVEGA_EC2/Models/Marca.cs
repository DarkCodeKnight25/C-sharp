using System;
using System.Collections.Generic;

namespace WEB_API_DAVIDVEGA_EC2.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    public string NombreMarca { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
