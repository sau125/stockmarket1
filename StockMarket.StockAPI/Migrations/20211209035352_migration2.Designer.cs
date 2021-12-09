﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockMarket.StockAPI.DBContext;

namespace StockMarket.StockAPI.Migrations
{
    [DbContext(typeof(StockDBContext))]
    [Migration("20211209035352_migration2")]
    partial class migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockMarket.StockAPI.Entities.Company", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BoardOfDirectors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyBrief")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("CompanyTurnOver")
                        .HasColumnType("real");

                    b.Property<string>("ListedInStockExchanges")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CompanyName");

                    b.HasIndex("CompanyCode");

                    b.HasIndex("SectorId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.IPODetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OpenDatetime")
                        .HasColumnType("datetime2");

                    b.Property<long>("PricePerShare")
                        .HasColumnType("bigint");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("StockExchangeCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalShare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("IPOList");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.Sectors", b =>
                {
                    b.Property<string>("SectorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SectorId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.StockExchange", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Brief")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("StockExchangeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("StockExchange");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.StockPrice", b =>
                {
                    b.Property<string>("PriceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CurrentStockPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime");

                    b.Property<string>("StockExchangeId")
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("PriceId");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("StockPrice");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.Company", b =>
                {
                    b.HasOne("StockMarket.StockAPI.Entities.StockPrice", "StockPrice")
                        .WithMany()
                        .HasForeignKey("CompanyCode");

                    b.HasOne("StockMarket.StockAPI.Entities.Sectors", "Sectors")
                        .WithMany()
                        .HasForeignKey("SectorId");

                    b.Navigation("Sectors");

                    b.Navigation("StockPrice");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.IPODetails", b =>
                {
                    b.HasOne("StockMarket.StockAPI.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("StockMarket.StockAPI.Entities.StockPrice", b =>
                {
                    b.HasOne("StockMarket.StockAPI.Entities.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId");

                    b.Navigation("StockExchange");
                });
#pragma warning restore 612, 618
        }
    }
}
