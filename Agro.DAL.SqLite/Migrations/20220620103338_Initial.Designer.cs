﻿// <auto-generated />
using System;
using Agro.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agro.DAL.SqLite.Migrations
{
    [DbContext(typeof(AgroDB))]
    [Migration("20220620103338_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("Agro.DAL.Entities.BankDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bik")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("Bs")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("CounterpartyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ks")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameBank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CounterpartyId");

                    b.HasIndex("StatusId");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Counterparty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<string>("Kpp")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ogrn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Okpo")
                        .HasColumnType("TEXT");

                    b.Property<string>("PayName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeDocId")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Контрагенты"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Покупатели"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Поставщики"
                        });
                });

            modelBuilder.Entity("Agro.DAL.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeApplication")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Юридическое лицо",
                            TypeApplication = "Counterparty"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Индивидуальный предприниматель",
                            TypeApplication = "Counterparty"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Государственный орган",
                            TypeApplication = "Counterparty"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Физическое лицо",
                            TypeApplication = "Counterparty"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Юридический адрес",
                            TypeApplication = "Address"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Фактический адрес",
                            TypeApplication = "Address"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Почтовый адрес",
                            TypeApplication = "Address"
                        });
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
                        .HasForeignKey("GroupId");

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

            modelBuilder.Entity("Agro.DAL.Entities.GroupDoc", b =>
                {
                    b.HasOne("Agro.DAL.Entities.GroupDoc", "ParentGroup")
                        .WithMany("ChildGroups")
                        .HasForeignKey("ParentGroupId");

                    b.Navigation("ParentGroup");
                });

            modelBuilder.Entity("Agro.DAL.Entities.Counterparty", b =>
                {
                    b.Navigation("BankDetails");
                });

            modelBuilder.Entity("Agro.DAL.Entities.GroupDoc", b =>
                {
                    b.Navigation("ChildGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
