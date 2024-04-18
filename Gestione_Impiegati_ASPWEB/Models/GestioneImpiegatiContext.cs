using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestione_Impiegati_ASPWEB.Models;

public partial class GestioneImpiegatiContext : DbContext
{
    public GestioneImpiegatiContext()
    {
    }

    public GestioneImpiegatiContext(DbContextOptions<GestioneImpiegatiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cittum> Citta { get; set; }

    public virtual DbSet<Impiegato> Impiegatos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Reparto> Repartos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ACADEMY-01\\SQLEXPRESS;Database=gestione_impiegati;User Id=academy;Password=academy1;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cittum>(entity =>
        {
            entity.HasKey(e => e.CittaId).HasName("PK__Citta__3EF53F31B7291285");

            entity.HasIndex(e => e.Nome, "UQ__Citta__6F71C0DCDA988DF9").IsUnique();

            entity.Property(e => e.CittaId).HasColumnName("cittaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ProvinciaRif).HasColumnName("provinciaRif");

            entity.HasOne(d => d.ProvinciaRifNavigation).WithMany(p => p.Citta)
                .HasForeignKey(d => d.ProvinciaRif)
                .HasConstraintName("FK__Citta__provincia__4222D4EF");
        });

        modelBuilder.Entity<Impiegato>(entity =>
        {
            entity.HasKey(e => e.ImpiegatoId).HasName("PK__Impiegat__C7A20D1277AAA55B");

            entity.ToTable("Impiegato");

            entity.HasIndex(e => e.Matricola, "UQ__Impiegat__2C2751BA09B8DD27").IsUnique();

            entity.Property(e => e.ImpiegatoId).HasColumnName("impiegatoID");
            entity.Property(e => e.Citta)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("citta");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.DataNascita)
                .HasColumnType("datetime")
                .HasColumnName("dataNascita");
            entity.Property(e => e.Indirizzo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("indirizzo");
            entity.Property(e => e.Matricola)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("matricola");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Provincia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("provincia");
            entity.Property(e => e.RepartoRif).HasColumnName("repartoRif");
            entity.Property(e => e.Ruolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ruolo");

            entity.HasOne(d => d.RepartoRifNavigation).WithMany(p => p.Impiegatos)
                .HasForeignKey(d => d.RepartoRif)
                .HasConstraintName("FK__Impiegato__repar__3B75D760");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__671F13455070693C");

            entity.HasIndex(e => e.Nome, "UQ__Provinci__6F71C0DC2147446A").IsUnique();

            entity.Property(e => e.ProvinciaId).HasColumnName("provinciaID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Sigla)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("sigla");
        });

        modelBuilder.Entity<Reparto>(entity =>
        {
            entity.HasKey(e => e.RepartoId).HasName("PK__Reparto__612C4F36AAEB836B");

            entity.ToTable("Reparto");

            entity.HasIndex(e => e.Nome, "UQ__Reparto__6F71C0DCD5D7BA47").IsUnique();

            entity.Property(e => e.RepartoId).HasColumnName("repartoID");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
