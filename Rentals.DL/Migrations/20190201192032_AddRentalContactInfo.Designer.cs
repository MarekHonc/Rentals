﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rentals.DL;

namespace Rentals.DL.Migrations
{
    [DbContext(typeof(EntitiesContext))]
    [Migration("20190201192032_AddRentalContactInfo")]
    partial class AddRentalContactInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Rentals.DL.Entities.AdminInvite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiresAt");

                    b.Property<string>("ForUser")
                        .IsRequired();

                    b.Property<bool>("IsRedeemed");

                    b.Property<bool>("WillBeAdmin");

                    b.Property<bool>("WillBeEmployee");

                    b.HasKey("Id");

                    b.ToTable("AdminInvites");
                });

            modelBuilder.Entity("Rentals.DL.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("ItemId");

                    b.Property<int>("RentingId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("RentingId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Rentals.DL.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverImage");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("ItemTypeId");

                    b.Property<string>("Note");

                    b.Property<string>("UniqueIdentifier")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("UniqueIdentifier")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Rentals.DL.Entities.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RentalId");

                    b.HasKey("Id");

                    b.HasIndex("RentalId");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("Rentals.DL.Entities.ItemTypeToItemType", b =>
                {
                    b.Property<int>("AccesoryId");

                    b.Property<int>("AccesoryToId");

                    b.HasKey("AccesoryId", "AccesoryToId");

                    b.HasIndex("AccesoryToId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("Rentals.DL.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("ContactEmail")
                        .IsRequired();

                    b.Property<string>("ContactPhone");

                    b.Property<TimeSpan>("EndsAt");

                    b.Property<int>("MinTimeUnit");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<TimeSpan>("StartsAt");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Rentals.DL.Entities.Renting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndsAt");

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartsAt");

                    b.Property<int>("State");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Rentings");
                });

            modelBuilder.Entity("Rentals.DL.Entities.RentingToItem", b =>
                {
                    b.Property<int>("RentingId");

                    b.Property<int>("ItemId");

                    b.HasKey("RentingId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("RentingToItems");
                });

            modelBuilder.Entity("Rentals.DL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("RoleType");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Rentals.DL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Basket");

                    b.Property<string>("Class");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Rentals.DL.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Rentals.DL.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Rentals.DL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Rentals.DL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Rentals.DL.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentals.DL.Entities.History", b =>
                {
                    b.HasOne("Rentals.DL.Entities.Item", "Item")
                        .WithMany("History")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentals.DL.Entities.Renting", "Renting")
                        .WithMany()
                        .HasForeignKey("RentingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentals.DL.Entities.Item", b =>
                {
                    b.HasOne("Rentals.DL.Entities.ItemType", "Type")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentals.DL.Entities.ItemType", b =>
                {
                    b.HasOne("Rentals.DL.Entities.Rental", "Rental")
                        .WithMany("ItemTypes")
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentals.DL.Entities.ItemTypeToItemType", b =>
                {
                    b.HasOne("Rentals.DL.Entities.ItemType", "Accesory")
                        .WithMany("AccesoryTo")
                        .HasForeignKey("AccesoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Rentals.DL.Entities.ItemType", "AccesoryTo")
                        .WithMany("Accessories")
                        .HasForeignKey("AccesoryToId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Rentals.DL.Entities.Renting", b =>
                {
                    b.HasOne("Rentals.DL.Entities.User", "User")
                        .WithMany("Rentings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentals.DL.Entities.RentingToItem", b =>
                {
                    b.HasOne("Rentals.DL.Entities.Item", "Item")
                        .WithMany("RentingToItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentals.DL.Entities.Renting", "Renting")
                        .WithMany("RentingToItems")
                        .HasForeignKey("RentingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rentals.DL.Entities.UserRole", b =>
                {
                    b.HasOne("Rentals.DL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rentals.DL.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}