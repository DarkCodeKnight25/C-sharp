using System;
using System.Collections.Generic;

namespace ClinicaVeterinariaAPI.Models;

public partial class Cita
{
    public int Idcita { get; set; }

    public int? Idmascota { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? Hora { get; set; }

    public string? MotivoConsulta { get; set; }

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual Mascota? IdmascotaNavigation { get; set; }
}
