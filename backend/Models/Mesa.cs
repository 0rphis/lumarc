using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Mesa
{
    [Key]
    public int Idmesa { get; set; }

    public int Capacidade { get; set; }

    public int Numeromesa { get; set; }

    public string? Statusmesa { get; set; }
}
