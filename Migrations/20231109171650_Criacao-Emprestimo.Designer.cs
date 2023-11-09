﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoBiblioteca.Models;

#nullable disable

namespace ProjetoBiblioteca.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231109171650_Criacao-Emprestimo")]
    partial class CriacaoEmprestimo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoBiblioteca.Models.Devolucao", b =>
                {
                    b.Property<int>("DevolucaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DevolucaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DevolucaoId"));

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataDevolucao");

                    b.Property<int>("EmprestimoId")
                        .HasColumnType("int");

                    b.HasKey("DevolucaoId");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("Devolucao");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Emprestimo", b =>
                {
                    b.Property<int>("EmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmprestimoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmprestimoId"));

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataEmprestimo");

                    b.Property<DateTime>("DevolucaoPrevista")
                        .HasColumnType("datetime2")
                        .HasColumnName("DevolucaoPrevista");

                    b.Property<bool>("Devolvido")
                        .HasColumnType("bit")
                        .HasColumnName("Devolvido");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("EmprestimoId");

                    b.HasIndex("LivroId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Emprestimo");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GeneroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("GeneroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GeneroNome");

                    b.HasKey("GeneroId");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LivroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"));

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("LivroAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LivroAutor");

                    b.Property<string>("LivroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LivroNome");

                    b.HasKey("LivroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PessoaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("PessoaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PessoaNome");

                    b.Property<int>("PessoaRM")
                        .HasColumnType("int")
                        .HasColumnName("PessoaRM");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Reclamacao", b =>
                {
                    b.Property<int>("ReclamacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReclamacaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReclamacaoId"));

                    b.Property<string>("DescReclamacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescReclamacao");

                    b.Property<byte[]>("LivroImagem")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("LivroImagem");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("ReclamacaoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Reclamacao");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Sugestao", b =>
                {
                    b.Property<int>("SugestaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SugestaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SugestaoId"));

                    b.Property<string>("DescSugestao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescSugestao");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("SugestaoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Sugestao");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Devolucao", b =>
                {
                    b.HasOne("ProjetoBiblioteca.Models.Emprestimo", "Emprestimo")
                        .WithMany()
                        .HasForeignKey("EmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emprestimo");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Emprestimo", b =>
                {
                    b.HasOne("ProjetoBiblioteca.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoBiblioteca.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Livro", b =>
                {
                    b.HasOne("ProjetoBiblioteca.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Reclamacao", b =>
                {
                    b.HasOne("ProjetoBiblioteca.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ProjetoBiblioteca.Models.Sugestao", b =>
                {
                    b.HasOne("ProjetoBiblioteca.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
