using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvcCrud.Models
{
    public partial class MvcCrudContext : DbContext
    {
        public MvcCrudContext()
        {
        }

        public MvcCrudContext(DbContextOptions<MvcCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActaNota> ActaNotas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActaNota>(entity =>
            {
                entity.HasKey(e => e.IdNotasE)
                    .HasName("PK__ActaNota__C2D0AC29FB62B959");

                entity.Property(e => e.Apellido).HasMaxLength(30);

                entity.Property(e => e.Carnet).HasMaxLength(12);

                entity.Property(e => e.Iipn).HasColumnName("IIPN");

                entity.Property(e => e.Ipn).HasColumnName("IPN");

                entity.Property(e => e.Nf).HasColumnName("NF");

                entity.Property(e => e.Nombre).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
