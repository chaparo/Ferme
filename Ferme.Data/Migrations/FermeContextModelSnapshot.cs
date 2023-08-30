﻿// <auto-generated />
using System;
using Ferme.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ferme.Data.Migrations
{
    [DbContext(typeof(FermeContext))]
    partial class FermeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ferme.Data.Models.BasePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<double>("Text")
                        .HasColumnType("double precision");

                    b.Property<string>("UnitOfMeasureCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("BasePrice", (string)null);
                });

            modelBuilder.Entity("Ferme.Data.Models.CaisseLite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AmountWithoutRounding")
                        .HasColumnType("double precision");

                    b.Property<string>("FiscalState")
                        .HasColumnType("text");

                    b.Property<int?>("LocalReceiptID")
                        .HasColumnType("integer");

                    b.Property<double>("OriginalSalesTotal")
                        .HasColumnType("double precision");

                    b.Property<double>("PriceToPay")
                        .HasColumnType("double precision");

                    b.Property<double>("PriceToPayWithoutRounding")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("ReceiptDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ReceiptID")
                        .HasColumnType("integer");

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("VATId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("VATId");

                    b.ToTable("CaisseLite", (string)null);
                });

            modelBuilder.Entity("Ferme.Data.Models.PLU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PLU", (string)null);
                });

            modelBuilder.Entity("Ferme.Data.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaisseLiteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PaymentConfirmed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("PaymentValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CaisseLiteId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Ferme.Data.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BasePriceId")
                        .HasColumnType("integer");

                    b.Property<int?>("CaisseLiteId")
                        .HasColumnType("integer");

                    b.Property<int>("PLUId")
                        .HasColumnType("integer");

                    b.Property<double>("PriceToPay")
                        .HasColumnType("double precision");

                    b.Property<int>("VATId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BasePriceId");

                    b.HasIndex("CaisseLiteId");

                    b.HasIndex("PLUId");

                    b.HasIndex("VATId");

                    b.ToTable("Registration", (string)null);
                });

            modelBuilder.Entity("Ferme.Data.Models.VAT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Percent")
                        .HasColumnType("double precision");

                    b.Property<double>("Text")
                        .HasColumnType("double precision");

                    b.Property<int>("VATID")
                        .HasColumnType("integer");

                    b.Property<double>("VATTurnover")
                        .HasColumnType("double precision");

                    b.Property<double>("VATValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("VAT", (string)null);
                });

            modelBuilder.Entity("Ferme.Data.Models.CaisseLite", b =>
                {
                    b.HasOne("Ferme.Data.Models.VAT", "VAT")
                        .WithMany()
                        .HasForeignKey("VATId");

                    b.Navigation("VAT");
                });

            modelBuilder.Entity("Ferme.Data.Models.Payment", b =>
                {
                    b.HasOne("Ferme.Data.Models.CaisseLite", null)
                        .WithMany("Payment")
                        .HasForeignKey("CaisseLiteId");
                });

            modelBuilder.Entity("Ferme.Data.Models.Registration", b =>
                {
                    b.HasOne("Ferme.Data.Models.BasePrice", "BasePrice")
                        .WithMany()
                        .HasForeignKey("BasePriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferme.Data.Models.CaisseLite", null)
                        .WithMany("Registration")
                        .HasForeignKey("CaisseLiteId");

                    b.HasOne("Ferme.Data.Models.PLU", "PLU")
                        .WithMany()
                        .HasForeignKey("PLUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferme.Data.Models.VAT", "VAT")
                        .WithMany()
                        .HasForeignKey("VATId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasePrice");

                    b.Navigation("PLU");

                    b.Navigation("VAT");
                });

            modelBuilder.Entity("Ferme.Data.Models.CaisseLite", b =>
                {
                    b.Navigation("Payment");

                    b.Navigation("Registration");
                });
#pragma warning restore 612, 618
        }
    }
}