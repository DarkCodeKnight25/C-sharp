using System;
using System.Collections.Generic;

namespace ClinicaVeterinariaAPI.Models;

public partial class HistorialMedico
{
    public int Idhistorial { get; set; }

    public int? Idcita { get; set; }

    public string? Diagnostico { get; set; }

    public string? Tratamiento { get; set; }

    public virtual Cita? IdcitaNavigation { get; set; }
}
