﻿// <auto-generated />
using System;
using GreenTeam.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenTeam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenTeam.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasData(
                        new
                        {
                            Id = "f9f1d318-e966-4f44-925c-5b661f94ae98",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1f228eeb-f6eb-481a-80ef-5d96d47358df",
                            Email = "iris@greenteam.com",
                            EmailConfirmed = true,
                            FullName = "Iris Hagen",
                            LockoutEnabled = false,
                            NormalizedEmail = "IRIS@GREENTEAM.COM",
                            NormalizedUserName = "IRIS@GREENTEAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEG5s1FPdi1uWUT5aMuroJ9Kqp2y63QBxqG7mpB3IEJgY+3niV5vtz9rordJQJuA3jQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "779dfe33-b7aa-4f35-b5d4-22dacbcc9eb9",
                            TwoFactorEnabled = false,
                            UserName = "iris@greenteam.com"
                        },
                        new
                        {
                            Id = "d9ef8fe1-a012-42b4-917d-ff4aa7af2c6d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "de731585-1998-455b-af8c-b550752e27d5",
                            Email = "marcel@greenteam.com",
                            EmailConfirmed = true,
                            FullName = "Marcel Klerken",
                            LockoutEnabled = false,
                            NormalizedEmail = "MARCEL@GREENTEAM.COM",
                            NormalizedUserName = "MARCEL@GREENTEAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFdQ+nVpIh8gz2hi/Sd2t776sDHvrTGd3f67aGCyv6ktjNEgHiZ3MR9H5Ik/HPqQQQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cadec1c1-c5d1-4cb8-9a08-2851391149c2",
                            TwoFactorEnabled = false,
                            UserName = "marcel@greenteam.com"
                        },
                        new
                        {
                            Id = "bca6b676-85d9-4737-8dff-a21b1708e32e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "53ee6d80-9711-4f74-b2fa-b25987ce7213",
                            Email = "noa@greenteam.com",
                            EmailConfirmed = true,
                            FullName = "Noa Zeegers",
                            LockoutEnabled = false,
                            NormalizedEmail = "NOA@GREENTEAM.COM",
                            NormalizedUserName = "NOA@GREENTEAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ0/Jhw0gCTXBISbkY9CaVdrGEUpW2UXN+CH0bAGIi5wyUqU5V0KFfTo079pjaZFJA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cc5a6aba-e395-4c57-83b6-57b6faf49637",
                            TwoFactorEnabled = false,
                            UserName = "noa@greenteam.com"
                        },
                        new
                        {
                            Id = "d356bc6c-2f41-4a96-b500-359cd8fe008e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5b27961e-6454-40e7-a02f-6ddc930a6775",
                            Email = "sem@greenteam.com",
                            EmailConfirmed = true,
                            FullName = "Sem Peters",
                            LockoutEnabled = false,
                            NormalizedEmail = "SEM@GREENTEAM.COM",
                            NormalizedUserName = "SEM@GREENTEAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGf5CkNvVlIQhRKlD2wa//6AVHtNCNb0LBAyKEZMgYkKtV+JXX1MghCLFrGoKKc16g==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a157c190-1ca7-4bfb-bb19-5650cef39159",
                            TwoFactorEnabled = false,
                            UserName = "sem@greenteam.com"
                        },
                        new
                        {
                            Id = "86d1b277-8b29-436a-b449-90320cd9779b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6e43cf00-8582-4c5d-b5f3-e6ae05651b60",
                            Email = "roy@greenteam.com",
                            EmailConfirmed = true,
                            FullName = "Roy Hermans",
                            LockoutEnabled = false,
                            NormalizedEmail = "ROY@GREENTEAM.COM",
                            NormalizedUserName = "ROY@GREENTEAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEP2UOJaZ9pn7OStYxkpodoLaiX31eNdFNpxGYnnQBRGgRH5Wp9bt4UN01eudmmXItg==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3a8e8304-7bd9-4289-ae6d-6774f7d5f45b",
                            TwoFactorEnabled = false,
                            UserName = "roy@greenteam.com"
                        },
                        new
                        {
                            Id = "20fc5ce4-8a75-4808-99f8-cb5c43ba6d72",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b3c60edf-6712-4ad8-a855-3da62c3b6dbd",
                            Email = "sylvia@greenteam.com",
                            EmailConfirmed = true,
                            FullName = "Sylvia Albers",
                            LockoutEnabled = false,
                            NormalizedEmail = "SYLVIA@GREENTEAM.COM",
                            NormalizedUserName = "SYLVIA@GREENTEAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEIp/RJZNX9ODQEdbeD766nd8kd8pvjiu5RN47mUGMRxptATu/SZc9Xikbh6K1IAQvw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "68104baa-b634-435f-859e-c0f0aa813780",
                            TwoFactorEnabled = false,
                            UserName = "sylvia@greenteam.com"
                        });
                });

            modelBuilder.Entity("GreenTeam.Models.Garden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Garden");
                });

            modelBuilder.Entity("GreenTeam.Models.GardenUser", b =>
                {
                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsGardenManager")
                        .HasColumnType("bit");

                    b.HasKey("GardenId", "UserId")
                        .HasName("PrimaryKey_GardenUserId");

                    b.HasIndex("UserId");

                    b.ToTable("GardenUser");
                });

            modelBuilder.Entity("GreenTeam.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("GreenTeam.Models.Patch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Crop")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<string>("PatchName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("GardenId");

                    b.ToTable("Patch");
                });

            modelBuilder.Entity("GreenTeam.Models.PatchTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PatchId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("PatchId");

                    b.ToTable("PatchTask");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GreenTeam.Models.Garden", b =>
                {
                    b.HasOne("GreenTeam.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("GreenTeam.Models.GardenUser", b =>
                {
                    b.HasOne("GreenTeam.Models.Garden", "Garden")
                        .WithMany("GardenUsers")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenTeam.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garden");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenTeam.Models.Patch", b =>
                {
                    b.HasOne("GreenTeam.Models.Garden", null)
                        .WithMany("Patches")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenTeam.Models.PatchTask", b =>
                {
                    b.HasOne("GreenTeam.Models.Patch", null)
                        .WithMany("PatchTasks")
                        .HasForeignKey("PatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GreenTeam.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GreenTeam.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenTeam.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GreenTeam.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenTeam.Models.Garden", b =>
                {
                    b.Navigation("GardenUsers");

                    b.Navigation("Patches");
                });

            modelBuilder.Entity("GreenTeam.Models.Patch", b =>
                {
                    b.Navigation("PatchTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
