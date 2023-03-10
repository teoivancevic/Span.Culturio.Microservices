// <auto-generated />
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
    [Migration("20221225165756_Added_roles")]
    partial class Added_roles
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
                            PasswordHash = new byte[] { 77, 36, 218, 0, 94, 110, 89, 67, 81, 0, 185, 229, 24, 107, 128, 26, 69, 145, 166, 37, 47, 246, 136, 102, 251, 132, 173, 96, 22, 177, 163, 91, 245, 69, 136, 231, 145, 149, 90, 76, 115, 15, 90, 201, 128, 232, 32, 156, 147, 204, 158, 115, 239, 10, 67, 232, 97, 201, 213, 109, 122, 110, 114, 131 },
                            PasswordSalt = new byte[] { 165, 217, 234, 208, 205, 208, 239, 207, 125, 113, 185, 49, 122, 155, 232, 190, 225, 125, 98, 70, 248, 226, 105, 28, 198, 212, 184, 16, 40, 251, 110, 23, 22, 115, 52, 94, 166, 149, 37, 148, 115, 103, 25, 181, 123, 79, 181, 252, 147, 238, 0, 120, 41, 202, 232, 160, 170, 106, 188, 234, 147, 227, 46, 213, 193, 115, 87, 219, 101, 101, 250, 154, 78, 1, 181, 117, 193, 220, 16, 145, 197, 74, 104, 146, 84, 117, 205, 223, 58, 5, 75, 67, 159, 101, 190, 57, 153, 3, 105, 142, 220, 94, 223, 6, 87, 136, 130, 82, 138, 52, 72, 185, 3, 40, 227, 239, 146, 138, 45, 38, 170, 176, 45, 66, 21, 3, 157, 80 },
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
