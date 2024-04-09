using System;
using System.Collections.Generic;

namespace ClinicaVeterinariaAPI.Models;

public partial class Servicio
{
    public int Idservicio { get; set; }

    public string? NombreServicio { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }
}
