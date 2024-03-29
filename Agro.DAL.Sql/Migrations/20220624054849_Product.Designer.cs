﻿// <auto-generated />
using System;
using Agro.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agro.DAL.Sql.Migrations
{
    [DbContext(typeof(AgroDb))]
    [Migration("20220624054849_Product")]
    partial class Product
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Agro.DAL.Entities.BankDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bik")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Bs")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("Ks")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NameBank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CounterpartyId");

                    b.HasIndex("StatusId");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Counterparty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Kpp")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ogrn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Okpo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeDocId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeDocId");

                    b.HasIndex(new[] { "Inn" }, "NameIndex")
                        .IsUnique();

                    b.ToTable("Counterparties");
                });

            modelBuilder.Entity("Agro.DAL.Entities.GroupDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeApplication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Покупатели",
                            TypeApplication = "Контрагенты"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Поставщики",
                            TypeApplication = "Контрагенты"
                        });
                });

            modelBuilder.Entity("Agro.DAL.Entities.Nds", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Percent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ndses");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ArticleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMini")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NdsId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("NdsId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Черновик"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Новый"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Действующий"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Заблокировано"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Актуально"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Удален"
                        });
                });

            modelBuilder.Entity("Agro.DAL.Entities.TypeDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeApplication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Юридическое лицо",
                            TypeApplication = "Контрагенты"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Индивидуальный предприниматель",
                            TypeApplication = "Контрагенты"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Государственный орган",
                            TypeApplication = "Контрагенты"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Физическое лицо",
                            TypeApplication = "Контрагенты"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Юридический адрес",
                            TypeApplication = "Адреса"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Фактический адрес",
                            TypeApplication = "Адреса"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Почтовый адрес",
                            TypeApplication = "Адреса"
                        });
                });

            modelBuilder.Entity("Agro.DAL.Entities.UnitOkei", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OkeiCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("UnitsOkei");
                });

            modelBuilder.Entity("Agro.DAL.Entities.BankDetails", b =>
                {
                    b.HasOne("Agro.DAL.Entities.Counterparty", "Counterparty")
                        .WithMany("BankDetails")
                        .HasForeignKey("CounterpartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DAL.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Counterparty");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Counterparty", b =>
                {
                    b.HasOne("Agro.DAL.Entities.GroupDoc", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DAL.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DAL.Entities.TypeDoc", "TypeDoc")
                        .WithMany()
                        .HasForeignKey("TypeDocId");

                    b.Navigation("Group");

                    b.Navigation("Status");

                    b.Navigation("TypeDoc");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Product", b =>
                {
                    b.HasOne("Agro.DAL.Entities.GroupDoc", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DAL.Entities.Nds", "Nds")
                        .WithMany()
                        .HasForeignKey("NdsId");

                    b.HasOne("Agro.DAL.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DAL.Entities.TypeDoc", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agro.DAL.Entities.UnitOkei", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Nds");

                    b.Navigation("Status");

                    b.Navigation("Type");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Agro.DAL.Entities.UnitOkei", b =>
                {
                    b.HasOne("Agro.DAL.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Counterparty", b =>
                {
                    b.Navigation("BankDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
