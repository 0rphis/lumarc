using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Pagamento
{
    [Key]
    public int Idpagamento { get; set; }

    public int Idreserva { get; set; }

    public decimal? Valor { get; set; }

    public string Formapagameneto { get; set; } = null!;

    public DateOnly Datapagamento { get; set; }

    public string Statuspagamento { get; set; } = null!;

    public virtual Reserva IdreservaNavigation { get; set; } = null!;
}
