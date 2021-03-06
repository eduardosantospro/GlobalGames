﻿// <auto-generated />
using System;
using GlobalGamesCet49.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GlobalGamesCet49.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210121123039_ActualizarFotoInscricao")]
    partial class ActualizarFotoInscricao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GlobalGamesCet49.Dados.Entidades.Inscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido");

                    b.Property<string>("CC");

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Localidade");

                    b.Property<string>("Morada");

                    b.Property<string>("Nome");

                    b.Property<string>("UrlDaImagem");

                    b.HasKey("Id");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("GlobalGamesCet49.Dados.Entidades.PedidoDeContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Mensagem");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("PedidosDeContacto");
                });
#pragma warning restore 612, 618
        }
    }
}
