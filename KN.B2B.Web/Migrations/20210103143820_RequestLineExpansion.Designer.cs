﻿// <auto-generated />
using System;
using KN.B2B.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KN.B2B.Web.Migrations
{
    [DbContext(typeof(B2BDbContext))]
    [Migration("20210103143820_RequestLineExpansion")]
    partial class RequestLineExpansion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KN.B2B.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Att")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Channel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsVIP")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("Owner")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("GroupId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KN.B2B.Model.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("B2bInvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CancelationReasonId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EndStatus")
                        .HasColumnType("int");

                    b.Property<bool>("ExpressDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("ExpressProduction")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LegalAction")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartStatus")
                        .HasColumnType("int");

                    b.Property<bool>("TrustPilot")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TrustPilotDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CancelationReasonId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("KN.B2B.Model.RequestCommunication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Communication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Recipient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestCommunications");
                });

            modelBuilder.Entity("KN.B2B.Model.RequestLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackingCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VendorId")
                        .HasColumnType("int");

                    b.Property<double>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RequestId");

                    b.HasIndex("VendorId");

                    b.ToTable("RequestLines");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.B2BCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryGroupId");

                    b.ToTable("B2BCategory");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.B2BCategoryGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("B2BCategoryGroup");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.B2BRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("B2BRegion");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.CancelationReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("CancelationReason");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.DUNSGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DunsGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DUNSGroup");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Municipality");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("KN.B2B.Model.ZipCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("B2bRegionId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("B2bRegionId");

                    b.HasIndex("CityId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("RegionId");

                    b.ToTable("ZipCode");
                });

            modelBuilder.Entity("KN.B2B.Model.Customer", b =>
                {
                    b.HasOne("KN.B2B.Model.ZipCode", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("KN.B2B.Model.SystemTables.DUNSGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("KN.B2B.Model.Request", b =>
                {
                    b.HasOne("KN.B2B.Model.SystemTables.CancelationReason", "CancelationReason")
                        .WithMany()
                        .HasForeignKey("CancelationReasonId");

                    b.HasOne("KN.B2B.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("KN.B2B.Model.RequestCommunication", b =>
                {
                    b.HasOne("KN.B2B.Model.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("KN.B2B.Model.RequestLine", b =>
                {
                    b.HasOne("KN.B2B.Model.SystemTables.B2BCategory", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("KN.B2B.Model.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.HasOne("KN.B2B.Model.SystemTables.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("KN.B2B.Model.SystemTables.B2BCategory", b =>
                {
                    b.HasOne("KN.B2B.Model.SystemTables.B2BCategoryGroup", "CategoryGroup")
                        .WithMany()
                        .HasForeignKey("CategoryGroupId");
                });

            modelBuilder.Entity("KN.B2B.Model.ZipCode", b =>
                {
                    b.HasOne("KN.B2B.Model.SystemTables.B2BRegion", "B2bRegion")
                        .WithMany()
                        .HasForeignKey("B2bRegionId");

                    b.HasOne("KN.B2B.Model.SystemTables.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KN.B2B.Model.SystemTables.Municipality", "Municipality")
                        .WithMany()
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("KN.B2B.Model.SystemTables.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });
#pragma warning restore 612, 618
        }
    }
}
