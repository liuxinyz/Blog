﻿// <auto-generated />
using System;
using Blog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210405044634_ArticleTagsManytoMany")]
    partial class ArticleTagsManytoMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsHide")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("102fc28e-6565-4358-aa1c-46482f392880"),
                            Content = "Matrix is a rectangular two-dimensional array of numbers arranged in rows and columns. A matrix with m rows and n columns can be called an m × n matrix. Individual entries in the matrix are called elements and can be represented by a[i,j] which suggests that the element a is present in the ith row and jth column.",
                            CreateDate = new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsHide = false,
                            Title = "What is 2D Array(Matrix)?"
                        },
                        new
                        {
                            Id = new Guid("dfff1c6d-0f53-43e7-9d42-599b34adb261"),
                            Content = "wo matrices X and Y can be added if and only if they have the same dimensions that are, the same number of rows and columns. It is not possible to add a 2 × 3 matrix with a 3 × 2 matrix. The addition of two matrices can be performed by adding their corresponding elements as",
                            CreateDate = new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsHide = false,
                            Title = "Addition of two matrices"
                        },
                        new
                        {
                            Id = new Guid("94bb3b9a-6145-4a4f-833f-86c937c9df90"),
                            Content = "SOLID design principles in C# are basic design principles. SOLID stands for Single Responsibility Principle (SRP), Open closed Principle (OSP), Liskov substitution Principle (LSP), Interface Segregation Principle (ISP), and Dependency Inversion Principle (DIP). ",
                            CreateDate = new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsHide = false,
                            Title = "SOLID Principles In C#"
                        });
                });

            modelBuilder.Entity("Blog.Models.ArticlePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BaseSixFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticlePictures");
                });

            modelBuilder.Entity("Blog.Models.ArticleTag", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTag");
                });

            modelBuilder.Entity("Blog.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Blog.Models.ArticlePicture", b =>
                {
                    b.HasOne("Blog.Models.Article", "Article")
                        .WithMany("ArticlePictures")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Blog.Models.ArticleTag", b =>
                {
                    b.HasOne("Blog.Models.Article", "Article")
                        .WithMany("Tags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blog.Models.Tag", "Tag")
                        .WithMany("Articles")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Blog.Models.Article", b =>
                {
                    b.Navigation("ArticlePictures");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Blog.Models.Tag", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
