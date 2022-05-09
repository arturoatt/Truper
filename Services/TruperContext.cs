using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Truper.Entities;

namespace Truper.Services
{
    public partial class TruperContext : DbContext
    {
        public TruperContext()
        {
        }

        public TruperContext(DbContextOptions<TruperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PedidosDetalleW> PedidosDetalleWs { get; set; }
        public virtual DbSet<PedidosW> PedidosWs { get; set; }
        public virtual DbSet<ProductoW> ProductoWs { get; set; }
        public virtual DbSet<UsuariosW> UsuariosWs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidosDetalleW>(entity =>
            {
                entity.ToTable("PEDIDOS_DETALLE_W");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amout)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("AMOUT");

                entity.Property(e => e.IdPedido).HasColumnName("ID_PEDIDO");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Sku)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidosDetalleWs)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__PEDIDOS_D__ID_PE__2B3F6F97");
            });

            modelBuilder.Entity<PedidosW>(entity =>
            {
                entity.ToTable("PEDIDOS_W");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateSale)
                    .HasColumnType("date")
                    .HasColumnName("DATE_SALE");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.PedidosWs)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__PEDIDOS_W__USERN__286302EC");
            });

            modelBuilder.Entity<ProductoW>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PK__PRODUCTO__CA1ECF0CCCE9263C");

                entity.ToTable("PRODUCTO_W");

                entity.Property(e => e.Sku)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.Existencia).HasColumnName("EXISTENCIA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("PRICE");
            });

            modelBuilder.Entity<UsuariosW>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__USUARIOS__B15BE12F7F118835");

                entity.ToTable("USUARIOS_W");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
