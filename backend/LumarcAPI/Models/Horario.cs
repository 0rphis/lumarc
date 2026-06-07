using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Horario
{
    [Key]
    public int Idhorario { get; set; }

    public TimeOnly Horarioinicio { get; set; }

    public TimeOnly Horariofim { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
