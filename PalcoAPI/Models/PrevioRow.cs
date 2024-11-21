using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PalcoAPI.Models;

public partial class PrevioRow
{
    public int IdPrevioRow { get; set; }

    public int? NoPiezas { get; set; }

    public decimal? Kilos { get; set; }

    public string? Descripcion { get; set; }

    public string? Origen { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public string? NoSerie { get; set; }

    public string? NoFoto { get; set; }

    public string? NoParte { get; set; }

    public string? FraccionArancelaria { get; set; }

    public string IdGuiaHouse { get; set; } = null!;

    [JsonIgnore]
    public virtual Previo? IdGuiaHouseNavigation { get; set; }
}
