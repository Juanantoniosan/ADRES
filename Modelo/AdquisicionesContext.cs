using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaAdres.Modelo;

public partial class AdquisicionesContext : DbContext
{
    public AdquisicionesContext()
    {
    }

    public AdquisicionesContext(DbContextOptions<AdquisicionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adquisicione> Adquisiciones { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<TipoBienoServicio> TipoBienoServicios { get; set; }

    public virtual DbSet<Unidad> Unidads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Adquisiciones.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adquisicione>(entity =>
        {
            entity.HasKey(e => e.AdquisicionId);

            entity.Property(e => e.AdquisicionId).HasColumnName("AdquisicionID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.TipoBienoServicioId).HasColumnName("TipoBienoServicioID");
            entity.Property(e => e.UnidadId).HasColumnName("UnidadID");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Adquisiciones)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TipoBienoServicio).WithMany(p => p.Adquisiciones)
                .HasForeignKey(d => d.TipoBienoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Unidad).WithMany(p => p.Adquisiciones)
                .HasForeignKey(d => d.UnidadId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.ToTable("Proveedor");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
        });

        modelBuilder.Entity<TipoBienoServicio>(entity =>
        {
            entity.ToTable("TipoBienoServicio");

            entity.Property(e => e.TipoBienoServicioId).HasColumnName("TipoBienoServicioID");
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.ToTable("Unidad");

            entity.Property(e => e.UnidadId).HasColumnName("UnidadID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
