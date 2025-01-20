using System;
using System.Collections.Generic;

namespace PalcoAPI.ErikasModels;

public partial class Mensajito
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? Person { get; set; }

    public string? CreatedAt { get; set; }
}
