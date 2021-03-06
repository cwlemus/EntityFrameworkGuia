﻿// <auto-generated />
using System;
using EntityFrameworkGuia.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkGuia.Server.Migrations
{
    [DbContext(typeof(Facturacion_DBContext))]
    [Migration("20210218041335_Proveedor")]
    partial class Proveedor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_CLIENTE")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnName("APELLIDO")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telefono")
                        .HasColumnName("TELEFONO")
                        .HasColumnType("varchar(9)")
                        .HasMaxLength(9)
                        .IsUnicode(false);

                    b.HasKey("IdCliente");

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.DetFactura", b =>
                {
                    b.Property<int>("IdDetFactura")
                        .HasColumnName("ID_DET_FACTURA")
                        .HasColumnType("int");

                    b.Property<int?>("Cantidad")
                        .HasColumnName("CANTIDAD")
                        .HasColumnType("int");

                    b.Property<int?>("IdEncFactura")
                        .HasColumnName("ID_ENC_FACTURA")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnName("ID_PRODUCTO")
                        .HasColumnType("int");

                    b.Property<double?>("Total")
                        .HasColumnName("TOTAL")
                        .HasColumnType("float");

                    b.HasKey("IdDetFactura");

                    b.HasIndex("IdProducto");

                    b.ToTable("DET_FACTURA");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.EncFactura", b =>
                {
                    b.Property<int>("IdFactura")
                        .HasColumnName("ID_FACTURA")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnName("FECHA")
                        .HasColumnType("date");

                    b.Property<string>("FormaPago")
                        .HasColumnName("FORMA_PAGO")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("IdCliente")
                        .HasColumnName("ID_CLIENTE")
                        .HasColumnType("int");

                    b.HasKey("IdFactura");

                    b.HasIndex("IdCliente");

                    b.ToTable("ENC_FACTURA");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Usuario")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("MENU");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.Menuitem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Accion")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Controlador")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("IdPadre")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("MENUITEM");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .HasColumnName("ID_PRODUCTO")
                        .HasColumnType("int");

                    b.Property<double?>("Precio")
                        .HasColumnName("PRECIO")
                        .HasColumnType("float");

                    b.Property<string>("Producto1")
                        .HasColumnName("PRODUCTO")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdProducto");

                    b.ToTable("PRODUCTO");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .HasColumnName("ID_PROVEEDOR")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnName("APELLIDO")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .HasColumnName("NOMBRE")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdProveedor");

                    b.ToTable("PROVEEDOR");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.DetFactura", b =>
                {
                    b.HasOne("EntityFrameworkGuia.Server.Models.EncFactura", "IdProductoNavigation")
                        .WithMany("DetFactura")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_DET_FACTURA_ENC_FACTURA");

                    b.HasOne("EntityFrameworkGuia.Server.Models.Producto", "IdProducto1")
                        .WithMany("DetFactura")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_DET_FACTURA_PRODUCTO");
                });

            modelBuilder.Entity("EntityFrameworkGuia.Server.Models.EncFactura", b =>
                {
                    b.HasOne("EntityFrameworkGuia.Server.Models.Cliente", "IdClienteNavigation")
                        .WithMany("EncFactura")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_ENC_FACTURA_CLIENTE");
                });
#pragma warning restore 612, 618
        }
    }
}
