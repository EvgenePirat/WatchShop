﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WatchShop_Infrastructure.DbContext;

#nullable disable

namespace WatchShop_Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240403071103_RenameAllNameTables")]
    partial class RenameAllNameTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.AdditionalCharacteristics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("additional_characteristics");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Brend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("brends");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Cart", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WatchId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "WatchId");

                    b.HasIndex("WatchId");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.ClockFace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("ClockFaceColorId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IndicationKindId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IndicationTypeId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ClockFaceColorId");

                    b.HasIndex("IndicationKindId");

                    b.HasIndex("IndicationTypeId");

                    b.ToTable("clock_faces");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.ClockFaceColor", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("clock_face_colors");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Country", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("countries");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Dimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaseDiameter")
                        .HasColumnType("int");

                    b.Property<double?>("Length")
                        .HasColumnType("float");

                    b.Property<double?>("Thickness")
                        .HasColumnType("float");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.Property<double?>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("dimensions");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Frame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaseShape")
                        .HasColumnType("int");

                    b.Property<int>("DimensionsId")
                        .HasColumnType("int");

                    b.Property<byte>("FrameColorId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("FrameMaterialId")
                        .HasColumnType("tinyint");

                    b.Property<int>("WaterResistance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DimensionsId");

                    b.HasIndex("FrameColorId");

                    b.HasIndex("FrameMaterialId");

                    b.ToTable("Frames");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.FrameColor", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("frame_colors");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.FrameMaterial", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("frame_materials");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.GlassType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("glass_types");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Identities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Identities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.IndicationKind", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("indication_kinds");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.IndicationType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("indication_types");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.MechanismType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("mechanism_types");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("OrderStatusId")
                        .HasColumnType("tinyint");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("order_statuses");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Strap", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<byte>("StrapMaterialId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("StrapMaterialId");

                    b.ToTable("straps");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.StrapMaterial", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("strap_materials");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Style", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("styles");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Watch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrendId")
                        .HasColumnType("int");

                    b.Property<int>("ClockFaceId")
                        .HasColumnType("int");

                    b.Property<byte>("CountryId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FrameId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<byte>("GlassTypeId")
                        .HasColumnType("tinyint");

                    b.Property<int>("Guarantee")
                        .HasColumnType("int");

                    b.Property<byte>("MechanismTypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("NameModel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<byte>("StrapId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("StyleId")
                        .HasColumnType("tinyint");

                    b.Property<int>("TimeFormat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrendId");

                    b.HasIndex("ClockFaceId");

                    b.HasIndex("CountryId");

                    b.HasIndex("FrameId");

                    b.HasIndex("GlassTypeId");

                    b.HasIndex("MechanismTypeId");

                    b.HasIndex("NameModel")
                        .IsUnique();

                    b.HasIndex("StrapId");

                    b.HasIndex("StyleId");

                    b.ToTable("watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.WatchAdditionalCharacteristics", b =>
                {
                    b.Property<int>("WatchId")
                        .HasColumnType("int");

                    b.Property<int>("AdditionalCharacteristicsId")
                        .HasColumnType("int");

                    b.HasKey("WatchId", "AdditionalCharacteristicsId");

                    b.HasIndex("AdditionalCharacteristicsId");

                    b.ToTable("watch_additional_characteristics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Cart", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Order", "Order")
                        .WithMany("Carts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Watch", "Watch")
                        .WithMany("Carts")
                        .HasForeignKey("WatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Watch");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.ClockFace", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.ClockFaceColor", "ClockFaceColor")
                        .WithMany("ClockFaces")
                        .HasForeignKey("ClockFaceColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.IndicationKind", "IndicationKind")
                        .WithMany("ClockFaces")
                        .HasForeignKey("IndicationKindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.IndicationType", "IndicationType")
                        .WithMany("ClockFaces")
                        .HasForeignKey("IndicationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClockFaceColor");

                    b.Navigation("IndicationKind");

                    b.Navigation("IndicationType");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Frame", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Dimension", "Dimensions")
                        .WithMany("Frames")
                        .HasForeignKey("DimensionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.FrameColor", "FrameColor")
                        .WithMany()
                        .HasForeignKey("FrameColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.FrameMaterial", "FrameMaterial")
                        .WithMany("Frames")
                        .HasForeignKey("FrameMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dimensions");

                    b.Navigation("FrameColor");

                    b.Navigation("FrameMaterial");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Order", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Identities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Strap", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.StrapMaterial", "StrapMaterial")
                        .WithMany("Straps")
                        .HasForeignKey("StrapMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrapMaterial");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Watch", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.Brend", "Brend")
                        .WithMany("Watches")
                        .HasForeignKey("BrendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.ClockFace", "ClockFace")
                        .WithMany("Watches")
                        .HasForeignKey("ClockFaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Country", "Country")
                        .WithMany("Watches")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Frame", "Frame")
                        .WithMany("Watches")
                        .HasForeignKey("FrameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.GlassType", "GlassType")
                        .WithMany("Watches")
                        .HasForeignKey("GlassTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.MechanismType", "MechanismType")
                        .WithMany("Watches")
                        .HasForeignKey("MechanismTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Strap", "Strap")
                        .WithMany("Watches")
                        .HasForeignKey("StrapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Style", "Style")
                        .WithMany("Watches")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brend");

                    b.Navigation("ClockFace");

                    b.Navigation("Country");

                    b.Navigation("Frame");

                    b.Navigation("GlassType");

                    b.Navigation("MechanismType");

                    b.Navigation("Strap");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.WatchAdditionalCharacteristics", b =>
                {
                    b.HasOne("WatchShop_Core.Domain.Entities.AdditionalCharacteristics", "AdditionalCharacteristics")
                        .WithMany("WatchAdditionalCharacteristics")
                        .HasForeignKey("AdditionalCharacteristicsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WatchShop_Core.Domain.Entities.Watch", "Watch")
                        .WithMany("WatchAdditionalCharacteristics")
                        .HasForeignKey("WatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdditionalCharacteristics");

                    b.Navigation("Watch");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.AdditionalCharacteristics", b =>
                {
                    b.Navigation("WatchAdditionalCharacteristics");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Brend", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.ClockFace", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.ClockFaceColor", b =>
                {
                    b.Navigation("ClockFaces");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Country", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Dimension", b =>
                {
                    b.Navigation("Frames");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Frame", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.FrameMaterial", b =>
                {
                    b.Navigation("Frames");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.GlassType", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.IndicationKind", b =>
                {
                    b.Navigation("ClockFaces");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.IndicationType", b =>
                {
                    b.Navigation("ClockFaces");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.MechanismType", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Strap", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.StrapMaterial", b =>
                {
                    b.Navigation("Straps");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Style", b =>
                {
                    b.Navigation("Watches");
                });

            modelBuilder.Entity("WatchShop_Core.Domain.Entities.Watch", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("WatchAdditionalCharacteristics");
                });
#pragma warning restore 612, 618
        }
    }
}
