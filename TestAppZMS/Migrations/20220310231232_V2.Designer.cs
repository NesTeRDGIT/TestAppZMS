﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAppZMS.Entity;

namespace TestAppZMS.Migrations
{
    [DbContext(typeof(MSSQLContext))]
    [Migration("20220310231232_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestAppZMS.Entity.NPR", b =>
                {
                    b.Property<int>("NPR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CODE_MD")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("COMENTN")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("DEST_LPU")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("DEST_MO")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("DS")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("FOR_POM")
                        .HasColumnType("int");

                    b.Property<int>("IDNPR")
                        .HasColumnType("int");

                    b.Property<string>("NPR_LPU")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("NPR_MO")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("NPR_NUM")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("PLAN_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PODR")
                        .HasColumnType("int");

                    b.Property<int>("PROFIL")
                        .HasColumnType("int");

                    b.Property<string>("PROFK")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("ZAP_ID")
                        .HasColumnType("int");

                    b.HasKey("NPR_ID");

                    b.HasIndex("ZAP_ID");

                    b.ToTable("NPR");
                });

            modelBuilder.Entity("TestAppZMS.Entity.ZAP", b =>
                {
                    b.Property<int>("ZAP_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("COMENTP")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DR")
                        .HasColumnType("datetime2");

                    b.Property<string>("FAM")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ID_PAC")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("IM")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("NPOLIS")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("N_ZAP")
                        .HasColumnType("int");

                    b.Property<string>("OT")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PHONE")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SMO")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("SPOLIS")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ST_OKATO")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("VPOLIS")
                        .HasColumnType("int");

                    b.Property<int>("W")
                        .HasColumnType("int");

                    b.Property<int>("ZGLV_ID")
                        .HasColumnType("int");

                    b.HasKey("ZAP_ID");

                    b.HasIndex("ZGLV_ID");

                    b.ToTable("ZAP");
                });

            modelBuilder.Entity("TestAppZMS.Entity.ZGLV", b =>
                {
                    b.Property<int>("ZGLV_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CODE")
                        .HasColumnType("int");

                    b.Property<string>("CODE_LPU")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("CODE_MO")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("DATA")
                        .HasColumnType("datetime2");

                    b.Property<int>("DAY")
                        .HasColumnType("int");

                    b.Property<string>("FILENAME")
                        .HasMaxLength(26)
                        .HasColumnType("nvarchar(26)");

                    b.Property<int>("MONTH")
                        .HasColumnType("int");

                    b.Property<string>("VERSION")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("YEAR")
                        .HasColumnType("int");

                    b.HasKey("ZGLV_ID");

                    b.ToTable("ZGLV");
                });

            modelBuilder.Entity("TestAppZMS.Entity.NPR", b =>
                {
                    b.HasOne("TestAppZMS.Entity.ZAP", "ZAP")
                        .WithMany("NPR")
                        .HasForeignKey("ZAP_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZAP");
                });

            modelBuilder.Entity("TestAppZMS.Entity.ZAP", b =>
                {
                    b.HasOne("TestAppZMS.Entity.ZGLV", "ZGLV")
                        .WithMany("ZAP")
                        .HasForeignKey("ZGLV_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZGLV");
                });

            modelBuilder.Entity("TestAppZMS.Entity.ZAP", b =>
                {
                    b.Navigation("NPR");
                });

            modelBuilder.Entity("TestAppZMS.Entity.ZGLV", b =>
                {
                    b.Navigation("ZAP");
                });
#pragma warning restore 612, 618
        }
    }
}
