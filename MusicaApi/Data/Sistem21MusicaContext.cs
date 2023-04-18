using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MusicaApi.Models;

namespace MusicaApi.Data;

public partial class Sistem21MusicaContext : DbContext
{
    public Sistem21MusicaContext()
    {
    }

    public Sistem21MusicaContext(DbContextOptions<Sistem21MusicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canciones> Canciones { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Canciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("canciones");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasColumnType("text")
                .HasColumnName("autor");
            entity.Property(e => e.Duracion)
                .HasColumnType("text")
                .HasColumnName("duracion");
            entity.Property(e => e.Titulo)
                .HasColumnType("text")
                .HasColumnName("titulo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
