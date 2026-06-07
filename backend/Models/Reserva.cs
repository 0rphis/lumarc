using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LumarcAPI.Models;

public partial class Reserva
{
    [Key]
    public int Idreserva { get; set; }

    public int Idcliente { get; set; }

    public int Idmenu { get; set; }

    public int Idhorario { get; set; }

    public int Idmesa { get; set; }

    public DateOnly Datareserva { get; set; }

    public int Qntpessoas { get; set; }

    public int Idstatus { get; set; }

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual Horario IdhorarioNavigation { get; set; } = null!;

    public virtual Menu IdmenuNavigation { get; set; } = null!;

    public virtual Status IdstatusNavigation { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual ICollection<Vinho> Idvinhos { get; set; } = new List<Vinho>();
}
