using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Vinho
{
    [Key]
    public int Idvinho { get; set; }

    public string Nomevinho { get; set; } = null!;

    public string Tipovinho { get; set; } = null!;

    public decimal Preco { get; set; }

    public int Quantidade { get; set; }

    public virtual ICollection<Reserva> Idreservas { get; set; } = new List<Reserva>();
}
