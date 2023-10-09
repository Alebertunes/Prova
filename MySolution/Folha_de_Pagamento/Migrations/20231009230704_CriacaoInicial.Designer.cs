﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Folha_de_Pagamento.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20231009230704_CriacaoInicial")]
    partial class CriacaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("Folha_de_Pagamento.Models.FolhaDePagamento", b =>
                {
                    b.Property<int>("FolhaDePagamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("REAL");

                    b.Property<double?>("SalarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<double?>("Valor")
                        .HasColumnType("REAL");

                    b.Property<double?>("impostoFgts")
                        .HasColumnType("REAL");

                    b.Property<double?>("impostoInss")
                        .HasColumnType("REAL");

                    b.Property<double?>("impostoIrrf")
                        .HasColumnType("REAL");

                    b.Property<double?>("salarioBruto")
                        .HasColumnType("REAL");

                    b.HasKey("FolhaDePagamentoId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FolhaDePagamentos");
                });

            modelBuilder.Entity("Folha_de_Pagamento.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("FuncionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Folha_de_Pagamento.Models.FolhaDePagamento", b =>
                {
                    b.HasOne("Folha_de_Pagamento.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
