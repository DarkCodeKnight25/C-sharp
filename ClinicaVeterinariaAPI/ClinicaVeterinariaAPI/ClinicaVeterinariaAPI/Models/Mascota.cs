using System;
using System.Collections.Generic;

namespace ClinicaVeterinariaAPI.Models;

public partial class Mascota
{
    public int Idmascota { get; set; }

    public string? Nombre { get; set; }

    public int? Idcliente { get; set; }

    public string? Especie { get; set; }

    public string? Raza { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Cliente? IdclienteNavigation { get; set; }
}
