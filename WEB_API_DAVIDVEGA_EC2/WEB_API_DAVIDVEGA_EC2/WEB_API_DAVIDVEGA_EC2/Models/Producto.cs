using System;
using System.Collections.Generic;

namespace WEB_API_DAVIDVEGA_EC2.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal Precio { get; set; }

    public int? CategoriaId { get; set; }

    public int? MarcaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual Marca? Marca { get; set; }
}
