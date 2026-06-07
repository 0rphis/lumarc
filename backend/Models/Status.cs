using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Status
{
    [Key]
    public int Idstatus { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
