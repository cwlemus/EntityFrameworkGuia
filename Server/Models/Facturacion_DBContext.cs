using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkGuia.Server.Models
{
    public partial class Facturacion_DBContext : DbContext
    {
        public Facturacion_DBContext()
        {
        }

        public Facturacion_DBContext(DbContextOptions<Facturacion_DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetFactura> DetFactura { get; set; }
        public virtual DbSet<EncFactura> EncFactura { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Menuitem> Menuitem { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=LAPTOP-74AJBVCC\\SQLEXPRESS;database=Facturacion_DB;Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(p => p.IdProveedor);

                entity.ToTable("PROVEEDOR");

                entity.Property(p => p.IdProveedor)
                    .HasColumnName("ID_PROVEEDOR")
                    .ValueGeneratedNever();

                entity.Property(p => p.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(p => p.Apellido)
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(50)
                    .IsUnicode(false);                
            });
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_CLIENTE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetFactura);

                entity.ToTable("DET_FACTURA");

                entity.Property(e => e.IdDetFactura)
                    .HasColumnName("ID_DET_FACTURA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.IdEncFactura).HasColumnName("ID_ENC_FACTURA");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.Total).HasColumnName("TOTAL");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetFactura)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_DET_FACTURA_ENC_FACTURA");

                entity.HasOne(d => d.IdProducto1)
                    .WithMany(p => p.DetFactura)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_DET_FACTURA_PRODUCTO");
            });

            modelBuilder.Entity<EncFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("ENC_FACTURA");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("ID_FACTURA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("date");

                entity.Property(e => e.FormaPago)
                    .HasColumnName("FORMA_PAGO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.EncFactura)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_ENC_FACTURA_CLIENTE");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("MENU");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menuitem>(entity =>
            {
                entity.ToTable("MENUITEM");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Accion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Controlador)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("ID_PRODUCTO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Precio).HasColumnName("PRECIO");

                entity.Property(e => e.Producto1)
                    .HasColumnName("PRODUCTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
