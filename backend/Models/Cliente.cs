using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Cliente
{
    [Key]
    public int Idcliente { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
