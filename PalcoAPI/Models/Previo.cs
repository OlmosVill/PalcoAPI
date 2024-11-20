using System;
using System.Collections.Generic;

namespace PalcoAPI.Models;

public partial class Previo
{
    public string GuiaHouse { get; set; } = null!;

    public string? GuiaMaster { get; set; }

    public string? Cliente { get; set; }

    public decimal? PesoBruto { get; set; }

    public string? NoDeBultos { get; set; }

    public DateTime? FechaEntrada { get; set; }

    public DateTime? FechaReconocimientoPrevio { get; set; }

    public string? RecintoFiscal { get; set; }
}
