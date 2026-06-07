using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LumarcAPI.Models;

public partial class LumarcContext : DbContext
{
    public LumarcContext() { }

    public LumarcContext(DbContextOptions<LumarcContext> options)
        : base(options) { }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Vinho> Vinhos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Cpf, "cliente_cpf_key").IsUnique();

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Cpf).HasMaxLength(11).HasColumnName("cpf");
            entity.Property(e => e.Email).HasMaxLength(115).HasColumnName("email");
            entity.Property(e => e.Nome).HasMaxLength(115).HasColumnName("nome");
            entity.Property(e => e.Telefone).HasMaxLength(11).HasColumnName("telefone");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Idhorario).HasName("horarios_pkey");

            entity.ToTable("horarios");

            entity.Property(e => e.Idhorario).HasColumnName("idhorario");
            entity.Property(e => e.Horariofim).HasColumnName("horariofim");
            entity.Property(e => e.Horarioinicio).HasColumnName("horarioinicio");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Idmenu).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.Idmenu).HasColumnName("idmenu");
            entity.Property(e => e.Descricao).HasMaxLength(245).HasColumnName("descricao");
            entity.Property(e => e.Nomemenu).HasMaxLength(100).HasColumnName("nomemenu");
            entity.Property(e => e.Preco).HasPrecision(12, 2).HasColumnName("preco");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.Idmesa).HasName("mesa_pkey");

            entity.ToTable("mesa");

            entity.Property(e => e.Idmesa).HasColumnName("idmesa");
            entity.Property(e => e.Capacidade).HasColumnName("capacidade");
            entity.Property(e => e.Numeromesa).HasColumnName("numeromesa");
            entity
                .Property(e => e.Statusmesa)
                .HasMaxLength(20)
                .HasDefaultValueSql("'livre'::character varying")
                .HasColumnName("statusmesa");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Idpagamento).HasName("pagamento_pkey");

            entity.ToTable("pagamento");

            entity.Property(e => e.Idpagamento).HasColumnName("idpagamento");
            entity.Property(e => e.Datapagamento).HasColumnName("datapagamento");
            entity
                .Property(e => e.Formapagameneto)
                .HasMaxLength(25)
                .HasColumnName("formapagameneto");
            entity.Property(e => e.Idreserva).HasColumnName("idreserva");
            entity
                .Property(e => e.Statuspagamento)
                .HasMaxLength(20)
                .HasColumnName("statuspagamento");
            entity.Property(e => e.Valor).HasPrecision(12, 2).HasColumnName("valor");

            entity
                .HasOne(d => d.IdreservaNavigation)
                .WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.Idreserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagamento_idreserva_fkey");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Idreserva).HasName("reserva_pkey");

            entity.ToTable("reserva");

            entity.Property(e => e.Idreserva).HasColumnName("idreserva");
            entity.Property(e => e.Datareserva).HasColumnName("datareserva");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Idhorario).HasColumnName("idhorario");
            entity.Property(e => e.Idmenu).HasColumnName("idmenu");
            entity.Property(e => e.Idmesa).HasColumnName("idmesa");
            entity.Property(e => e.Idstatus).HasColumnName("idstatus");
            entity.Property(e => e.Qntpessoas).HasColumnName("qntpessoas");

            entity
                .HasOne(d => d.IdclienteNavigation)
                .WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_idcliente_fkey");

            entity
                .HasOne(d => d.IdhorarioNavigation)
                .WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Idhorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_idhorario_fkey");

            entity
                .HasOne(d => d.IdmenuNavigation)
                .WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Idmenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_idmenu_fkey");

            entity
                .HasOne(d => d.IdstatusNavigation)
                .WithMany(p => p.Reservas)
                .HasForeignKey(d => d.Idstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reserva_idstatus_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Idstatus).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Idstatus).HasColumnName("idstatus");
            entity.Property(e => e.Status1).HasMaxLength(30).HasColumnName("status");
        });

        modelBuilder.Entity<Vinho>(entity =>
        {
            entity.HasKey(e => e.Idvinho).HasName("vinho_pkey");

            entity.ToTable("vinho");

            entity.Property(e => e.Idvinho).HasColumnName("idvinho");
            entity.Property(e => e.Nomevinho).HasMaxLength(45).HasColumnName("nomevinho");
            entity.Property(e => e.Preco).HasPrecision(12, 2).HasColumnName("preco");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Tipovinho).HasMaxLength(25).HasColumnName("tipovinho");

            entity
                .HasMany(d => d.Idreservas)
                .WithMany(p => p.Idvinhos)
                .UsingEntity<Dictionary<string, object>>(
                    "ReservaVinho",
                    r =>
                        r.HasOne<Reserva>()
                            .WithMany()
                            .HasForeignKey("Idreserva")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("reserva_vinho_idreserva_fkey"),
                    l =>
                        l.HasOne<Vinho>()
                            .WithMany()
                            .HasForeignKey("Idvinho")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("reserva_vinho_idvinho_fkey"),
                    j =>
                    {
                        j.HasKey("Idvinho", "Idreserva").HasName("reserva_vinho_pkey");
                        j.ToTable("reserva_vinho");
                        j.IndexerProperty<int>("Idvinho").HasColumnName("idvinho");
                        j.IndexerProperty<int>("Idreserva").HasColumnName("idreserva");
                    }
                );
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
