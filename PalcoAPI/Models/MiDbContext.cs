using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PalcoAPI.Models;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Previo> Previos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=IO;Initial Catalog=GrupoPalco;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Previo>(entity =>
        {
            entity.HasKey(e => e.GuiaHouse);

            entity.ToTable("Previo");

            entity.Property(e => e.GuiaHouse)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrada).HasColumnType("datetime");
            entity.Property(e => e.FechaReconocimientoPrevio).HasColumnType("datetime");
            entity.Property(e => e.GuiaMaster)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NoDeBultos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PesoBruto).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.RecintoFiscal)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
