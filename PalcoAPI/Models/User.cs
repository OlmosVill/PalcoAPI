using System;
using System.Collections.Generic;

namespace PalcoAPI.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
