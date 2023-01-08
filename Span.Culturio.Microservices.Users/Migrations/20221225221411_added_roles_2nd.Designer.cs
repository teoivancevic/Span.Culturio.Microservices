﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Span.Culturio.Microservices.Users.Data;

#nullable disable

namespace Span.Culturio.Microservices.Users.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221225221411_added_roles_2nd")]
    partial class added_roles_2nd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Span.Culturio.Microservices.Users.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PlatformAdmin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CultureObjectAdmin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Span.Culturio.Microservices.Users.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@culturio.eu",
                            FirstName = "Admin",
                            LastName = "User",
                            PasswordHash = new byte[] { 31, 131, 10, 207, 119, 117, 23, 41, 183, 203, 112, 229, 26, 149, 160, 196, 63, 82, 221, 128, 224, 3, 62, 7, 51, 171, 9, 188, 169, 194, 39, 238, 65, 18, 124, 155, 125, 172, 16, 149, 122, 64, 6, 193, 245, 30, 52, 4, 91, 196, 110, 152, 205, 76, 179, 41, 53, 238, 163, 190, 67, 42, 250, 189 },
                            PasswordSalt = new byte[] { 250, 229, 155, 214, 41, 173, 111, 60, 3, 151, 161, 162, 92, 122, 248, 118, 252, 159, 70, 28, 56, 170, 243, 121, 115, 94, 221, 203, 230, 55, 56, 91, 139, 117, 250, 7, 82, 29, 15, 139, 205, 123, 129, 198, 152, 115, 36, 91, 147, 30, 100, 127, 43, 81, 141, 235, 94, 29, 5, 176, 179, 117, 54, 221, 192, 98, 121, 48, 192, 90, 249, 149, 187, 247, 208, 234, 151, 10, 197, 132, 221, 35, 37, 216, 74, 198, 39, 207, 142, 169, 65, 28, 28, 195, 46, 128, 66, 199, 175, 253, 96, 63, 114, 151, 62, 227, 91, 25, 137, 129, 25, 44, 50, 77, 8, 116, 157, 126, 172, 67, 254, 74, 82, 150, 150, 22, 100, 60 },
                            RoleId = 1,
                            Username = "sysadmin"
                        });
                });

            modelBuilder.Entity("Span.Culturio.Microservices.Users.Data.Entities.User", b =>
                {
                    b.HasOne("Span.Culturio.Microservices.Users.Data.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Span.Culturio.Microservices.Users.Data.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
